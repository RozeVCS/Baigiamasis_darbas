﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages
{
    public class Common
    {
        internal static IWebElement GetElement(string locator)
        {
            return Driver.GetDriver().FindElement(By.XPath(locator));
        }

        internal static void ClickElement(string locator)
        {
            GetElement(locator).Click();
        }

        internal static void SendKeysToElement(string locator, string keys)
        {
            GetElement(locator).SendKeys(keys);
        }
        internal static string GetElementText(string locator)
        {
            return GetElement(locator).Text;

            namespace Framework.Pages
    {
        internal class ShoppingCartPage
        { 
           
             return new ShoppingCartPage();
        }
    }
}

    
