using Base.Shared.ResultUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Threading;

namespace ShopManagement.Core.Services.Product.Command
{
    public record CreateProductCmdRequest : IRequest<ResultOperation>
    {
    }

    public interface ICreateProductCmdHandler
    {
        Task<ResultOperation> Handle(CreateProductCmdRequest request,CancellationToken cancellationToken);
    }
    public class CreateProductCmdHandler : IRequestHandler<CreateProductCmdRequest, ResultOperation>,ICreateProductCmdHandler
    {
        public async Task<ResultOperation> Handle(CreateProductCmdRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
