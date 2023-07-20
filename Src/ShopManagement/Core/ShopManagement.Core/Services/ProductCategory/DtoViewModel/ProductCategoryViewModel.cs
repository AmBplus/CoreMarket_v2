using Base.Resourses;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Core.Services.ProductCategory.DtoViewModel;

public class ProductCategoryViewModel
{
    public long Id { get; set; }
    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Name))]
    public string Name { get; set; }
    public string ImageSrc { get; set; }
    public string CreationDate { get; set; }

}
