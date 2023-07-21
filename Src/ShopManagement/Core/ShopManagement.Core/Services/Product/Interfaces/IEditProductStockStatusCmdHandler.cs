using Base.Shared.ResultUtility;
using ShopManagement.Core.Services.Product.Command;
using System.Threading;
using System.Threading.Tasks;

namespace ShopManagement.Core.Services.Product.Interfaces
{
    public interface IEditProductStockStatusCmdHandler
    {
        Task<ResultOperation> Handle(EditProductStockStatusCmdRequest request, CancellationToken cancellationToken);
    }
}
