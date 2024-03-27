using lab_1.Models;

namespace lab_1.Interfaces;

public interface IReport
{
    public Guid Id { get; set; }
    public DateTime CreationDate { get; set; }
    public List<Product>? ProductsInfo { get; set; }
    public Warehouse? Warehouse { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ReportType ReportType { get; set; }
    public string Extension { get; }
    public string FormIncomeReport();
    public string FormOutcomeReport();
    public string FormInventReport();
}
