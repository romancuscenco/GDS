using System;
using TechTalk.SpecFlow;

namespace GDS.Specs
{
    [Binding]
    public class OrderingAnswersSteps
    {
        [Given(@"There is a question ""(.*)"" with the answers")]
        public void GivenThereIsAQuestionWithTheAnswers(string p0, Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"you upvote answer ""(.*)""")]
        public void WhenYouUpvoteAnswer(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the answer ""(.*)"" should be on top")]
        public void ThenTheAnswerShouldBeOnTop(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
