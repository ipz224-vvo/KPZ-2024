namespace lab_1.Interfaces;

public interface IReportingService
{
    public string reportsPath { get; set; }
    public void CreateReport(IReport report);
    public void DeleteReport(IReport report);
}
