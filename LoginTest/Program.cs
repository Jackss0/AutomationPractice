using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Bogus.DataSets;


namespace LoginTest
{
    class Program
    {
        static void Main(string[] args)
        {

            string randomEmail = new Internet().Email();
            string randomFirstName = new Name().FirstName();
            string randomLastName = new Name().LastName();
            string randomPassword = new Internet().Password();
            string randomCompany = new Company().CompanyName();
            string randomAddress1 = new Address().StreetAddress();
            string randomAddress2 = new Address().SecondaryAddress();
            string randomCity = new Address().City();
            string randomOther = new Lorem().Text();
            string randomHomePhoneNumber = new PhoneNumbers().PhoneNumberFormat(1);
            string randomMobilePhoneNumber = new PhoneNumbers().PhoneNumberFormat(1);

            string folder = "";

            //IWebDriver _driver = new ChromeDriver();
            IWebDriver _driver = new FirefoxDriver();

            if (_driver.GetType() == typeof(FirefoxDriver))
            {
                folder = "Firefox";
            }
            else
            {
                folder = "Chrome";
            }

            _driver.Manage().Window.Maximize();
            _driver.Url = "http://automationpractice.com/index.php";

            void TakeScreenShot(string path)

            {
                Screenshot sreenShot = ((ITakesScreenshot)_driver).GetScreenshot();
                sreenShot.SaveAsFile(path, ScreenshotImageFormat.Png);
            }
            
            void CreateAccount()
            {
                TakeScreenShot($@"D:\{folder}\CreateAccountStep_1.png");

                var btnLogin = _driver.FindElement(By.ClassName("login"));
                btnLogin.Click();
                Task.Delay(3500).Wait();

                var txtEmail = _driver.FindElement(By.ClassName("account_input"));
                txtEmail.SendKeys(randomEmail);
                TakeScreenShot($@"D:\{folder}\CreateAccountStep_2.png");
                Task.Delay(3500).Wait();

                var btnCreateAccount = _driver.FindElement(By.Id("SubmitCreate"));
                btnCreateAccount.Click();
                Task.Delay(3500).Wait();

                var chkGender = _driver.FindElement(By.Id("id_gender1"));
                chkGender.Click();

                var txtFirstName = _driver.FindElement(By.Id("customer_firstname"));
                txtFirstName.SendKeys(randomFirstName);

                var txtLastName = _driver.FindElement(By.Id("customer_lastname"));
                txtLastName.SendKeys(randomLastName);

                var txtPassword = _driver.FindElement(By.Id("passwd"));
                txtPassword.SendKeys(randomPassword);

                var comboDay = _driver.FindElement(By.Id("days"));
                var selectElement = new SelectElement(comboDay);
                selectElement.SelectByValue("22");

                var comboMonth = _driver.FindElement(By.Id("months"));
                var selectElement2 = new SelectElement(comboMonth);
                selectElement2.SelectByValue("1");

                var comboYear = _driver.FindElement(By.Id("years"));
                var selectElement3 = new SelectElement(comboYear);
                selectElement3.SelectByValue("1999");


                var txtCompanyName = _driver.FindElement(By.Id("company"));
                txtCompanyName.SendKeys(randomCompany);

                var txtAddress = _driver.FindElement(By.Id("address1"));
                txtAddress.SendKeys(randomAddress1);

                var txtAddress2 = _driver.FindElement(By.Id("address2"));
                txtAddress2.SendKeys(randomAddress2);

                var txtCity = _driver.FindElement(By.Id("city"));
                txtCity.SendKeys(randomCity);

                var comboState = _driver.FindElement(By.Id("id_state"));
                var selectElement4 = new SelectElement(comboState);
                selectElement4.SelectByValue("1");

                var txtPostcode = _driver.FindElement(By.Id("postcode"));
                txtPostcode.SendKeys("36523");

                var comboContry = _driver.FindElement(By.Id("id_country"));
                var selectElement5 = new SelectElement(comboContry);
                selectElement5.SelectByValue("21");

                var txtOther = _driver.FindElement(By.Id("other"));
                txtOther.SendKeys(randomOther);

                var txtHomePhone = _driver.FindElement(By.Id("phone"));
                txtHomePhone.SendKeys(randomHomePhoneNumber);

                var txtMobilePhone = _driver.FindElement(By.Id("phone_mobile"));
                txtMobilePhone.SendKeys(randomMobilePhoneNumber);

                //SCREENSHOT STEP 1
                TakeScreenShot($@"D:\{folder}\CreateAccountStep_3.png");
                Task.Delay(3500).Wait();

                var btnRegister = _driver.FindElement(By.Id("submitAccount"));
                btnRegister.Click();
                Task.Delay(3500).Wait();


            }

            void Login()
            {
                var btnLogout = _driver.FindElement(By.ClassName("logout"));
                btnLogout.Click();
                Task.Delay(3500).Wait();

                var txtEmailLogin = _driver.FindElement(By.Id("email"));
                txtEmailLogin.SendKeys(randomEmail);

                var txtPasswordLogin = _driver.FindElement(By.Id("passwd"));
                txtPasswordLogin.SendKeys(randomPassword);

                var btnRegisterLogin = _driver.FindElement(By.Id("SubmitLogin"));

                //SCREENSHOT STEP 2
                TakeScreenShot($@"D:\{folder}\LoginStep.png");
                btnRegisterLogin.Click();
                Task.Delay(3500).Wait();
            }

            void Buy()
            {
                var btnWomen = _driver.FindElement(By.ClassName("sf-with-ul"));
                TakeScreenShot($@"D:\{folder}\OrderStep_1.png");
                btnWomen.Click();
                Task.Delay(3500).Wait();

                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                //var element = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("first-item-of-tablet-line")));
                var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div[2]/div/div[3]/div[2]/ul/li[1]")));

                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript("arguments[0].scrollIntoView()", element);

                Task.Delay(3500).Wait();
                Actions action = new Actions(_driver);
                action.MoveToElement(element).Perform();
                TakeScreenShot($@"D:\{folder}\OrderStep_2.png");
                Task.Delay(3500).Wait();

                var btnAddCart1 = _driver.FindElement(By.XPath("//*[@id='center_column']/ul/li[1]/div/div[2]/div[2]/a[1]"));
                TakeScreenShot($@"D:\{folder}\OrderStep_3.png");
                btnAddCart1.Click();
                Task.Delay(3500).Wait();

                var btnProccedToCheckout1 = _driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/a"));
                TakeScreenShot($@"D:\{folder}\OrderStep_4.png");
                btnProccedToCheckout1.Click();
                Task.Delay(3500).Wait();

                var btnProccedToCheckout2 = _driver.FindElement(By.XPath("//*[@id='center_column']/p[2]/a[1]"));
                TakeScreenShot($@"D:\{folder}\OrderStep_5.png");
                btnProccedToCheckout2.Click();
                Task.Delay(3500).Wait();

                var btnProccedToCheckout3 = _driver.FindElement(By.XPath("//*[@id='center_column']/form/p/button"));
                TakeScreenShot($@"D:\{folder}\OrderStep_6.png");
                btnProccedToCheckout3.Click();
                Task.Delay(3500).Wait();

                var chkAgree = _driver.FindElement(By.Id("cgv"));
                TakeScreenShot($@"D:\{folder}\OrderStep_7.png");
                chkAgree.Click();

                var btnProccedToCheckout4 = _driver.FindElement(By.XPath("//*[@id='form']/p/button"));
                TakeScreenShot($@"D:\{folder}\OrderStep_8.png");
                btnProccedToCheckout4.Click();
                Task.Delay(3500).Wait();

                var btnPayBankWire = _driver.FindElement(By.ClassName("bankwire"));
                TakeScreenShot($@"D:\{folder}\OrderStep_9.png");
                btnPayBankWire.Click();
                Task.Delay(3500).Wait();

                var btnConfirm = _driver.FindElement(By.XPath("//*[@id='cart_navigation']/button"));
                TakeScreenShot($@"D:\{folder}\OrderStep_10.png");
                btnConfirm.Click();
                Task.Delay(3500).Wait();

                //SCREENSHOT STEP 3
                TakeScreenShot($@"D:\{folder}\OrderStep_final.png");
            }

            CreateAccount();
            Login();
            Buy();
            _driver.Quit();

        }
    }
}
