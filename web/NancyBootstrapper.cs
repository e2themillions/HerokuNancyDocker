
using Nancy;
using Nancy.Conventions;
using Nancy.TinyIoc;

using Microsoft.AspNetCore.Hosting;
namespace web
{
    public class NancyBootstrapper : DefaultNancyBootstrapper
    {

        private IHostingEnvironment _env;
        public NancyBootstrapper(IHostingEnvironment environment)
        {
            _env = environment;
        }

        protected override IRootPathProvider RootPathProvider => new NancyRootPathProvider(_env);

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("dist", "dist"));
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.AddDirectory("css");
            nancyConventions.StaticContentsConventions.AddDirectory("js");
            nancyConventions.StaticContentsConventions.AddDirectory("fonts");
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            //container.Register<IAppConfiguration>(appConfig);
        }
    }
}
