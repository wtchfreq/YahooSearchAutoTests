using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;

namespace WebPages
{
    public class Yahoo
    {

        // add references and chrome browser
        // add search box element

        // input id = "uh-search-box"

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
                return driver.FindElement(By.XPath(".//*[@id='uh-search-box']"));
            }
        }

        private IWebElement SearchButton
        {
            get
            {
                return driver.FindElement(By.XPath(".//*[@id='uh-search-button']"));
            }
        }

        public void SearchText(string text)
        {
            SearchBox.SendKeys(text);
            SearchButton.Click();
        }


    }
}
