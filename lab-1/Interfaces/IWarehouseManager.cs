using lab_1.Models;

namespace lab_1.Interfaces;

public interface IWarehouseManager
{
    public void AddProduct(Product product);
    public void RemoveProduct(int id);
    public void UpdateProduct(Product product, int id);
    public void AddProducts(List<Product> products);
    public Product? GetProductById(int id);
    public List<Product> GetAllProducts();
}
