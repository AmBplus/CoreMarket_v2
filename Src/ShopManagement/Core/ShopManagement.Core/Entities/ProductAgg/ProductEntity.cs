
using System.Collections.Generic;
using ShopManagement.Core.Entities.ProductCategoryAgg;
using ShopManagement.Core.Entities.ProductPictureAgg;

namespace ShopManagement.Core.Entities.ProductAgg
{
    public class ProductEntity : Base.Core.BaseEntities.BaseEntity<long>
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public double UnitPrice { get; private set; }
        public bool IsStock { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public long CategoryId { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public ProductCategoryEntity Category { get; private set; }
        public List<ProductPictureEntity> ProductPictures { get; private set; }

        public ProductEntity(string name, string code, double unitPrice,
            string shortDescription, string description, string picture,
            string pictureAlt, string pictureTitle, long categoryId, string slug,
            string keywords, string metaDescription)
        {
            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            IsStock = true;
            ProductPictures = new List<ProductPictureEntity>();
        }

        public void Edit(string name, string code, double unitPrice,
            string shortDescription, string description, string picture,
            string pictureAlt, string pictureTitle, long categoryId, string slug,
            string keywords, string metaDescription)
        {
            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
        }

        public void ChangeStock(bool status)
        {
            IsStock = status;
        }
        
    }
}
