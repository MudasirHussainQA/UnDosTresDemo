using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TestContext = NUnit.Framework.TestContext;
using NUnit.Framework;
using System.IO;
using WalmartDemo.Configuration;
using WalmartDemo.Pages;

namespace WalmartDemo.Tests
{
    
    public class BaseTestSetup
    {
        public static IWebDriver driver { get; set; }

        internal RechargePage AppPage { get; set; }
        //internal TestUser TheTestUser { get; set; }

        //internal LogInPage AppPage { get; private set; }

        //internal LMSPage LMSPage { get; private set; }

        //internal Timesheet TimePage { get; set; }

        //public bool PageTitle => driver.Title.Contains("My Account – Demo Shopping site");

        //public bool PageTitle => Driver.Instance.Title.Contains("My Account – Demo Shopping site");



        //[OneTimeSetUp]
        public void SetupforEveryTestMethod()
        {

            Driver.InitPrimary();
            Driver.Instance.Manage().Window.Maximize();            
            AppPage = new RechargePage();
            





        }


        public IWebDriver GetChromeDriver()
        {

            var outputDirectory = Path.GetDirectoryName(@"C:\Projects");

            return new ChromeDriver(@"C:\Projects");
        }

       public IWebDriver GetFirefoxDriver()
        {

            var outputDirectory = Path.GetDirectoryName(@"C:\Projects1");

            return new FirefoxDriver(@"C:\Projects1");
        }

        //public static void InitWebdriver(TestContext tc)
        //{

        //    BasePage.Config = new AppConfigReader();

        //    var firefox = new BaseTestSetup();
        //    var chrome = new BaseTestSetup();

        //    switch (BasePage.Config.GetBrowser())
        //    {
        //        case BrowserType.Firefox:
        //            BasePage.Driver.Instance = firefox.GetFirefoxDriver();
        //            break;

        //        case BrowserType.Chrome:
        //            BasePage.Driver = chrome.GetChromeDriver();
        //            break;


        //        default:
        //            throw new NoSuitableDriverFound("Driver Not Found : " + BasePage.Config.GetBrowser().ToString());
        //    }
        //}


        
        //[OneTimeTearDown]

        public void CleanupAfterTest()
        {

            Driver.Instance.Close();
            Driver.Instance.Quit();
        }
    }
}
