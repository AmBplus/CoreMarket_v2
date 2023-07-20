
using Base.Infrastructure.Dapper;
using Microsoft.Extensions.Configuration;


namespace ShopManagement.Data
{
    public class ShopManagementDapperContext : DapperContext
    {
        public ShopManagementDapperContext(DapperSettings settings) : base(settings)
        {
        }
    }
}
