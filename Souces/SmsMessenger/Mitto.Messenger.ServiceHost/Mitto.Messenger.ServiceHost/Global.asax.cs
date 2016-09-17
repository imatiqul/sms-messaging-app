using ServiceStack.MiniProfiler;
using System;

namespace Mitto.Messenger.ServiceHost
{
  public class Global : System.Web.HttpApplication
  {
    protected void Application_Start(object sender, EventArgs e)
    {
      new Configurations.MessageServiceHost().Init();
    }
    
    protected void Application_BeginRequest(object src, EventArgs e)
    {
      if (Request.IsLocal)
        Profiler.Start();
    }

    protected void Application_EndRequest(object src, EventArgs e)
    {
      Profiler.Stop();
    }
  }
}