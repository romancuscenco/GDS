using System;
using TechTalk.SpecFlow;

namespace GDS.Specs.TransportManager.Steps
{
    [Binding]
    public class ManageTransportUnitsSteps
    {
        [Given(@"I have the following transports in the system")]
        public void GivenIHaveTheFollowingTransportsInTheSystem(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I request the list of ""(.*)"" Transports")]
        public void WhenIRequestTheListOfTransports(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I send the request of adding the following transport")]
        public void WhenISendTheRequestOfAddingTheFollowingTransport(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I send the request of retiring the following transport")]
        public void WhenISendTheRequestOfRetiringTheFollowingTransport(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I send the request of editing the following transport's serial number from ""(.*)"" to ""(.*)""")]
        public void WhenISendTheRequestOfEditingTheFollowingTransportSSerialNumberFromTo(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should see the following list")]
        public void ThenIShouldSeeTheFollowingList(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should have the following active transports in the system")]
        public void ThenIShouldHaveTheFollowingActiveTransportsInTheSystem(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should have the following retired transports in the system")]
        public void ThenIShouldHaveTheFollowingRetiredTransportsInTheSystem(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should have the following transports in the system")]
        public void ThenIShouldHaveTheFollowingTransportsInTheSystem(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
