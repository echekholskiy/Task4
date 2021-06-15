using Allure.Commons;
using Aquality.Selenium.Browsers;
using AqualityTracking.Integrations.Core;
using NUnit.Framework;
using Task4.Utils;
using TechTalk.SpecFlow;

namespace Test.Hooks
{
    [Binding]
    public class ScreenshotHooks
    {
        private readonly ScreenshotProvider screenshotProvider;
        private readonly ScenarioContext scenarioContext;

        public ScreenshotHooks(ScenarioContext scenarioContext, ScreenshotProvider screenshotProvider)
        {
            this.scenarioContext = scenarioContext;
            this.screenshotProvider = screenshotProvider;
        }

        [AfterScenario(Order = 0)]
        public void TakeScreenshot()
        {
            if (AqualityServices.IsBrowserStarted)
            {
                var pathToScreenshot = screenshotProvider.TakeScreenshot();
                TestContext.AddTestAttachment(pathToScreenshot);
                AllureLifecycle.Instance.AddAttachment(pathToScreenshot, "Screenshot");
                AqualityTrackingLifecycle.Instance.AddAttachment(pathToScreenshot);
            }
        }
    }
}
