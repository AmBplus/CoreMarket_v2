using Base.Core;
using Base.Core.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedServices
{
    public class BootstrapServices
    {
        public IServiceCollection InjectServices(IServiceCollection services,IConfiguration configuration)
        {
            
          //  services.AddTransient<IDapperContext, DapperContext>();
            return services;
        }
    }
}
