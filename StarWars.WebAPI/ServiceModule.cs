using Autofac;
using StarWars.Model;
using StarWars.Service;

namespace StarWars.WebAPI
{
    internal class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            // Register services...
            
            builder.RegisterType<CharacterRepository>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<EpisodeRepository>().AsSelf().InstancePerLifetimeScope();

            
        }
    }
}
