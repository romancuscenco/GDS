using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDS.Models;
using GDS.Services.Interfaces;
using GDS.Repositories.Interfaces;
using GDS.Models.Enums;
using GDS.Models.Exceptions;

namespace GDS.Services
{
    public class TransportService : ITransportService
    {
        private ITransportRepository transportRepository;

        //ctor
        public TransportService(ITransportRepository _transportRepository)
        {
            transportRepository = _transportRepository;
        }

        #region Public methods...
        public IQueryable<TransportModel> FindAllTransports()
        {
            return transportRepository.FindAll();
        }

        public IQueryable<TransportModel> FindAllTransportsExcept(TransportState state)
        {
            return transportRepository.FindAllExcept(state);
        }

        public TransportModel FindTransportBy(Guid id)
        {
            return transportRepository.FindBy(id);
        }

        public IQueryable<TransportModel> FindTransportBy(TransportState state)
        {
            return transportRepository.FindBy(state);
        }

        public void AddTransport(TransportModel transport)
        {
            transportRepository.Add(transport);
        }

        public void SaveTransport(TransportModel transport)
        {
            if (Validate(transport))
            {
                transportRepository.Save(transport);
            }

            throw new UnvalidatedTransportException();
        }        
        #endregion

        #region Private methods...
        private bool Validate(TransportModel transport)
        {
            if (transport.State == TransportState.RETIRED)
            {
                TransportModel originalTransport = FindTransportBy(transport.ID);

                if (originalTransport != null && originalTransport.State == TransportState.WORK)
                    throw new RetireWorkingTransportException();
            }

            return true;
        }
        #endregion
    }
}
