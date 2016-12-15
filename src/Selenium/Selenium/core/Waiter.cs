using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Threading;

namespace Selenium.core
{
    public class Waiter
    {
        private readonly TimeSpan _checkInterval;
        private readonly Stopwatch _stopwatch;
        private readonly TimeSpan _timeout;

        private Waiter(TimeSpan timeout)
            : this(timeout, TimeSpan.FromSeconds(1))
        {
        }

        private Waiter(TimeSpan timeout, TimeSpan checkInterval)
        {
            Contract.Requires(timeout >= TimeSpan.Zero);
            Contract.Requires(checkInterval >= TimeSpan.Zero);

            _timeout = timeout;
            _checkInterval = checkInterval;
            _stopwatch = Stopwatch.StartNew();
        }

        public bool IsSatisfied { get; private set; } = true;

        public static Waiter WithTimeout(TimeSpan timeout, TimeSpan pollingInterval)
        {
            return new Waiter(timeout, pollingInterval);
        }

        public static Waiter WithTimeout(TimeSpan timeout)
        {
            return new Waiter(timeout);
        }

        public Waiter WaitFor(Func<bool> condition)
        {
            Contract.Requires(condition != null);

            if (!IsSatisfied)
                return this;

            while (!condition())
            {
                var sleepAmount = Min(_timeout - _stopwatch.Elapsed, _checkInterval);

                if (sleepAmount < TimeSpan.Zero)
                {
                    IsSatisfied = false;
                    break;
                }

                Thread.Sleep(sleepAmount);
            }

            return this;
        }

        public void EnsureSatisfied()
        {
            if (!IsSatisfied)
                throw new TimeoutException();
        }

        public void EnsureSatisfied(string message)
        {
            Contract.Requires(message != null);

            if (!IsSatisfied)
                throw new TimeoutException(message);
        }

        public static bool SpinWait(Func<bool> condition, TimeSpan timeout)
        {
            return SpinWait(condition, timeout, TimeSpan.FromSeconds(1));
        }

        public static bool SpinWait(Func<bool> condition, TimeSpan timeout, TimeSpan pollingInterval)
        {
            return WithTimeout(timeout, pollingInterval).WaitFor(condition).IsSatisfied;
        }

        public static bool Try(Action action)
        {
            Exception exception;

            return Try(action, out exception);
        }

        public static bool Try(Action action, out Exception exception)
        {
            Contract.Requires(action != null);

            try
            {
                action();
                exception = null;

                return true;
            }
            catch (Exception e)
            {
                exception = e;

                return false;
            }
        }

        public static Func<bool> MakeTry(Action action)
        {
            return () => Try(action);
        }

        private static T Min<T>(T left, T right) where T : IComparable<T>
        {
            return left.CompareTo(right) < 0 ? left : right;
        }
    }
}