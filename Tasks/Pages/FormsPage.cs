using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
namespace Tasks.Pages
{
  public class FormsPage
    { 
        public IWebDriver driver;
        public IWebElement element;
        public IJavaScriptExecutor js;

        public FormsPage(IWebDriver driver)
        {
            this.driver = driver; 

           
        }
        By btn_PracticeForm = By.XPath("//span[contains(text(),'Practice Form')]");

        By btn_Mainform = By.XPath("//h5[contains(text(),'Forms')]");

        By Accor_form = By.XPath("//div[.='Forms']");

        By firstName = By.Id("firstName");
        
        By LastName = By.Id("lastName");

        By Email = By.Id("userEmail");

        By Gender_Male = By.ClassName("custom-control-label");

        By Gender_Female = By.XPath("//*[@id='genterWrapper']/div[2]/div[2]/label");

        By Gender_Other = By.Id("gender-radio-3");

        By Mobile_Number = By.Id("userNumber");

        By Subject = By.Id("subjectsInput");

        By hobbies_Sports = By.Id("hobbies-checkbox-1");
        By hobbies_Reading = By.Id("hobbies-checkbox-2");
        By hobbies_Music = By.Id("hobbies-checkbox-3");

        By Submit_button = By.Id("submit");
        By currentAddress = By.Id("currentAddress");

        By Calender = By.Id("dateOfBirthInput");
        By Success_Message = By.Id("example-modal-sizes-title-lg");

        public void enterValue_firstName(string value)
        {
            driver.FindElement(firstName).Click();
            driver.FindElement(firstName).Clear();
            driver.FindElement(firstName).SendKeys(value);

        }
        
        public void Validate_sucessMessage()
        {

            string message = driver.FindElement(Success_Message).Text;

            Assert.AreEqual("Thanks for submitting the form", message);
        }
        //Click on Form button on Main page
        public void click_btnMainForms()
        {
            driver.FindElement(btn_Mainform).Click();

        }
        //Click on Form Accordian
        public void click_btn_AccorForm()
        {
            driver.FindElement(Accor_form).Click();
        }
        //Click on the Practice form
        public void click_PracticeForm()
        {
            driver.FindElement(btn_PracticeForm).Click();

        }
        //Navigate to Forms Page
        public void Navigate()
        {

              click_btnMainForms();
            //Click on the Accordian of  Forms
            click_btn_AccorForm();
            //Click on the Practice Form 
            // System.Threading.Thread.Sleep(10000);
           click_PracticeForm();
            
        }
        public void pick_date() {
            driver.FindElement(Calender).Click();
            driver.FindElement(By.XPath("//div[@class='react-datepicker__day react-datepicker__day--005']")).Click();
        }
        public void enterValue_lastName(string value)
        {
            driver.FindElement(LastName).Click();
            driver.FindElement(LastName).Clear();
            driver.FindElement(LastName).SendKeys(value);

        }

        public void enterValue_Email(string value)
        {

            driver.FindElement(Email).Click();
            driver.FindElement(Email).Clear();
            driver.FindElement(Email).SendKeys(value);

        }

        public void Click_Male(string value)
        {  
             if (value.Equals("Male")) {
                 driver.FindElement(Gender_Male).Click();
             } else if (value.Equals("Female")) {
                 driver.FindElement(Gender_Female).Click();
             }
             else {
              //driver.FindElement(Gender_Other).Click();
             }
            
        }

        public void Click_Female()
        {
            driver.FindElement(Gender_Female).Click();
             }


        public void enterValue_MobileNumber(string value)
        {
            driver.FindElement(Mobile_Number).Click();
            driver.FindElement(Mobile_Number).Clear();
            driver.FindElement(Mobile_Number).SendKeys(value);
             

        }
        public void Click_btnSubmit()
        {
           
            js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.Id("submit")));
            driver.FindElement(Submit_button).Click();

        }

        public void Validate_Mandatary_FirstName() {

           js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(firstName));
            string Color=driver.FindElement(firstName).GetCssValue("border-color");
            string status= driver.FindElement(firstName).GetAttribute("required"); 
            Assert.AreEqual("true", status);
             Console.WriteLine(status);
        }
        
        public void Validate_Mandatary_LastName()
        {
            
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(LastName));
            string Color = driver.FindElement(firstName).GetCssValue("border-color");
//            Assert.AreEqual("rgba(220, 53, 69, 1)", Color);
            string status = driver.FindElement(LastName).GetAttribute("required");
            Assert.AreEqual("true", status);
            Console.WriteLine(status);

        }
        public void Validate_Mandatary_Gender()
        {

            string Color = driver.FindElement(Gender_Other).GetCssValue("color");
//            Assert.AreEqual("rgba(220, 53, 69, 1)", Color);
            string status = driver.FindElement(Gender_Other).GetAttribute("required");
            Assert.AreEqual("true", status);
            Console.WriteLine(status);
        }
        public void Validate_Mandatary_MobileNumber()
        {

            js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(Mobile_Number));
            string Color = driver.FindElement(Mobile_Number).GetCssValue("border-color");
            string status = driver.FindElement(Mobile_Number).GetAttribute("required");
            Assert.AreEqual("true", status);
            Console.WriteLine(status);
        }


    }
}

