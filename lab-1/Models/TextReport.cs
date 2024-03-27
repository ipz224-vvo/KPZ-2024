using lab_1.Interfaces;
using lab_1.Services;
using System.Text;

namespace lab_1.Models;

public class TextReport : IReport
{
    public Guid Id { get; set; }
    public DateTime CreationDate { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Product>? ProductsInfo { get; set; }
    public Warehouse? Warehouse { get; set; }
    public ReportType ReportType { get; set; }
    public string Extension => ".txt";
    public string FormIncomeReport()
    {
        var stringBuilder = FormHeader(ReportType);
        if (ProductsInfo == null || ProductsInfo.Count == 0)
        {
            stringBuilder.AppendLine("No info about products");
            return stringBuilder.ToString();
        }
        stringBuilder.AppendLine("Products: ");
        ProductsInfo.ForEach(product => stringBuilder.AppendLine(FormProductLine(product)));
        return stringBuilder.ToString();
    }

    public string FormOutcomeReport()
    {
        var stringBuilder = FormHeader(ReportType);
        if (ProductsInfo == null || ProductsInfo.Count == 0)
        {
            stringBuilder.AppendLine("No info about products");
            return stringBuilder.ToString();
        }
        ProductsInfo.ForEach(product => stringBuilder.AppendLine(FormProductLine(product)));
        return stringBuilder.ToString();
    }

    public string FormInventReport()
    {
        var stringBuilder = FormHeader(ReportType);
        if (Warehouse == null)
        {
            stringBuilder.AppendLine("No info about warehouse");
            return stringBuilder.ToString();
        }

        stringBuilder.AddWarehouseTextInfo(Warehouse);

        if (Warehouse.Products == null)
        {
            stringBuilder.AppendLine("No info about products in warehouse");
            return stringBuilder.ToString();
        }
        stringBuilder.AppendLine("Products: ");
        Warehouse.Products.ForEach(product => stringBuilder.AppendLine(FormProductLine(product)));

        double currentCapacity = Warehouse.CurrentCapacity;
        double maxCapacity = Warehouse.MaxCapacity;
        stringBuilder.AppendLine($"Warehouse available capacity: {currentCapacity}/{maxCapacity} ({currentCapacity / maxCapacity}%)");

        return stringBuilder.ToString();
    }

    protected StringBuilder FormHeader(ReportType reportType)
    {
        string type;
        switch (reportType)
        {
            case ReportType.Income: type = "Income Report"; break;
            case ReportType.Outcome: type = "Outcome Report"; break;
            case ReportType.Invent: type = "Invent Report"; break;
            default: type = "UNKNOWN REPORT TYPE"; break;
        }

        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine($"Report Id - {Id}");
        stringBuilder.AppendLine($"Type: {type}");
        stringBuilder.AppendLine($"Title - {Title}");
        stringBuilder.AppendLine($"Description - {Description}");
        stringBuilder.AppendLine($"Date - {CreationDate}");
        return stringBuilder;
    }

    protected string FormProductLine(Product product)
    {
        return $"{product.Id}|{product.Name}|{product.Price}" +
                $"|{product.ExpirationDate}|{product.DateOfEntry}" +
                $"|{product.Weight}|{product.Unit}";
    }

}
