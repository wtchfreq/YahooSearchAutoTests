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

        [Test]
        public void Test1()
        {
            webpage.SearchText("test");
            System.Threading.Thread.Sleep(5000);
            Assert.Pass();
        }

        [TearDown]
        public void TearDownTest()
        {
            driver.Quit();
        }
    }
}