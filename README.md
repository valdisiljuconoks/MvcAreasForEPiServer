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


More info: [here](http://tech-fellow.net/2015/01/22/full-support-asp-net-mvc-areas-episerver-7-5/)
<br/>
More info about using Mvc Areas as EPiServer's site discriminators [here](http://blog.tech-fellow.net/2015/08/10/asp-net-mvc-areas-in-episerver-part-2/)
