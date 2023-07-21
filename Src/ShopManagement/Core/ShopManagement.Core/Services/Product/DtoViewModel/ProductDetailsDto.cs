using System;
using System.Collections.Generic;

namespace ShopManagement.Core.Services.Product.DtoViewModel;

public class ProductDetailsDto
{
    public long Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string ImageSrc { get; private set; }
    public string ImageAlt { get; private set; }
    public string ImageTitle { get; private set; }
    public string Keywords { get; private set; }
    public string MetaDescription { get; private set; }
    public string Slug { get; private set; }
    public string Category { get; set; }
    public string CategoryId { get; set; }
    public List<string> PictureImages { get; set; }
    
}
