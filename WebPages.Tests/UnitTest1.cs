using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebPages;

namespace Tests
{

    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        private Yahoo webpage;

        [SetUp]
        public void Setup()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"F:\src\qa\qa_automation_lib", "chromedriver.exe");
            driver = new ChromeDriver(service);
            webpage = new Yahoo(driver);

        }

        [TestCase("test", "https://www.merriam-webster.com/dictionary/test")]
        public void SearchTest(string text, string resultURL)
        {
            // TODO: Change thread sleep to more adequate waiting
            webpage.InputSearchText(text);
            System.Threading.Thread.Sleep(5000);

            SearchResults results = webpage.Search();
            Assert.True(results.IsResultPresent(resultURL));
            System.Threading.Thread.Sleep(5000);
        }

        [Test]
        public void FirstSearchResultClickTest()
        {
            // TODO: Change thread sleep to more adequate waiting
            webpage.InputSearchText("something");
            SearchResults results = webpage.Search();
            System.Threading.Thread.Sleep(5000);
            
            results.ClickOnFirstSearchResult();
            System.Threading.Thread.Sleep(5000);
            // TODO: Add some kind of Assert

        }

        [TearDown]
        public void TearDownTest()
        {
            driver.Quit();
        }
    }
}