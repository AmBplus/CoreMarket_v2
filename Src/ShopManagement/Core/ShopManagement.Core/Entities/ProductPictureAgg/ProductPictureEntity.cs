using ShopManagement.Core.Entities.ProductAgg;

namespace ShopManagement.Core.Entities.ProductPictureAgg
{
    public class ProductPictureEntity : Base.Core.BaseEntities.BaseEntity<long>
    {
        public long ProductId { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        
        public ProductEntity Product { get; private set; }

        public ProductPictureEntity(long productId, string picture, string pictureAlt, string pictureTitle)
        {
            ProductId = productId;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            
        }

        public void Edit(long productId, string picture, string pictureAlt, string pictureTitle)
        {
            ProductId = productId;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
        }

     
    }
}
