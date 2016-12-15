namespace Selenium.core
{
    public struct JavaScriptEvent
    {
        public readonly string Name;

        public JavaScriptEvent(string name) : this()
        {
            Name = name;
        }

        public static implicit operator string(JavaScriptEvent x)
        {
            return x.Name;
        }

        public override string ToString()
        {
            return Name;
        }

        public static readonly JavaScriptEvent KeyUp = new JavaScriptEvent("keyup");
        public static readonly JavaScriptEvent Click = new JavaScriptEvent("click");
    }
}