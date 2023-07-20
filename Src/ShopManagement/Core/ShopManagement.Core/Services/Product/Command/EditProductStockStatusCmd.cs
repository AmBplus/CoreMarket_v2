using Base.Resourses;
using Base.Shared.ResultUtility;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopManagement.Core.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ShopManagement.Core.Services.Product.Command
{
    public interface IEditProductStockStatusCmdHandler
    {
        Task<ResultOperation> Handle(EditProductStockStatusCmdRequest request, CancellationToken cancellationToken);
    }
    public record EditProductStockStatusCmdRequest(long Id , bool IsStock) : IRequest<ResultOperation>
    {
        
    }
    public class EditProductStockStatusCmdHandler : IRequestHandler<EditProductStockStatusCmdRequest, ResultOperation> , IEditProductStockStatusCmdHandler
    {
        public EditProductStockStatusCmdHandler(ILogger<EditProductStockStatusCmdRequest> logger , ShopManagementEfCoreContext context)
        {
            Context = context;
        }

        public ShopManagementEfCoreContext Context { get; }

        public async Task<ResultOperation> Handle(EditProductStockStatusCmdRequest request, CancellationToken cancellationToken)
        {
            var product = await Context.ProductEntities.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (product == null) return ResultOperation.BuildFailedResult(ErrorMessages.EntityNotFind);

            product.ChangeStock(request.IsStock);
            Context.Update(product);
            await Context.SaveChangesAsync();
            return ResultOperation.BuildSuccessResult();
        }
    }
}
