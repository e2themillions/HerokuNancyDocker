using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nancy;
using Microsoft.AspNetCore.Hosting;
namespace web
{
    public class NancyRootPathProvider: IRootPathProvider
    {
        private readonly IHostingEnvironment _environment;

        public NancyRootPathProvider(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public string GetRootPath()
        {
            return _environment.WebRootPath;
        }
    }
}
