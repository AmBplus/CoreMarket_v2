using ShopManagement.Core.Services.Product.DtoViewModel;

namespace ShopManagement.Core.Services.Product.DtoViewModel
{
    public class EditProductCmd : CreateProductCmd
    {
        public long Id { get; set; }
    }
}
