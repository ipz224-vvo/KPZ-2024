using lab_1.Interfaces;

namespace lab_1.Models;

public class Warehouse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public double MaxCapacity { get; set; }
    public double CurrentCapacity => Products.Sum(p => p.OccupiedCapacity);
    public List<Product> Products { get; set; } = new List<Product>();
    public IWarehouseManager Manager { get; set; }
}
