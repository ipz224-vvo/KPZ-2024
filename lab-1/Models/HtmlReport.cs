using lab_1.Interfaces;
using lab_1.Services;
using System.Text;

namespace lab_1.Models;

public class HtmlReport : IReport
{
    public Guid Id { get; set; }
    public DateTime CreationDate { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Product>? ProductsInfo { get; set; }
    public Warehouse? Warehouse { get; set; }
    public ReportType ReportType { get; set; }
    public string Extension => ".html";
    public string FormIncomeReport()
    {
        StringBuilder stringBuilder = new();
        stringBuilder.Append(FormHtmlHeader());
        stringBuilder.Append(FormHeader(ReportType));
        if (ProductsInfo == null || ProductsInfo.Count == 0)
        {
            stringBuilder.AppendLine("<p>No info about products</p>");
            return stringBuilder.ToString();
        }
        stringBuilder.Append(FormProductTables(ProductsInfo));
        stringBuilder.Append(FormHtmlFooter());
        return stringBuilder.ToString();
    }

    public string FormInventReport()
    {
        StringBuilder stringBuilder = new();
        stringBuilder.Append(FormHtmlHeader());
        stringBuilder.Append(FormHeader(ReportType));
        if (ProductsInfo == null || ProductsInfo.Count == 0)
        {
            stringBuilder.AppendLine("<p>No info about products</p>");
            return stringBuilder.ToString();
        }
        stringBuilder.Append(FormProductTables(ProductsInfo));
        stringBuilder.Append(FormHtmlFooter());

        return stringBuilder.ToString();
    }

    public string FormOutcomeReport()
    {
        StringBuilder stringBuilder = new();
        stringBuilder.Append(FormHtmlHeader());
        stringBuilder.Append(FormHeader(ReportType));
        if (Warehouse == null)
        {
            stringBuilder.AppendLine("<p>No info about warehouse</p>");
            return stringBuilder.ToString();
        }

        stringBuilder.AddWarehouseHtmlInfo(Warehouse);

        if (Warehouse.Products == null)
        {
            stringBuilder.AppendLine("<p>No info about products in warehouse</p>");
            return stringBuilder.ToString();
        }
        stringBuilder.Append(FormProductTables(Warehouse.Products));

        double currentCapacity = Warehouse.CurrentCapacity;
        double maxCapacity = Warehouse.MaxCapacity;
        stringBuilder.AppendLine($"<p>Warehouse available capacity: {currentCapacity}/{maxCapacity} ({currentCapacity / maxCapacity}%)</p>");

        stringBuilder.Append(FormHtmlFooter());
        return stringBuilder.ToString();
    }
    protected string FormHtmlHeader()
    {
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine("<!DOCTYPE html>");
        stringBuilder.AppendLine("<html>");
        stringBuilder.AppendLine("<style> table, th, td { border:1px solid black; border-collapse: collapse; }</style>");
        stringBuilder.AppendLine("<body>");
        return stringBuilder.ToString();
    }
    protected string FormHtmlFooter()
    {
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine("</body>");
        stringBuilder.AppendLine("</html>");
        return stringBuilder.ToString();
    }
    protected string FormHeader(ReportType reportType)
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
        stringBuilder.AppendLine($"<h1>{Title}</h1>");
        stringBuilder.AppendLine($"<h3>{Description}</h3>");
        stringBuilder.AppendLine($"<p>Report id - {Id}</p>");
        stringBuilder.AppendLine($"<p>Report type - {type}</p>");
        stringBuilder.AppendLine($"<p>Date - {CreationDate}</p>");
        return stringBuilder.ToString();
    }
    protected string FormTableHeader()
    {
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine("<tr>");
        stringBuilder.AppendLine("<th>Id</th>");
        stringBuilder.AppendLine("<th>Name</th>");
        stringBuilder.AppendLine("<th>Price</th>");
        stringBuilder.AppendLine("<th>Expiration date</th>");
        stringBuilder.AppendLine("<th>Date of entry</th>");
        stringBuilder.AppendLine("<th>Weight</th>");
        stringBuilder.AppendLine("<th>Unit</th>");
        stringBuilder.AppendLine("<tr>");
        return stringBuilder.ToString();
    }
    protected string FormProductTables(List<Product> products)
    {
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine("<h3>Products: </h3>");
        stringBuilder.AppendLine("<table>");
        stringBuilder.AppendLine(FormTableHeader());
        products.ForEach(product => stringBuilder.AppendLine(FormProductLine(product)));
        stringBuilder.AppendLine("</table>");
        return stringBuilder.ToString();
    }
    protected string FormProductLine(Product product)
    {
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine("<tr>");
        stringBuilder.AppendLine($"<td>{product.Id}</td>");
        stringBuilder.AppendLine($"<td>{product.Name}</td>");
        stringBuilder.AppendLine($"<td>{product.Price}</td>");
        stringBuilder.AppendLine($"<td>{product.ExpirationDate}</td>");
        stringBuilder.AppendLine($"<td>{product.DateOfEntry}</td>");
        stringBuilder.AppendLine($"<td>{product.Weight}</td>");
        stringBuilder.AppendLine($"<td>{product.Unit}</td>");
        stringBuilder.AppendLine("</tr>");
        return stringBuilder.ToString();
    }
}
