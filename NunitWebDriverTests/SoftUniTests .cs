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
            // create new object of type ChtomeOptios
            var options = new ChromeOptions();
            //options.AddArgument("--headless");

            this.driver = new ChromeDriver(options);

            driver.Url = "https://softuni.bg";
            driver.Manage().Window.Maximize();
        }     

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

            //var forUsElement = driver.FindElement(By.LinkText("За нас"));
            //forUsElement.Click();

            string expectedTitle = "За нас - Софтуерен университет";
            // Assert.AreEqual(expectedTitle, driver.Title);
            //Assert
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));            

        }

        [Test]
        public void Test_Login_InvalidUsernameAndPassword()
        {
           //driver.Navigate().GoToUrl("https://softuni.bg/");
           //driver.Manage().Window.Size = new System.Drawing.Size(1050, 840);
            driver.FindElement(By.CssSelector(".softuni-btn-primary")).Click();

            //Locate usernameField
           // IWebElement usernameField = driver.FindElement(By.Id("username"));

            //Locate Element By TagName
            //IWebElement usernameField_ByName = driver.FindElement(By.Name("username"));
            IWebElement usernameField_ByCssSelector = driver.FindElement(By.CssSelector("#username"));
            //usernameField.Click();
            usernameField_ByCssSelector.Click();


            usernameField_ByCssSelector.SendKeys("a");
            driver.FindElement(By.Id("password-input")).Click();

            driver.FindElement(By.Id("password-input")).SendKeys("kaka");
            driver.FindElement(By.CssSelector(".softuni-btn")).Click();
            driver.FindElement(By.CssSelector(".field-validation-error")).Click();
            Assert.That(driver.FindElement(By.Id("username-error")).Text, Is.EqualTo("Невалиден формат на потребителското име."));
                      
        }

        [Test]
        public void Test_SearchField_PostitiveResults() 
        {
            driver.Url = "https://softuni.bg";
            driver.Manage().Window.Maximize();
              
            driver.FindElement(By.CssSelector(".header-search-dropdown-link  .fa-search")).Click();


           var searchBox = driver.FindElement(By.CssSelector(".containner > form #search-input"));
            searchBox.Click();
            searchBox.SendKeys("QA");

            
            //We take fromt he given field the containing text witht he .Text
            var resultField = driver.FindElement(By.CssSelector(".search-title")).Text;
            var expectedValue = "Резултати от търсене на “QA”";

            Assert.That(resultField, Is.EqualTo(expectedValue));
        
        }


        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
    }
}