using System.Text.RegularExpressions;
using Allure.Commons;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Test.Hooks
{
    [Binding]
    public class PluginsHooks
    {
        private readonly ScenarioContext _context;

        public PluginsHooks(ScenarioContext context)
        {
            this._context = context;
        }

        [AfterScenario(Order = -1)]
        public void UpdateAllureTestCaseName()
        {
            _context.TryGetValue(out TestResult testResult);
            AllureLifecycle.Instance.UpdateTestCase(testResult.uuid, testCase =>
            {
                testCase.name += GetScenarioNameSuffix();
                testCase.historyId = TestContext.CurrentContext.Test.FullName;
            });
        }

        private string GetScenarioNameSuffix()
        {
            var suffix = string.Empty;
            var testFullName = TestContext.CurrentContext.Test.FullName;
            var paramsMatch = Regex.Match(testFullName, @"(.*)(\(.*\))$");
            if (paramsMatch.Success)
            {
                suffix = $" {paramsMatch.Groups[2].Value.Replace(",null", string.Empty)}";
            }
            return suffix;
        }
    }
}
