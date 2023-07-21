using System.Collections.Generic;
using ShopManagement.Core.Entities.ProductAgg;

namespace ShopManagement.Core.Entities.ProductCategoryAgg
{
    public class ProductCategoryEntity : Base.Core.BaseEntities.BaseEntity<long>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
      
        public List<ProductEntity> Products { get; private set; }

        public ProductCategoryEntity()
        {
            Products = new List<ProductEntity>();
        }

        public ProductCategoryEntity(string name, string description, string picture,
            string pictureAlt, string pictureTitle, string keywords, string metaDescription,
            string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
            Products = new List<ProductEntity>();
        }

        public void Edit(string name, string description, string picture,
            string pictureAlt, string pictureTitle, string keywords, string metaDescription,
            string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
        }
      
    }
}
