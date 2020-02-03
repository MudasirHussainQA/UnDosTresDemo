using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WalmartDemo.Interfaces;

namespace WalmartDemo.Pages
{
    public class BasePage
    {
        public static IWebDriver Drivers { get; set; }
        
        public static IConfig Config { get; set; }

        public BasePage Page { get; private set; }

        //public LoginPage Login_Page { get; private set; }

        public BasePage()
        {
           

        }

        public static string Address;
        

        public static string SiteUrl()
        {
            return "https://prueba.undostres.com.mx/";
        }
        public static bool PageTitle => Driver.Instance.Title.Contains("My Account – Demo Shopping site");

        public void Open()
        {
            Driver.Instance.Navigate().GoToUrl(Address);
        }
    }
}
