using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDS.Models;
using GDS.Models.Enums;
using GDS.Repositories.Interfaces;

namespace GDS.Repositories
{
    public class TransportRepository : ITransportRepository
    {
        //private DataContext
        private List<TransportModel> transportDB;
        
        //ctor
        public TransportRepository()
        {
            //init connection
            #region add transports...
            transportDB = new List<TransportModel>() 
            {
                new TransportModel()
                {
                    Name = "Warp Hauler",
                    SerialNumber = "P-348-A",
                    CargoCapacity = 1000.0,
                    State = TransportState.READY
                },
                new TransportModel()
                {
                    Name = "Star Lifter",
                    SerialNumber = "S-232-G",
                    CargoCapacity = 5000.0,
                    State = TransportState.READY
                },
                new TransportModel()
                {
                    Name = "Photon III",
                    SerialNumber = "T-282-D",
                    CargoCapacity = 2400.0,
                    State = TransportState.READY
                },
                new TransportModel()
                {
                    Name = "Warp Hauler",
                    SerialNumber = "V-517-U",
                    CargoCapacity = 1000.0,
                    State = TransportState.RETIRED
                },
                new TransportModel()
                {
                    Name = "Warp Hauler",
                    SerialNumber = "G-135-N",
                    CargoCapacity = 1000.0,
                    State = TransportState.RETIRED
                }
            };
            #endregion
        }

        #region Private methods...
        public IQueryable<TransportModel> FindAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TransportModel> FindAllExcept(TransportState state)
        {
            throw new NotImplementedException();
        }

        public TransportModel FindBy(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TransportModel> FindBy(TransportState state)
        {
            throw new NotImplementedException();
        }

        public void Add(TransportModel transport)
        {
            throw new NotImplementedException();
        }

        public void Save(TransportModel transport)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
