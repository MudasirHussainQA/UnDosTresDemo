using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalmartDemo.Pages;

namespace WalmartDemo
{
    public class GenericHelper : BasePage
    {
        public GenericHelper()
        {

        }
        public static bool IsElemetPresent(By Locator)
        {
            try
            {
                return Driver.Instance.FindElements(Locator).Count == 1;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static IWebElement GetElement(By Locator)
        {
            if (IsElemetPresent(Locator))
                return Driver.Instance.FindElement(Locator);
            else
                throw new NoSuchElementException("Element Not Found : " + Locator.ToString());
        }

        

        public static bool WaitForWebElement(By locator, TimeSpan timeout)
        {
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            //Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(Driver.Instance, timeout);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            bool flag = wait.Until(WaitForWebElementFunc(locator));
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(BasePage.Config.GetElementLoadTimeOut());
            //Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(BasePage.Config.GetElementLoadTimeOut()));
            return flag;
        }

        public static IWebElement WaitForWebElementInPage(By locator, TimeSpan timeout)
        {
            //Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            WebDriverWait wait = new WebDriverWait(Driver.Instance, timeout);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            IWebElement flag = wait.Until(WaitForWebElementInPageFunc(locator));
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(BasePage.Config.GetElementLoadTimeOut());
            //Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(BasePage.Config.GetElementLoadTimeOut()));
            return flag;
        }

        private static Func<IWebDriver, bool> WaitForWebElementFunc(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return true;
                return false;
            });
        }

        private static Func<IWebDriver, IWebElement> WaitForWebElementInPageFunc(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return x.FindElement(locator);
                return null;
            });
        }

    }
}
