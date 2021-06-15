
using System.Collections.Generic;
using System.Linq;
using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Core.Logging;
using Aquality.Selenium.Elements;
using Aquality.Selenium.Elements.Interfaces;
using Newtonsoft.Json;
using OpenQA.Selenium;
using Task4.Pages;

namespace Task4.Extensions
{
    public static class ActionPageExtensions
    {
        public static string GetLowestDiscount(this ActionPage actionPage)
        {
            ITextBox v = null;
            var discounts = actionPage.GameWithDiscountTextBoxes;
            var listOfDiscountPct = discounts.Select(a => a.FindChildElement<ITextBox>(By.XPath("//*[@class='discount_pct']"))).ToList();
            var discountList = listOfDiscountPct.Select(a => a.Text);
            return discountList.Min();
        }
    }
}
