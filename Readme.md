<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128549704/14.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T163285)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/Q588216/Controllers/HomeController.cs)
* [MyModel.cs](./CS/Q588216/Models/MyModel.cs)
* [_FormLayoutPartial.cshtml](./CS/Q588216/Views/Home/_FormLayoutPartial.cshtml)
* [_GridViewPartial.cshtml](./CS/Q588216/Views/Home/_GridViewPartial.cshtml)
* [Index.cshtml](./CS/Q588216/Views/Home/Index.cshtml)
<!-- default file list end -->
# GridView - EditFormTemplate with strong-typed FormLayout
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t163285/)**
<!-- run online end -->


<p>You can find how to place a FormLayout inside the EditForm template in the <a href="https://www.devexpress.com/Support/Center/p/T102593">A simple implementation of FormLayout inside EditFormTemplate</a> example (which does not use the FormLayout strong-typed feature). The advantages of the strong-typed approach:<br /><br />1. The built-in client-side Unobtrusive validation;<br /><br />2. If you change the name of a model property, you will easily find places where you need to change that name as well when compiling your project.<br /><br />The main idea of this example is to create a separate partial view with a FormLayout. Since the grid requires a model that represents a list of data items, but to be strong-typed, a FormLayout should be bound to a single item, this approach will allow us to use a strong-typed model in the partial view with a FormLayout and pass a particular item from the Grid partial view to the FormLayout partial view.<br /><br />Take a note at how the "Update" and "Cancel" button client-side clicks are handled:</p>


```cs
btnSettings.ClientSideEvents.Click = string.Format("function(s, e) {{ {0}.UpdateEdit(); }}", settings.Name);

```


<p> </p>


```vb
btnSettings.ClientSideEvents.Click = String.Format("function(s, e) {{ {0}.UpdateEdit(); }}", settings.Name)
```


<p> </p>
<p>As you can see, instead of a hard-coded grid view extension name, the settings.Name property is used. This will ensure that the corresponding client-side methods will be precisely executed for our grid view extension.</p>

<br/>


