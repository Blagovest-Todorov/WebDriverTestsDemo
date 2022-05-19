using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

// Create new Chrome browser instance
var driver = new ChromeDriver();

// Navigate to wikipedia
driver.Url = "https://wikipedia.org";

Console.WriteLine("CURRENT TITLE: " + driver.Title);

// locate search field by Id
IWebElement searchField = driver.FindElement(By.Id("searchInput"));

// click on element
searchField.Click();

//write QA and press enter btn
searchField.SendKeys("Quality Assurance" + Keys.Enter);

Console.WriteLine("Title after search: " + driver.Title);


// close the browser
//driver.Quit();

