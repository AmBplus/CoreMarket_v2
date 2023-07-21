
using Base.Infrastructure.Dapper;
using ShopManagement.Core.Data;
using Microsoft.Extensions.Configuration;


namespace ShopManagement.Data
{
    public class ShopManagementDapperContext : DapperContext , IShopManagementDapperContext
    {
        public ShopManagementDapperContext(DapperSettings settings) : base(settings)
        {
        }
    }
}
