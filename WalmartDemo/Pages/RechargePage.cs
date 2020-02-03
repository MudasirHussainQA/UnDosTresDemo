using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WalmartDemo.Configuration;
using WalmartDemo.Helper;
using OpenQA.Selenium.Support.UI;

namespace WalmartDemo.Pages
{
    public class RechargePage : BasePage
    {
        public RechargePage() 
        {

            Address = SiteUrl(); //+ "my - account / ";
            

        }

        public SelectElement SelElement;

        public SelectElement SelectOperator
        {
            get
            {
                return SelElement = new SelectElement(Driver.Instance.FindElement(By.XPath("")));
            }
        }

        public IWebElement Operator => Driver.Instance.FindElement(By.XPath("(//input[@name='operator'and @type='text']) [1]"));
        public IWebElement CellularField => Driver.Instance.FindElement(By.XPath("(//input[@name='mobile'and @type='tel']) [1]"));

        public IWebElement Telcel => Driver.Instance.FindElement(By.CssSelector("img[src='https://d203ovh1oelywy.cloudfront.net/images/operators/telcel_logo.jpg?v=2']"));
        public IWebElement RechargeCoupon => Driver.Instance.FindElement(By.XPath("(//input[@name='amount'and @type='text']) [1]"));

        public IWebElement Recharge10 => Driver.Instance.FindElement(By.XPath("//div[text()='Recarga $10']"));

        public IWebElement RechargeButton => Driver.Instance.FindElement(By.CssSelector("button[class='button buttonRecharge']"));

        public IWebElement CardName => Driver.Instance.FindElement(By.XPath("(//input[@name='cardname'])[2]"));

        public IWebElement CardNumber => Driver.Instance.FindElement(By.XPath("(//label[text()='Número de tarjeta'])[2]"));

        public IWebElement MonthLabel => Driver.Instance.FindElement(By.XPath("(//label[text()='MM'])[2]"));

        public IWebElement YearLabel => Driver.Instance.FindElement(By.XPath("(//label[text()='AAAA'])[2]"));
        public IWebElement CVVLabel => Driver.Instance.FindElement(By.XPath("(//label[text()='CVV'])[2]"));

        public IWebElement EmailRegistered => Driver.Instance.FindElement(By.XPath("(//label[text()='Correo electrónico'])[1]"));

        public IWebElement ApplyRecharge => Driver.Instance.FindElement(By.CssSelector("button[id='paylimit']"));

        public IWebElement UserEmail => Driver.Instance.FindElement(By.CssSelector("button[id='paylimit']"));

        public IWebElement UserPassword => Driver.Instance.FindElement(By.CssSelector("input[id='psw']"));

        public IWebElement RechargeAccess => Driver.Instance.FindElement(By.CssSelector("button[id='loginBtn']"));






        public RechargePage SignInApplication()
        {

            Open();          
                
            
            return new RechargePage();
        }

        public RechargePage RechargeProcess()
        {
            Operator.SendKeys("telcel");
            Telcel.Click();
            CellularField.Click();
            CellularField.SendKeys("5523261151");
            RechargeCoupon.Click();
            Recharge10.Click();
            RechargeButton.Click();
            CardName.SendKeys("Test");
            CardNumber.SendKeys("4111111111111111");
            MonthLabel.SendKeys("11");
            YearLabel.SendKeys("2025");
            CVVLabel.SendKeys("111");
            EmailRegistered.SendKeys("test@test.com");
            ApplyRecharge.Click();
            UserEmail.SendKeys("marze.zr@gmail.com");
            UserPassword.SendKeys("123456");
            RechargeAccess.Click();
            return new RechargePage();
        }


    }
}
