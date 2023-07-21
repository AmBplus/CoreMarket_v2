using Base.Shared.ResultUtility;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using System.Threading;
using Base.Resourses;
using System.ComponentModel.DataAnnotations;
using Base.Shared;
using Microsoft.Extensions.Logging;
using ShopManagement.Core.Data;
using ShopManagement.Core.Entities.ProductAgg;
using ShopManagement.Core.Services.ProductCategory.DtoViewModel;
using ShopManagement.Core.Services.Product.Interfaces;

namespace ShopManagement.Core.Services.Product.Command
{
    public record CreateProductCmdRequest : IRequest<ResultOperation>
    {
        [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Name))]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]
        public string Name { get; set; }
        //***********************************************************************************************
        [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Description))]
        public string? Description { get; set; }

        //***********************************************************************************************
        [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.ImageSrc))]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]
        public string ImageSrc { get; set; }

        //***********************************************************************************************
        [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.ImageAlt))]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]
        public string ImageAlt { get; set; }

        //***********************************************************************************************
        [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.ImageTitle))]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]
        public string ImageTitle { get; set; }

        //***********************************************************************************************
        [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Keywords))]
        public string? Keywords { get; set; }

        //***********************************************************************************************
        [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.MetaDescription))]
        public string? MetaDescription { get; set; }

        //***********************************************************************************************
        [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Slug))]
        public string? Slug { get; set; }
        //***********************************************************************************************
        [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Slug))]
        public string? Code { get; set; }
        //***********************************************************************************************
        [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.UnitPrice))]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]
        public double UnitPrice { get; set; }
        //***********************************************************************************************
        [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.ShortDescription))]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]
        public string ShortDescription { get; set; }
        //***********************************************************************************************
        [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Image))]
        public string Picture { get; set; }
        //***********************************************************************************************
        [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.ImageAlt))]
        public string PictureAlt { get; set; }
        //***********************************************************************************************
        [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.ImageTitle))]
        public string PictureTitle { get; set; }
        //***********************************************************************************************
        [Range(1, 100000 ,ErrorMessageResourceType = typeof(PropertiesName),ErrorMessageResourceName = nameof(PropertiesName.CategoryId))]
        public long CategoryId { get; set; }
        //***********************************************************************************************
        [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Categories))]
        public List<ProductCategoryViewModel> Categories { get; set; }
        //***********************************************************************************************


        public  ProductEntity MapToProduct( )
        {
            return new ProductEntity(Name,Code,
                UnitPrice, ShortDescription,
                Description, Picture,
                PictureAlt, PictureTitle,
                CategoryId, Slug.Slugify(),
                Keywords, MetaDescription);
        }
    }

  
    public class CreateProductCmdHandler : IRequestHandler<CreateProductCmdRequest, ResultOperation>,ICreateProductCmdHandler
    {
        public CreateProductCmdHandler(ILogger<CreateProductCmdHandler> logger , IShopManagementEfCoreContext context)
        {
            Logger = logger;
            Context = context;
        }

        public ILogger<CreateProductCmdHandler> Logger { get; }
        public IShopManagementEfCoreContext Context { get; }

        public async Task<ResultOperation> Handle(CreateProductCmdRequest request, CancellationToken cancellationToken)
        {
          var resultValidate =   request.GetValidationResults();
            if (!resultValidate.IsSuccess) return resultValidate;
            var product = request.MapToProduct();
            Context.Update(product);
            await Context.SaveChangesAsync();
            return ResultOperation.ToSuccessResult();
        }
    }
}
