using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopManagement.Core.Data;
using ShopManagement.Core.Services.Product.DtoViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopManagement.Core.Services.Product.Query
{
    public record GetProductSearchQueryRequest : IRequest<ProductViewModel>    
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public long CategoryId { get; set; }
    }
  
    public class GetProductSearchQueryHandler : IRequestHandler<GetProductSearchQueryRequest, ProductViewModel> , IGetProductSearchQueryHandler
    {
        public GetProductSearchQueryHandler(ILogger<GetProductSearchQueryHandler>  logger , IShopManagementDapperContext context)
        {
            Logger = logger;
            Context = context;
        }

        public ILogger<GetProductSearchQueryHandler> Logger { get; }
        public IShopManagementDapperContext Context { get; }

        public async Task<ProductViewModel> Handle(GetProductSearchQueryRequest request, CancellationToken cancellationToken)
        {
            using (var conection  = Context.CreateConnection())
            {
                var query = @"select Id  Picture Name Code Category CategoryId CreationDate";
                await conection.QueryAsync(query);
 
              }
            throw new NotImplementedException();    
        }
    }
}
