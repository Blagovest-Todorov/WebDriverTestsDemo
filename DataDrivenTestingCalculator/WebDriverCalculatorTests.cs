using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace DataDrivenTestingCalculator
{
    public class WebDriverCalculatorTests
    {
        //private ChromeDriver driver;

        private FirefoxDriver driver;

        IWebElement field1;
        IWebElement field2;
        IWebElement operation;
        IWebElement calculateButton;
        IWebElement resultField;
        IWebElement resetBtn;


        [OneTimeSetUp]
        public void Setup_OpenAndNavigate()
        {
            //this.driver = new ChromeDriver();
            this.driver = new FirefoxDriver();

            driver.Url = "https://number-calculator.nakov.repl.co/";
            driver.Manage().Window.Maximize();

            field1 = driver.FindElement(By.Id("number1"));
            field2 = driver.FindElement(By.Id("number2"));
            operation = driver.FindElement(By.Id("operation"));
            calculateButton = driver.FindElement(By.Id("calcButton"));
            resultField = driver.FindElement(By.Id("result"));
            resetBtn = driver.FindElement(By.Id("resetButton"));
        }

        [TestCase("5",  "6", "+", "Result: 11")]
        [TestCase("15", "6", "-", "Result: 9")]
        [TestCase("155", "5", "-", "Result: 150")]
        [TestCase("5", "5", "*", "Result: 25")]
        [TestCase("5", "5", "/", "Result: 1")]
        [TestCase("5ala", "alala5", "-", "invalid input")]
        public void TestCalculator(
            string num1, string num2, string operatorAction, string expectedResult)
        {
            
            //Act
            field1.SendKeys(num1);
            operation.SendKeys(operatorAction);
            field2.SendKeys(num2);
            calculateButton.Click();
            
            Assert.That(resultField.Text, Is.EqualTo(expectedResult));

            resetBtn.Click(); // after every operation clear reset teh fileds
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            Thread.Sleep(10000); // wait 10 secs before closing 
            driver.Quit();
        }
    }
}