using Microsoft.AspNetCore.Identity;
using PharmacyApp.Models;
using PharmacyApp.Repositories;
using PharmacyApp.ViewModels;

namespace PharmacyApp.Services
{
    public class ProductService : IProductService<ProductViewModel>
    {
        private readonly IRepository<Products> _productRepository;

        public ProductService(IRepository<Products> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();

            return products.Select(p => new ProductViewModel
            {
                ProductName = p.ProductName,
                Price = p.Price,
                Description = p.Description,
                StockQuantity = p.StockQuantity,
                ProductPicUrl = p.ProductPicUrl,
                ProductCategory = p.ProductCategory
            });
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProductsByCategory(string category)
        {
            var products = await _productRepository.GetAllAsync();

            var productbyCategory = products.Where(p => p.ProductCategory == category);
            
            var selectAllProductsByCategory = productbyCategory
            .Select(p => new ProductViewModel
            {
                ProductName = p.ProductName,
                Price = p.Price,
                Description = p.Description,
                StockQuantity = p.StockQuantity,
                ProductPicUrl = p.ProductPicUrl,
                ProductCategory = p.ProductCategory
            });


            return selectAllProductsByCategory;
        }

        public async Task<IEnumerable<ProductViewModel>> SearchForProductByName(string productName)
        { 
            var products = await _productRepository.GetAllAsync();
            var productsByName = products.Where(p=>p.ProductName == productName);

            if (productsByName == null)
            {
                throw new Exception();
            }

            var selectAllProductsByName = productsByName
            .Select(p => new ProductViewModel
            {
                ProductName = p.ProductName,
                Price = p.Price,
                Description = p.Description,
                StockQuantity = p.StockQuantity,
                ProductPicUrl = p.ProductPicUrl,
                ProductCategory = p.ProductCategory
            });

            return selectAllProductsByName;
        }

        public async Task<ProductViewModel> getProductByName(string Name)
        { 
            var accessProductByName = await _productRepository.GetByNameAsync(Name);
            if(accessProductByName == null) 
            {
                throw new Exception();
            }

            return new ProductViewModel
            {
                ProductName = accessProductByName.ProductName,
                Price = accessProductByName.Price,
                Description = accessProductByName.Description,
                StockQuantity = accessProductByName.StockQuantity,
                ProductPicUrl = accessProductByName.ProductPicUrl,
                ProductCategory = accessProductByName.ProductCategory
            };

        }

        public async Task<ProductViewModel> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return new ProductViewModel
            {
                ProductName = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                StockQuantity = product.StockQuantity,
                ProductPicUrl = product.ProductPicUrl,
                ProductCategory = product.ProductCategory

            };

        }

        public async Task<IEnumerable<ProductViewModel>> GetTop3Products()
        {
            var products = await _productRepository.GetAllAsync();

            var top3 = products.OrderBy(p => p.StockQuantity).Take(3)
            .Select(p => new ProductViewModel
            {

                ProductName = p.ProductName,
                Price = p.Price,
                Description = p.Description,
                StockQuantity = p.StockQuantity,
                ProductPicUrl = p.ProductPicUrl,
                ProductCategory = p.ProductCategory

            }
            );
            return top3;

        }

        public async Task<ProductViewModel> GetProductByID(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            
            if(product == null)
            {
                throw new Exception();
            }

            return new ProductViewModel
            {   ProductName = product.ProductName, 
                Price = product.Price, 
                Description = product.Description, 
                StockQuantity = product.StockQuantity, 
                ProductPicUrl = product.ProductPicUrl, 
                ProductCategory = product.ProductCategory 
            };  
        }

        public async Task<ProductViewModel> purchaseProduct(string Name)
        { 
            var product = await _productRepository.GetByNameAsync(Name);

            if (product == null)
            {
                throw new Exception();
            }

            // If  product is out of stock, throw an exception
            if (product.StockQuantity <= 0)
            {
                throw new Exception("Product is out of stock");
            }

            // Reduce stock by 1
            product.StockQuantity -= 1;

            // Update the database with the new stock quantity
            await _productRepository.UpdateAsync(product);

            return new ProductViewModel
            {
                ProductName = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                StockQuantity = product.StockQuantity,
                ProductPicUrl = product.ProductPicUrl,
                ProductCategory = product.ProductCategory
            };

           
        }


    }
}
