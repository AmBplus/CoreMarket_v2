using Base.Resourses;
using Base.Shared.ResultUtility;
using Base.Shared;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopManagement.Core.Data;
using ShopManagement.Core.Entities.ProductAgg;
using ShopManagement.Core.Services.ProductCategory.DtoViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShopManagement.Core.Services.Product.Command
{
    public record UpdateProductCmdRequest : IRequest<ResultOperation>
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
        [Range(1, 100000, ErrorMessageResourceType = typeof(PropertiesName), ErrorMessageResourceName = nameof(PropertiesName.CategoryId))]
        public long CategoryId { get; set; }
        //***********************************************************************************************
        [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Categories))]
        public List<ProductCategoryViewModel> Categories { get; set; }
        //***********************************************************************************************
        [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Id))]
        [Range(minimum: 1, maximum: long.MaxValue, ErrorMessageResourceType = typeof(ErrorMessages)
      , ErrorMessageResourceName = nameof(ErrorMessages.OutofMinMax))]
        public long Id { get; set; }
        //***********************************************************************************************
        public ProductEntity MapToProduct()
        {
            return new ProductEntity(Name, Code,
                UnitPrice, ShortDescription,
                Description, Picture,
                PictureAlt, PictureTitle,
                CategoryId, Slug.Slugify(),
                Keywords, MetaDescription);
        }
        public ProductEntity MapToProduct(ProductEntity product)
        {
            product.Edit(Name, Code,
                UnitPrice, ShortDescription,
                Description, Picture,
                PictureAlt, PictureTitle,
                CategoryId, Slug.Slugify(),
                Keywords, MetaDescription);
            return product;
        }
    }

    public interface IUpdateProductCmdHandler
    {
        Task<ResultOperation> Handle(UpdateProductCmdRequest request, CancellationToken cancellationToken);
    }
    public class UpdateProductCmdHandler : IRequestHandler<UpdateProductCmdRequest, ResultOperation>, IUpdateProductCmdHandler
    {
        public UpdateProductCmdHandler(ILogger<CreateProductCmdHandler> logger, ShopManagementEfCoreContext context)
        {
            Logger = logger;
            Context = context;
        }

        public ILogger<CreateProductCmdHandler> Logger { get; }
        public ShopManagementEfCoreContext Context { get; }

        public async Task<ResultOperation> Handle(UpdateProductCmdRequest request, CancellationToken cancellationToken)
        {
            var resultValidate = request.GetValidationResults();
            if (!resultValidate.IsSuccess) return resultValidate;
            var result = Context.ProductEntities.FirstOrDefault(x => x.Id == request.Id);
            if (result == null) return ResultOperation.BuildFailedResult(string.Format(ErrorMessages.EntityNotFind));
            var product = request.MapToProduct(result);
            Context.Update(product);
            await Context.SaveChangesAsync();
            return ResultOperation.BuildSuccessResult();
        }
    }
}
