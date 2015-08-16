using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDS.Models;
using GDS.Models.Enums;

namespace GDS.Repositories.Interfaces
{
    public interface ITransportRepository
    {
        IQueryable<TransportModel> FindAll();

        IQueryable<TransportModel> FindAllExcept(TransportState state);

        TransportModel FindBy(Guid id);

        IQueryable<TransportModel> FindBy(TransportState state);

        void Add(TransportModel transport);

        void Save(TransportModel transport);
    }
}
