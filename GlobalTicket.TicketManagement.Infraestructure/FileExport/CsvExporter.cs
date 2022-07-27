using CsvHelper;
using GlobalTicket.TicketManagement.Application.Contracts.Infraestructure;
using GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using System.Globalization;

namespace GlobalTicket.TicketManagement.Infrastructure
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                csvWriter.WriteRecords(eventExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
