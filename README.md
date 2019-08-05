Selenium WebDriver in C#
===========

This repository contains Webdriver code examples, exercises and tutorials for developers.
Over time, more and more test example will be uploaded here.
All tests examples in this repository is to be considered public domain unless stated otherwise.  

**NOTE:** Currently supports the chrome Driver, and Gecko (firefox) support is on the way.

## Demo website to practice Webdriver:
Here is a list of websites where you can practice Selenium webdriver. You will find the list incredibly useful as these will cover many of your real-time web automation use case scenario. Some of the common examples includes are like testing of a login page, online registration forms, and automating flight booking. 
 
- [Madison Island](http://magento-demo.lexiconn.com/)
- [The Internet by Elemental Selenium](http://the-internet.herokuapp.com/)
- [jQuery UI Demos](http://jqueryui.com/demos/)
- [PHPTRAVELS](http://phptravels.com/demo/)
- [Mercury Tours](http://newtours.demoaut.com/)
- [PHPTRAVELS](http://phptravels.com/demo/)
- [Way2Automation](http://www.way2automation.com/demo.html)
- [Automation Practice](http://automationpractice.com/index.php)
- [DemoQA](http://demoqa.com/)
- [OrangeHRM Enterprise](http://enterprise.demo.orangehrmlive.com/symfony/web/index.php/auth/login)

## Examples with:

- [ ] Mouse hover
- [ ] Drag & Drop
- [ ] Draggable
- [ ] Selectable
- [ ] Sortable
- [ ] Actionable
- [ ] Radio Button
- [ ] Checkbox
- [ ] Datepicker


## Pre-requisites
- Windows OS
- Visual Studio 


## Let's get started

#### Clone the git repo
```
$ git clone https://github.com/sayems/csharp.webdriver
```

#### Install Visual Studio and .NET Core

- (1) [Install Visual Studio](https://www.visualstudio.com/en-us/visual-studio-homepage-vs.aspx)
- (2) [.NET Core](https://www.microsoft.com/net/download/core)
- (3) Start Visual Studio.
- (4) On the menu bar, choose File, Open, Project/Solution.  
      Navigate to the csharp.webdriver project folder and open it

#### Install NUnit Templates for Visual Studio 
-  Go to Tools > Extensions and Update
-  Select > Online
-  Search for "[NUnit Templates for Visual Studio](https://marketplace.visualstudio.com/items?itemName=NUnitDevelopers.NUnitTemplatesforVisualStudio)"

#### Install NUnit 3 Test Adapter
-  Go to Tools > Extensions and Update
-  Select > Online
-  Search for "[NUnit 3 Test Adapter](https://marketplace.visualstudio.com/items?itemName=NUnitDevelopers.NUnit3TestAdapter)" and install it

#### Install Nuget package
-  Right-click on your project and click “Manage NuGet Packages”.
-  Search for "Microsoft.Extensions.Configuration.UserSecrets" and install it
-  Search for "System.Diagnostics.Contracts" and install it
-  Search for "[NUnit](https://www.nuget.org/packages/NUnit/)" Framework and install it

#### Install Selenium
Currently, there is no official support for .NET Core, But there is a Nuget package which provides .NET Core support for those of us who can’t wait, please visit [CoreCompat.Selenium.WebDriver](https://www.nuget.org/packages/CoreCompat.Selenium.WebDriver/2.54.0-beta002)  to learn more about it.

#### Install *Unofficial* Selenium for .Net Core
-  Search for "CoreCompat.Selenium.WebDriver" library and install it

### Create NUnit test
Click on *Create new project*
![](https://github.com/sayems/csharp.webdriver/blob/master/docs/images/start-page.png)

Select *Test* and then Select *NUnit 3 Test Project* to create NUnit 3 project
![](https://github.com/sayems/csharp.webdriver/blob/master/docs/images/nunit3-test.png)


### Add NUnit test from Solution Explorer

Right-click on your project and click *Add* and then *New Item*
![](https://github.com/sayems/csharp.webdriver/blob/master/docs/images/add-test.png)

Select *Test* and then select *NUnit Test Fixture* or *NUnit Setup Fixture*
![](https://github.com/sayems/csharp.webdriver/blob/master/docs/images/new-test.png)

Congratulations! You have just created your first NUnit test!



### Issues
Parallel execution of methods within a class is not yet implemented. More information is provided here: [Run test methods within a fixture in parallel](https://github.com/nunit/nunit/issues/164)



### Contributions

If you have any code examples you would like to contribute to this repository, please feel free to open a pull request.

## Feedback

Contributors to this repo would be very grateful to receive feedback! If you would like to praise or comment on any test examples, or the repo as a whole, please do so in the issue tracker. I'd love to hear what you think, so please take a moment to let me know.


## Contact

If you have any questions about this repo, or need some help to contribute, please do not hesitate to contact me.
