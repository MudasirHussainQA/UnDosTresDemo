using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalmartDemo.Configuration;
using WalmartDemo.Pages;
using TestContext = NUnit.Framework.TestContext;

namespace WalmartDemo.Tests
{
    [SetUpFixture]
    public  class FixtureInitializer
    {

        //public FixtureInitializer()
        //{
        
        //}
        //public bool PageTitle => Driver.Instance.Title.Contains("My Account – Demo Shopping site");

        internal   RechargePage AppPage { get; set; }

        //public  bool PageTitle => Driver.Instance.Title.Contains("My Account – Demo Shopping site");


        [OneTimeSetUp]
        public void SetupforEveryTestMethod()
        {

            Driver.InitPrimary();
            Driver.Instance.Manage().Window.Maximize();
            AppPage = new RechargePage().SignInApplication();
            //new LoginPage().SignInApplication();
        }




        public  IWebDriver GetChromeDriver()
        {

            var outputDirectory = Path.GetDirectoryName(@"C:\Projects");

            return new ChromeDriver(@"C:\Projects");
        }

        private  IWebDriver GetFirefoxDriver()
        {

            var outputDirectory = Path.GetDirectoryName(@"C:\Projects1");

            return new FirefoxDriver(@"C:\Projects1");
        }

        public static void InitWebdriver(TestContext tc)
        {

            BasePage.Config = new AppConfigReader();

            var firefox = new BaseTestSetup();
            var chrome = new BaseTestSetup();

            switch (BasePage.Config.GetBrowser())
            {
                case BrowserType.Firefox:
                    Driver.Instance = firefox.GetFirefoxDriver();
                    break;

                case BrowserType.Chrome:
                  Driver.Instance = chrome.GetChromeDriver();
                    break;


                default:
                    throw new NoSuitableDriverFound("Driver Not Found : " + BasePage.Config.GetBrowser().ToString());
            }
        }


        [OneTimeTearDown]
        //[OneTimeTearDown]
        public void CleanupAfterTest()
        {

            Driver.Instance.Close();
            Driver.Instance.Quit();
        }
    }
}
