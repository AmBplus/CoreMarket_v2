using Base.Resourses;
using System.ComponentModel.DataAnnotations;
using ShopManagement.Core.Services.Product.DtoViewModel;

namespace ShopManagement.Core.Services.Product.DtoViewModel;

public class UpdateProductCmd : CreateProductCmd
{
    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Id))]
    [Range(minimum: 1, maximum: long.MaxValue, ErrorMessageResourceType = typeof(ErrorMessages)
        , ErrorMessageResourceName = nameof(ErrorMessages.OutofMinMax))]
    public long Id { get; set; }
}
