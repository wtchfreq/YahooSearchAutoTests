using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;

namespace WebPages
{
    public class Yahoo
    {

        private IWebDriver driver;
        private const string url = "https://www.yahoo.com/";

        public Yahoo(IWebDriver driver)
        {
            this.driver = driver;
            driver.Url = url;
        }

        private IWebElement SearchBox
        {
            get
            {
                return driver.FindElement(By.Id("uh-search-box"));
            }
        }

        private IWebElement SearchButton
        {
            get
            {
                return driver.FindElement(By.Id("uh-search-button"));
            }
        }

        private IWebElement Logo
        {
            get
            {
                return driver.FindElement(By.Id("uh-logo"));
            }
        }

        public void InputSearchText(string text)
        {
            SearchBox.SendKeys(text);
        }

        public void ClearSearchField()
        {
            SearchBox.Clear();
        }

        // Launches search of the current content of the search text field.
        // Results are returned encapsulated into SearchResults object.
        public SearchResults Search()
        {
            SearchButton.Click();
            return new SearchResults(driver);
        }


    }
}
