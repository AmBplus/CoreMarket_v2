using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopManagement.Core.Services.Product.Query
{
    public record GetProductSearchQueryRequest : IRequest<GetProductSearchQueryResponse>    
    {
        public string Name { get; set; }
    }
    public record GetProductSearchQueryResponse
    {

    }
    public class GetProductSearchQueryHandler : IRequestHandler<GetProductSearchQueryRequest, GetProductSearchQueryResponse> , IGetProductSearchQueryHandler
    {
        public async Task<GetProductSearchQueryResponse> Handle(GetProductSearchQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
