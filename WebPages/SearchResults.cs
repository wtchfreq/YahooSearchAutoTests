using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebPages
{
    public class SearchResults
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public SearchResults(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Checks if specific result URL is present on results page.  
        public bool IsResultPresent(string linkURL)
        {
            try
            {
                var result = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//a[@href='{linkURL}']")));
                if (result != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        // Click on the first search result in the list.
        public void ClickOnFirstSearchResult()
        {
            IWebElement link = driver.FindElement(By.XPath("(//div[@id='web']//a[@href])[1]"));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//div[@id='web']//a[@href])[1]")));
            link.Click();
        }
    }
}