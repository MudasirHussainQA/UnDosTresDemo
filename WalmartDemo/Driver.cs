using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WalmartDemo.Tests;

namespace WalmartDemo
{
    public static class Driver 
    {
        public static IWebDriver _instance;
        public static IWebDriver _secondaryinstance;

        public static IWebDriver driver1 { get; set; }


        public static IWebDriver Instance
        {
            get
            {
                return _instance;
            }

            set
            {
                if (_instance != null) return;
                InitPrimary();
            }
        }

        //public static bool PageTitle => Instance.Title.Contains("My Account – Demo Shopping site");

        private static WebDriverWait PrimaryWait { get; set; }

        private static WebDriverWait SecondaryWait { get; set; }

        public static IDictionary<string, string> OpenTabHandles => new Dictionary<string, string>();

        



        public static void InitPrimary()
        {
            var outputDirectory = Path.GetDirectoryName(@"C:\Projects");

            _instance = new ChromeDriver(@"C:\Projects");
        }



        public static string SiteUrl()
        {
            return "https://shop.demoqa.com/";
        }

        public static void AcceptBrowserAlert()
        {
            try
            {
                IAlert alert = _instance.SwitchTo().Alert();
                alert.Accept();
            }
            catch
            {
                //If Page Leave alert box is not shown the exception is caught
            }
        }

        public static void MaximizeP()
        {
            _instance.Manage().Window.Maximize();
        }

        public static void SwitchToFrameP(By iframeSelector)
        {
            _instance.SwitchTo().Frame(_instance.FindElement(iframeSelector));
        }

        public static void SwitchToFrameS(By iframeSelector)
        {
            Driver._secondaryinstance.SwitchTo().Frame(_secondaryinstance.FindElement(iframeSelector));
        }

        public static void SwitchToMainContentP()
        {
            _instance.SwitchTo().DefaultContent();
        }

        public static void SwitchToMainContentS()
        {
            _secondaryinstance.SwitchTo().DefaultContent();
        }

        public static void MaximizeS()
        {
            _secondaryinstance.Manage().Window.Maximize();
        }

        public static IWebElement VisibleElementP(By by, int seconds = 60)
        {
            try
            {
                var wait = new WebDriverWait(
                    _instance, TimeSpan.FromSeconds(seconds));
                var element = wait.Until(ExpectedConditions.ElementToBeClickable(@by));
                return element;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        public static IWebElement VisibleElementS(IWebElement element, int seconds = 10)
        {

            try
            {
                var wait = new WebDriverWait(
                    _secondaryinstance, TimeSpan.FromSeconds(seconds));
                wait.Until(fun => element.Displayed);
                return element;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        //[TestCleanup]
        ////[OneTimeTearDown]

        //public static void CleanupAfterTest()
        //{
        //    Instance.Close();
        //    Instance.Quit();
        //    //driver.Close();
        //    //driver.Quit();
        //}

    }
}
