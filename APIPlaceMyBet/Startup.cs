using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(APIPlaceMyBet.Startup))]

namespace APIPlaceMyBet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app); 
        }
    }
}
