# Asp.NET Mvc Bootstrap Flash Messages

[![NuGet version](https://badge.fury.io/nu/Santhos.Web.Mvc.BootstrapFlashMessages@2x.png)](https://badge.fury.io/nu/Santhos.Web.Mvc.BootstrapFlashMessages)

Asp.NET Mvc Bootstrap Flash Messages extends MVC Controllers with methods to create flash messages easily.

- The library uses [ControllerBase.TempData][1] to store the flash messages between the requests.

- It uses [Bootstrap Alerts][2] to display the flash messages.

## Usage

### In a controller action

Create Flash Messages using one of the 4 Controller extension methods: 

_FlashSuccess, FlashWarning, FlashDanger, FlashInfo_

Each method has two parameters - message and its parameters - (string message, params object[] messageArgs).

```csharp
using static Santhos.Web.Mvc.BootstrapFlashMessages.FlashControllerExtensions;

...

public ActionResult Index()
{
    this.FlashSuccess("Password changed successfully");

    var userName = "Gordon Flash";
    var userId = 5;
    this.FlashWarning("User {0} with Id {1} is a good person", userName, userId);

    // imagine you have a resource file called Localised.resx
    this.FlashInfo(Localised.MyLocalisedString, username, userId);
    
    return this.View();
}
```

### In a razor view

Show Flash Messages using HtmlHelper extension method _FlashMessages(bool dismissable)_

```csharp
@using static Santhos.Web.Mvc.BootstrapFlashMessages

...

@* 
   Set dismissable to true if you want the flash messages 
   to be dismissable (Bootstrap feature, requires proper Bootstrap javascript) 
*@
@Html.FlashMessages()
@Html.FlashMessages(true)

...
```

[1]: "https://msdn.microsoft.com/en-us/library/system.web.mvc.controllerbase.tempdata(v=vs.118).aspx"
[2]: "http://getbootstrap.com/components/#alerts"
