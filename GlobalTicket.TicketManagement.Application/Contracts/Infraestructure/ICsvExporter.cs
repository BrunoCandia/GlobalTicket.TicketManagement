﻿using GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;

namespace GlobalTicket.TicketManagement.Application.Contracts.Infraestructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);   
    }
}
