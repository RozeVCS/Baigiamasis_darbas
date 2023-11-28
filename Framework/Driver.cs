using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class Driver
    {
        internal static IWebDriver driver;

        public static void InitializeDriver()
        {
            driver = new ChromeDriver();
        }

        internal static IWebDriver GetDriver()
        {
            return driver;
        }

        public class HomePage
        {
            private readonly IWebDriver driver;

            public HomePage(IWebDriver driver)
            {
                this.driver = driver;
            }

            public static void OpenPage(string url)
        {
                driver.Navigate().GoToUrl(url);
        }

        public static void QuitDriver()
        {
                driver.Quit();
        }
    }
    

