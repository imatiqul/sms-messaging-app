using Funq;
using Mitto.Messenger.Client.ServiceInterface;
using ServiceStack;
using ServiceStack.Razor;

namespace Mitto.Messenger.Client
{
  public class ClientAppServiceHost : AppHostBase
  {
    /// <summary>
    /// Base constructor requires a Name and Assembly where web service implementation is located
    /// </summary>
    public ClientAppServiceHost()
        : base("Messenger Client", typeof(ClientServices).Assembly)
    { }

    /// <summary>
    /// Application specific configuration
    /// This method should initialize any IoC resources utilized by your web service classes.
    /// </summary>
    public override void Configure(Container container)
    {
      //Config Plugins
      Plugins.Add(new CorsFeature());

      this.Plugins.Add(new RazorFormat());
    }
  }
}