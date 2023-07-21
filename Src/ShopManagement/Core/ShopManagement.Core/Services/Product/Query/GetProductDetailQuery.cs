using Base.Resourses;
using Base.Shared.ResultUtility;
using Dapper;
using MediatR;
using ShopManagement.Core.Data;
using ShopManagement.Core.Services.Product.DtoViewModel;
using ShopManagement.Core.Services.Product.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopManagement.Core.Services.Product.Query
{
    public record GetProductDetailQueryRequest(long Id) : IRequest<ResultOperation<ProductDetailsDto>>
    {

    }

    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQueryRequest, ResultOperation<ProductDetailsDto>> , IGetProductDetailQueryHandler
    {
        public GetProductDetailQueryHandler(IShopManagementDapperContext  context)
        {
            Context = context;
        }

        public IShopManagementDapperContext Context { get; }

        public async Task<ResultOperation<ProductDetailsDto>> Handle(GetProductDetailQueryRequest request, CancellationToken cancellationToken)
        {
            using (var connection = Context.CreateConnection())
            {
                var query = @"SELECT TOP 1
                    [Id],
                    [CreatedDate],
                    [UpdateDate],
                    [Name],
                    [Description],
                    [Picture] AS [ImageSrc],
                    [PictureAlt] AS [ImageAlt],
                    [PictureTitle] AS [ImageTitle],
                    [Keywords],
                    [MetaDescription],
                    [Slug]
                FROM [ProductEntity]
                WHERE [Id] = @Id";
               var result = await connection.QueryFirstOrDefaultAsync<ProductDetailsDto>(query, new { Id = request.Id });
                if (result == null)
                {
                    return ResultOperation<ProductDetailsDto>.ToFailedResult(ErrorMessages.EntityNotFind);
                }
                return result.ToSuccessResult();
            }
            
        }
    }
}
