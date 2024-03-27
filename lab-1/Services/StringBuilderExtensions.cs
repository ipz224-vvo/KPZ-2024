using lab_1.Models;
using System.Text;

namespace lab_1.Services;

static class StringBuilderExtensions
{
    public static StringBuilder AddWarehouseTextInfo(this StringBuilder stringBuilder, Warehouse warehouse)
    {
        stringBuilder.AppendLine("Products: ");
        stringBuilder.AppendLine($"Warehouse id - {warehouse.Id}");
        stringBuilder.AppendLine($"Warehouse title - {warehouse.Title}");
        stringBuilder.AppendLine($"Warehouse address - {warehouse.Address}");
        stringBuilder.AppendLine($"Warehouse maximum capacity - {warehouse.MaxCapacity}");
        return stringBuilder;
    }
    public static StringBuilder AddWarehouseHtmlInfo(this StringBuilder stringBuilder, Warehouse warehouse)
    {
        stringBuilder.AppendLine("<h3>Warehouse: </h3>");
        stringBuilder.AppendLine($"<p>Warehouse title - {warehouse.Title}</p>");
        stringBuilder.AppendLine($"<p>Warehouse id - {warehouse.Id}</p>");
        stringBuilder.AppendLine($"<p>Warehouse address - {warehouse.Address}</p>");
        stringBuilder.AppendLine($"<p>Warehouse maximum capacity - {warehouse.MaxCapacity}</p>");
        return stringBuilder;
    }
}
