using Funq;
using Mitto.Messenger.Core.Configs;
using Mitto.Messenger.Services;
using ServiceStack;
using ServiceStack.Api.Swagger;
using ServiceStack.Data;
using ServiceStack.MiniProfiler;
using ServiceStack.MiniProfiler.Data;
using ServiceStack.OrmLite;
using ServiceStack.Text;
using ServiceStack.Validation;

namespace Mitto.Messenger.ServiceHost.Configurations
{
  public class MessageServiceHost : AppHostBase
  {
    public MessageServiceHost() : base("Web Services - SMS Messaging Platform", typeof(MessageServices).Assembly)
    { }
  
    public override void Configure(Container container)
    {
      //Config Plugins
      Plugins.Add(new CorsFeature());
      Plugins.Add(new SwaggerFeature());

      container.RegisterValidators(typeof(SendSMSValidator).Assembly);
      Plugins.Add(new ValidationFeature());
      //Plugins.RemoveAll(x => x is MetadataFeature);

      container.Register<IDbConnectionFactory>(
          c => new OrmLiteConnectionFactory(AppSettings.GetString("ConnectionString"), MySqlDialect.Provider)
          {
            ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current)
          });

      using (var db = container.Resolve<IDbConnectionFactory>().Open())
      {
        DatabaseConfig.Initialize(db);
      }

      JsConfig.DateHandler = DateHandler.ISO8601;
    }
  }
}