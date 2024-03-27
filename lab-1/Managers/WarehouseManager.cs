using lab_1.Interfaces;
using lab_1.Models;

namespace lab_1.Managers;

public class WarehouseManager : IWarehouseManager
{
    private Warehouse _warehouse;
    private ILogger _logger;
    public WarehouseManager(Warehouse warehouse, ILogger logger)
    {
        _logger = logger;
        _warehouse = warehouse;
    }
    public void AddProduct(Product product)
    {
        if (!isProductWillFit(product))
            return;
        _warehouse.Products.Add(product);
        _logger.Info("");
    }

    public void AddProducts(List<Product> products)
    {
        foreach (var product in products)
        {
            if (!isProductWillFit(product))
            {
                _logger.Error($"Product \"{product.Name}\"({product.Id}) capacity bigger than available!");
                return;
            }
            _warehouse.Products.Add(product);
        }
        _logger.Info("Products successfully added.");
    }

    public List<Product> GetAllProducts()
    {
        return _warehouse.Products;
    }

    public Product? GetProductById(int id)
    {
        return _warehouse.Products.SingleOrDefault(p => p.Id == id);
    }

    public void RemoveProduct(int id)
    {
        var product = GetProductById(id);
        if (product != null)
        {
            _warehouse.Products.Remove(product);
        }
    }

    public void UpdateProduct(Product product, int id)
    {
        _warehouse.Products.ForEach(p => { if (p.Id == id) p = product; });
    }

    protected bool isProductWillFit(Product product)
        => _warehouse.CurrentCapacity + product.OccupiedCapacity < _warehouse.MaxCapacity;

}
