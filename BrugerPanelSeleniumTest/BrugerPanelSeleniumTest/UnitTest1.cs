using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Edge;
using System.Linq;
using SeleniumExtras.WaitHelpers;

namespace BrugerPanelSeleniumTest
{
    [TestClass]
    public class UnitTest1
    {
        //ændre hvor driveren er placeret på din egen pc
        private static readonly string DriverDirectory = "C:\\WebDrivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            // brug den browser du vil teste
            _driver = new ChromeDriver(DriverDirectory);
            //_driver = new EdgeDriver(DriverDirectory);
            //_driver = new FirefoxDriver(DriverDirectory);
        }

        public static void TearDown()
        {
            _driver.Dispose();
        }

        
        [TestMethod]
        public void TestViewStatestart()
        {
            //denne her virker.

            //husk at ændre URL til din egen localhost eller hjemmesiden.
            _driver.Navigate().GoToUrl("http://127.0.0.1:5501/index.html");

            // Find a button and click it to change the viewstate
            IWebElement button = _driver.FindElement(By.Id("startKnap"));
            button.Click();

            // Wait for the page to load
            Thread.Sleep(5000);

            // Check if an element is present in the new viewstate
            //IWebElement elementInNewViewState = _driver.FindElement(By.Id("startKnap"));
            Assert.ThrowsException<NoSuchElementException>(() => _driver.FindElement(By.Id("startKnap")));
            //Assert.IsNull(elementInNewViewState);

           
        }
        
        [TestMethod]
        public void TestViewStateLanguageDanish()
        {

            //denne her virker 

            //husk at ændre URL til din egen localhost eller hjemmesiden.
            _driver.Navigate().GoToUrl("http://127.0.0.1:5501/index.html");

            IWebElement button = _driver.FindElement(By.Id("startKnap"));
            button.Click();
            
            Thread.Sleep(2000);

            IWebElement buttonSelectLanguage = _driver.FindElement(By.Id("SelectLanguage"));
            buttonSelectLanguage.Click();

            // Wait for the page to load
            Thread.Sleep(2000);


            // Check if an element is present in the new viewstate
            Assert.ThrowsException<NoSuchElementException>(() => _driver.FindElement(By.Id("SelectLanguage")));
        }


        [TestMethod]
        public void TestViewStateLanguageAll()
        {

            //husk at ændre URL til din egen localhost eller hjemmesiden.
            _driver.Navigate().GoToUrl("http://127.0.0.1:5501/index.html");

        // Click on the start button
        IWebElement button = _driver.FindElement(By.Id("startKnap"));
        button.Click();

        // Wait for the language selection to appear
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("language-selection")));


        // Find all language selection buttons
        var languageButtons = _driver.FindElements(By.ClassName("flag-button")).ToList();

        // Check if there are any language buttons
        Assert.IsTrue(languageButtons.Count > 0, "No language buttons found.");

        // Click on the desired language button, for example the first one
        // Adjust the index based on the desired language
        // 0 - Dansk, 1 - Engelsk, 2 - Fransk
        languageButtons[2].Click();


        // Wait for the question view to appear
        wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("question-container")));

        // Perform assertions or further interactions as needed
        // For example, checking if the language has been changed by looking for a specific element
        Assert.IsTrue(_driver.FindElement(By.ClassName("question-title")).Displayed, "Question view did not appear.");
        
        }





    }
}