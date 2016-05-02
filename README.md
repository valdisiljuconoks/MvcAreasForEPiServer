# Asp.Net Mvc Areas for EPiServer
Add Asp.Net Mvc areas support for EPiServer project

## Getting Started

```
PM> Install-Package MvcAreasForEPiServer
```

After you installed this NuGet package, you will need to kick off area registration (usually this could be done in `Global.asax.cs`)

```
namespace MyProject
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            AreaConfiguration.RegisterAllAreas();
        }
    }
}
```

By default configuration setting to detect Mvc Area by controller will be enabled.

## Configuration

If you want to disable Mvc Area detection by controller, you can choose configuration settings to customize this behavior during areas registration procedure.

```
[InitializableModule]
[ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
public class ConfigureAreasSupportModule : IInitializableModule
{
    public void Initialize(InitializationEngine context)
    {
        AreaConfiguration.RegisterAllAreas(config =>
        {
            config.EnableAreaDetectionByController = true;
            config.EnableAreaDetectionBySite = true;
        });
    }

    public void Uninitialize(InitializationEngine context)
    {
    }
}
```

There are two configuration settings:

* `EnableAreaDetectionByController`: this setting will make sure that Mvc Area is detected while executing controller for particular content type in that area;
* `EnableAreaDetectionBySite`: this setting will make sure that Mvc Area is detected when accessing EPiServer site that is also defined as Mvc Area;


## More info
[General description](http://blog.tech-fellow.net/2015/01/21/full-support-for-asp-net-mvc-areas-in-episerver-7-5/)<br/>
How to use Mvc Areas as [EPiServer's](http://episerver.com) [site discriminators](http://blog.tech-fellow.net/2015/08/10/asp-net-mvc-areas-in-episerver-part-2/)<br/>
Asp.Net Mvc Area support in EPiServer - [part 2](http://blog.tech-fellow.net/2015/08/10/asp-net-mvc-areas-in-episerver-part-2/)
