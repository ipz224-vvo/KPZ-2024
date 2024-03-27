using lab_1.Interfaces;
using lab_1.Models;

namespace lab_1.Services;

public class ReportingService : IReportingService
{
    public string reportsPath { get; set; }
    protected ILogger _logger { get; set; }
    public ReportingService(ILogger logger)
    {
        _logger = logger;
        reportsPath = Directory.GetCurrentDirectory() + "/reports";
    }

    public void CreateReport(IReport report)
    {
        if (!Directory.Exists(reportsPath))
        {
            Directory.CreateDirectory(reportsPath);
        }

        string formedReport;
        switch (report.ReportType)
        {
            case ReportType.Income: formedReport = report.FormIncomeReport(); break;
            case ReportType.Outcome: formedReport = report.FormOutcomeReport(); break;
            case ReportType.Invent: formedReport = report.FormInventReport(); break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        var newReportName = report.Title + "_" + report.Id;
        var newReportPath = Path.Combine(reportsPath, newReportName) + report.Extension;
        if (!File.Exists(newReportPath))
        {
            //File.Create(newReportPath);
            File.WriteAllLines(newReportPath, [formedReport]);
            _logger.Info("Report successfully created.");
            return;
        }
        _logger.Error("Path is not valid");
    }

    public void DeleteReport(IReport report)
    {
        var reportName = report.Title + "_" + report.Id;
        var reportPath = Path.Combine(reportsPath, reportName) + report.Extension;

        if (File.Exists(reportPath))
        {
            File.Delete(reportPath);
            _logger.Info("Report successfully deleted.");
            return;
        }
        _logger.Error("Report not found");
    }
}
