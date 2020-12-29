using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace SeleniumTest
{
    [TestClass]
    public class StudentUITest
    {
        private string _webSiteURL= "http://localhost:50237/"; /* /Student/Create */
        private RemoteWebDriver _browserDriver;
        private TestContext TestContext { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            _webSiteURL = (string)TestContext.Properties["WebAppURL"];
        }

        [TestMethod]
        [TestCategory("Selenium")]
        [DataRow("Marina", "Tucakovic", "Antifasisticke borbe 5", "Beograd")]
        [DataRow("Milos", "Strugalovic", "Francuska 9", "Beograd")]
        public void CreateStudent(string ime, string prezime, string adresa, string grad)
        {
            //arrange
            _browserDriver = new ChromeDriver();
            _browserDriver.Manage().Window.Maximize();
            _browserDriver.Navigate().GoToUrl(_webSiteURL + "/Student/Create");
            _browserDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(3);

            _browserDriver.FindElementByName("Ime").SendKeys(ime);
            _browserDriver.FindElementByName("Prezime").SendKeys(prezime);
            _browserDriver.FindElementByName("Adresa").SendKeys(adresa);
            _browserDriver.FindElementByName("Grad").SendKeys(grad);

            //create screenshot
            var screenshot = _browserDriver.GetScreenshot();
            var fileName = $"{ime}.jpg";
            screenshot.SaveAsFile(fileName);
            TestContext.AddResultFile(fileName);

            //act
            _browserDriver.FindElement(By.CssSelector("button button1")).Click();
            _browserDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

            //assert
            Assert.IsTrue(_browserDriver.PageSource.Contains(ime));
            Assert.IsTrue(_browserDriver.PageSource.Contains(prezime));
            Assert.IsTrue(_browserDriver.PageSource.Contains(adresa));
            Assert.IsTrue(_browserDriver.PageSource.Contains(grad));

        }
    }
}
