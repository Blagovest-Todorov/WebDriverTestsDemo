using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NunitWebDriverTests
{
    public class SoftUniTests
    {
        private WebDriver driver;

        [OneTimeSetUp]
        public void OpenBrowserAndNavigate()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://softuni.bg";
            driver.Manage().Window.Maximize();
        }

        //[OneTimeTearDown]
        //public void ShutDown() 
        //{
        //    driver.Quit();
        //}        

        [Test]
        public void Test_AssertMainPageTitle()
        {
            driver.Url = "https://softuni.bg";
            string expectedTitle = "Обучение по програмиране - Софтуерен университет";
           // Assert.AreEqual(expectedTitle, driver.Title);
           //Assert
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));  
        }

        [Test]
        public void Test_AssertAboutUsTitle()
        {          
            var forUsElement = driver.FindElement(By.CssSelector(
                "#header-nav > div.toggle-nav.toggle-holder > ul > li:nth-child(1) > a > span"));
            forUsElement.Click();

            string expectedTitle = "За нас - Софтуерен университет";
            // Assert.AreEqual(expectedTitle, driver.Title);
            //Assert
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));            

        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
    }
}