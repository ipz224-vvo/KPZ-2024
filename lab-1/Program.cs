using lab_1.Interfaces;
using lab_1.Managers;
using lab_1.Models;
using lab_1.Services;

namespace lab_1;

class Program
{
    static void Main(string[] args)
    {
        var rand = new Random();
        ILogger logger = new Logger();

        IReportingService reportingService = new ReportingService(logger);
        reportingService.reportsPath = Directory.GetCurrentDirectory() + "/reports";


        Warehouse warehouse = new Warehouse()
        {
            Id = rand.Next(0, 100),
            Title = "WorkShop title",
            Address = "Chudnivska",
            MaxCapacity = 1000,
        };
        var products = GetMockProducts();
        warehouse.Manager = new WarehouseManager(warehouse, logger);

        warehouse.Manager.AddProducts(products);

        var htmlReport = GetHtmlReport(products);
        reportingService.CreateReport(htmlReport);
        var textReport = GetTextReport(products);
        reportingService.CreateReport(textReport);



    }

    static List<Product> GetMockProducts()
    {
        var now = DateTime.Now;
        var rand = new Random();
        var products = new List<Product>();
        int last = rand.Next(0, 20);
        for (int i = 0; i < last; i++)
        {
            var price = new Dollar();
            price.SetMoney(rand.Next(0, 100), rand.Next(0, 99));
            var expDate = DateOnly.FromDateTime(now.AddDays(rand.Next(0, 90)));
            int id = rand.Next(0, 10000);
            var tempProduct = new Product
            {
                Id = id,
                Name = "Product " + id,
                Description = "Desc " + id,
                DateOfEntry = now,
                ExpirationDate = expDate,
                Price = price,
                Unit = "kg",
                Weight = rand.NextDouble() * 100 + 0.1,
                OccupiedCapacity = rand.NextDouble() * 100 + 0.1,
            };
            products.Add(tempProduct);
        }
        return products;
    }

    static IReport GetTextReport(List<Product>? products = null, Warehouse? warehouse = null)
    {
        var rand = new Random();
        int last = rand.Next(0, 20);
        var textReport = new TextReport()
        {
            Id = Guid.NewGuid(),
            Title = "Title " + last,
            Description = "Desc " + last,
            CreationDate = DateTime.Now,
            ProductsInfo = products ?? null,
            Warehouse = warehouse ?? null,
            ReportType = ReportType.Income
        };
        return textReport;
    }
    static IReport GetHtmlReport(List<Product>? products = null, Warehouse? warehouse = null)
    {
        var rand = new Random();
        int last = rand.Next(0, 20);
        var htmlReport = new HtmlReport()
        {
            Id = Guid.NewGuid(),
            Title = "Title " + last,
            Description = "Desc " + last,
            CreationDate = DateTime.Now,
            ProductsInfo = products ?? null,
            Warehouse = warehouse ?? null,
            ReportType = ReportType.Income
        };
        return htmlReport;
    }
}
