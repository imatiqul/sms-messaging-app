using System;

namespace Mitto.Messenger.Client
{
  public class Global : System.Web.HttpApplication
  {
    protected void Application_Start(object sender, EventArgs e)
    {
      new ClientAppServiceHost().Init();
    }
  }
}