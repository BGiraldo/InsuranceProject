﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Insurance.MVC.Startup))]
namespace Insurance.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
