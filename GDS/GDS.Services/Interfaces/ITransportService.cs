using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDS.Models;
using GDS.Models.Enums;

namespace GDS.Services.Interfaces
{
    public interface ITransportService
    {
        IQueryable<TransportModel> FindAllTransports();

        IQueryable<TransportModel> FindAllTransportsExcept(TransportState state);

        TransportModel FindTransportBy(Guid id);

        IQueryable<TransportModel> FindTransportBy(TransportState state);

        void AddTransport(TransportModel transport);

        void SaveTransport(TransportModel transport);
    }
}
