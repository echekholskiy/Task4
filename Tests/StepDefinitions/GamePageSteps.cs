using FluentAssertions;
using Task4.Models;
using Task4.Pages;
using TechTalk.SpecFlow;

namespace Test.StepDefinitions
{
    [Binding]
    public class GamePageSteps
    {
        private readonly GamePage _gamePage;
        private readonly ScenarioContext _scenarioContext;

        public GamePageSteps(GamePage gamePage, ScenarioContext scenarioContext)
        {
            this._gamePage = gamePage;
            _scenarioContext = scenarioContext;
        }

        [When(@"Enter the correct age on the Rated content if it's shown")]
        public void WhenEnterCorrectAge(Birth birth)
        {
            _gamePage.PassAgeGate(birth.Day, birth.Month, birth.Year);
        }

        [When(@"I check discount of the game")]
        public void WhenCheckGameDiscount()
        {
            _scenarioContext.Add("InnerGame", _gamePage.GetGameModel());
        }

        [Then(@"Then discount rate, initial and discounted prices equals to corresponding values")]
        public void ThenDiscountIsEqual()
        {
            var expectedDiscount = _scenarioContext["InnerGame"];
            var actualDiscount = _scenarioContext["Game"];
            actualDiscount.Should().BeEquivalentTo(expectedDiscount, "Discount and prices are equal");
        }

        [Then(@"Game page is opened")]
        public void ThenGamePageOpened()
        {
            _gamePage.PageIsOpened(_scenarioContext["GameName"].ToString()).Should()
                .BeTrue("Game page is opened");
        }
    }
}
