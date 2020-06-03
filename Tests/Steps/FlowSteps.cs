using API.Sender;
using TechTalk.SpecFlow;

namespace Tests.Steps
{
    [Binding]
    class FlowSteps
    {
        protected static Sender Send = new Sender();

        [Given("I create user in store")]
        public void CreateUser()
        {

        }
    }
}