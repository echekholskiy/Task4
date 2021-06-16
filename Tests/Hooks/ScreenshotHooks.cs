using Allure.Commons;
using Aquality.Selenium.Browsers;
using NUnit.Framework;
using Task4.Utils;
using TechTalk.SpecFlow;

namespace Test.Hooks
{
    [Binding]
    public class ScreenshotHooks
    {
        private readonly ScreenshotProvider _screenshotProvider;

        public ScreenshotHooks(ScreenshotProvider screenshotProvider)
        {
            this._screenshotProvider = screenshotProvider;
        }

        [AfterScenario(Order = 0)]
        public void TakeScreenshot()
        {
            if (AqualityServices.IsBrowserStarted)
            {
                var pathToScreenshot = _screenshotProvider.TakeScreenshot();
                TestContext.AddTestAttachment(pathToScreenshot);
                AllureLifecycle.Instance.AddAttachment(pathToScreenshot, "Screenshot");
            }
        }
    }
}
