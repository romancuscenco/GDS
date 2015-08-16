using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Moq;
using GDS.Repositories.Interfaces;
using GDS.Models;
using GDS.Models.Enums;
using GDS.Services.Interfaces;
using GDS.Services;

namespace GDS.Specs.Steps
{
    [Binding]
    public class ManageTransportUnitsSteps
    {
        private List<TransportModel> transports;
        Mock<ITransportRepository> mockTransportRepository;
        ITransportService transportService;

        private const string ACTIVE_TRANSPORTS = "ACTIVE_TRANSPORTS";
        private const string TRANSPORT_ID = "TRANSPORT_ID";
        private Guid SavedTransportId = new Guid("11111111-1111-1111-1111-111111111111");

        #region Public methods...

        #region GIVEN...
        [Given(@"I have the following transports in the system")]
        public void GivenIHaveTheFollowingTransportsInTheSystem(Table table)
        {            
            transports = new List<TransportModel>();
            transports.AddRange(FillTransportModel(table));

            //Arrange
            mockTransportRepository = new Mock<ITransportRepository>();
            transportService = new TransportService(mockTransportRepository.Object);

            mockTransportRepository.Setup(r => r.FindAllExcept(TransportState.RETIRED))
                                   .Returns(transports.AsQueryable().Where(t => t.State != TransportState.RETIRED).AsQueryable());

            mockTransportRepository.Setup(r => r.FindBy(It.IsAny<Guid>()))
                                   .Returns(transports.First(t => t.State != TransportState.RETIRED));

            mockTransportRepository.Setup(r => r.Save(It.IsAny<TransportModel>()))
                                   .Returns(SavedTransportId);

            Assert.IsNotEmpty(transports, "Transports are empty!");
        }
        #endregion

        #region WHEN...
        [When(@"I request the list of Transports that are not retired")]
        public void WhenIRequestTheListOfTransportsThatAreNotRetired()
        {
            //Act
            IQueryable<TransportModel> activeTransports = transportService.FindAllTransportsExcept(TransportState.RETIRED);

            ScenarioContext.Current.Add(ACTIVE_TRANSPORTS, activeTransports);
        }

        [When(@"I request the list of Retired Transports")]
        public void WhenIRequestTheListOfRetiredTransports()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I send the request of adding the following transport")]
        public void WhenISendTheRequestOfAddingTheFollowingTransport(Table table)
        {
            TransportModel transportToAdd = FillTransportModel(table).First();
            transportToAdd.State = TransportState.READY;

            //Add
            Guid transportId = transportService.SaveTransport(transportToAdd);
            transportToAdd.ID = transportId;            
            transports.Add(transportToAdd);

            ScenarioContext.Current.Add(TRANSPORT_ID, transportId);
        }
        
        [When(@"I send the request of retiring the following transport")]
        public void WhenISendTheRequestOfRetiringTheFollowingTransport(Table table)
        {
            TransportModel inputTransport = FillTransportModel(table).First();
            TransportModel transportToRetire = transports.Single(t => t.SerialNumber == inputTransport.SerialNumber);
            transportToRetire.State = TransportState.RETIRED;

            //Act
            Guid transportId = transportService.SaveTransport(transportToRetire);
            transportToRetire.ID = transportId;
            
            ScenarioContext.Current.Add(TRANSPORT_ID, transportId);
        }
        
        [When(@"I send the request of editing the following transport's serial number from ""(.*)"" to ""(.*)""")]
        public void WhenISendTheRequestOfEditingTheFollowingTransportSSerialNumberFromTo(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
                
        [When(@"I send the request of retiring a transport that is in Work state")]
        public void WhenISendTheRequestOfRetiringATransportThatIsInWorkState()
        {
            TransportModel workingTransportToRetire = transports.First(t => t.State != TransportState.RETIRED);
            workingTransportToRetire.State = TransportState.WORK;

            //Act
            Guid transportId = transportService.SaveTransport(transportToRetire);
            transportToRetire.ID = transportId;

            ScenarioContext.Current.Add(TRANSPORT_ID, transportId);
        }
        #endregion

        #region THEN...
        [Then(@"I should see the following active transports list")]
        public void ThenIShouldSeeTheFollowingActiveTransportsList(Table tblActiveTransports)
        {
            IQueryable<TransportModel> activeTransports = (IQueryable<TransportModel>)ScenarioContext.Current[ACTIVE_TRANSPORTS];

            List<TransportModel> expectedTransports = new List<TransportModel>();
            expectedTransports.AddRange(FillTransportModel(tblActiveTransports));

            //Assert
            mockTransportRepository.Verify(r => r.FindAllExcept(TransportState.RETIRED), Times.Once());
            Assert.IsTrue(activeTransports.All(t => t.State != TransportState.RETIRED), "There must not be a transport that is RETIRED!");
            Assert.AreEqual(expectedTransports.Select(t => t.SerialNumber), activeTransports.Select(t => t.SerialNumber));
        }

        [Then(@"I should see the following retired transports list")]
        public void ThenIShouldSeeTheFollowingRetiredTransportsList(Table table)
        {
            ScenarioContext.Current.Pending();
        }
                
        [Then(@"I should have the following active transports in the system")]
        public void ThenIShouldHaveTheFollowingActiveTransportsInTheSystem(Table tblActiveTransports)
        {
            Guid savedTransportId = (Guid)ScenarioContext.Current[TRANSPORT_ID];

            List<TransportModel> expectedTransports = FillTransportModel(tblActiveTransports);
            TransportModel savedTransport = transports.Single(t => t.ID == savedTransportId);

            //Assert
            mockTransportRepository.Verify(r => r.Save(It.IsAny<TransportModel>()), Times.Once());
            Assert.IsTrue(expectedTransports.Select(t => t.SerialNumber).Contains(savedTransport.SerialNumber));
            Assert.IsTrue(savedTransport.State != TransportState.RETIRED);
        }
        
        [Then(@"I should have the following retired transports in the system")]
        public void ThenIShouldHaveTheFollowingRetiredTransportsInTheSystem(Table tblRetiredTransports)
        {
            Guid savedTransportId = (Guid)ScenarioContext.Current[TRANSPORT_ID];

            List<TransportModel> expectedTransports = FillTransportModel(tblRetiredTransports);
            TransportModel savedTransport = transports.Single(t => t.ID == savedTransportId);

            //Assert
            mockTransportRepository.Verify(r => r.Save(It.IsAny<TransportModel>()), Times.Once());
            Assert.IsTrue(expectedTransports.Select(t => t.SerialNumber).Contains(savedTransport.SerialNumber));
            Assert.IsTrue(savedTransport.State == TransportState.RETIRED);
        }
        
        [Then(@"I should have the following transports in the system")]
        public void ThenIShouldHaveTheFollowingTransportsInTheSystem(Table table)
        {
            ScenarioContext.Current.Pending();
        }        
        
        [Then(@"The transport should remain Ready")]
        public void ThenTheTransportShouldRemainReady()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should get the message ""(.*)""")]
        public void ThenIShouldGetTheMessage(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        #endregion

        #endregion

        #region Private methods...
        private List<TransportModel> FillTransportModel(Table table)
        {
            List<TransportModel> result = new List<TransportModel>();
            foreach (var row in table.Rows)
            {
                result.Add(new TransportModel
                {
                    SerialNumber = row["SerialNumber"],
                    State = (TransportState)Enum.Parse(typeof(TransportState), row["Status"].ToUpper())
                });
            }

            return result;
        }        
        #endregion
    }
}

      