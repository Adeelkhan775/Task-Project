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
        By PracticeFormBtn = By.XPath("//span[contains(text(),'Practice Form')]");
        By MainformBtn = By.XPath("//h5[contains(text(),'Forms')]");
        By AccorForm = By.XPath("//div[.='Forms']");
        By FirstNameTxt = By.Id("firstName");
        By LastNameTxt = By.Id("lastName");
        By EmailTxt = By.Id("userEmail");
        By GenderMale = By.ClassName("custom-control-label");
        By GenderFemale = By.XPath("//*[@id='genterWrapper']/div[2]/div[2]/label");
        By GenderOther = By.Id("gender-radio-3");
        By MobileNumber = By.Id("userNumber");
        By Subject = By.Id("subjectsInput");
        By HobbiesSports = By.Id("hobbies-checkbox-1");
        By HobbiesReading = By.Id("hobbies-checkbox-2");
        By HobbiesMusic = By.Id("hobbies-checkbox-3");
        By SubmitBtn = By.Id("submit");
        By CurrentAddress = By.Id("currentAddress");
        By Calender = By.Id("dateOfBirthInput");
        By SuccessMessage = By.Id("example-modal-sizes-title-lg");

        public void enterValue_FirstName(string value)
        {
            driver.FindElement(FirstNameTxt).Click();
            driver.FindElement(FirstNameTxt).Clear();
            driver.FindElement(FirstNameTxt).SendKeys(value);

        }
        
        public void validate_SucessMessage()
        {

            string message = driver.FindElement(SuccessMessage).Text;
            Assert.AreEqual("Thanks for submitting the form", message);
        }
        //Click on Form button on Main page
        public void click_MainFormsBtn()
        {
            driver.FindElement(MainformBtn).Click();

        }
        //Click on Form Accordian
        public void click_AccorFormBtn()
        {
            driver.FindElement(AccorForm).Click();
        }
        //Click on the Practice form
        public void click_PracticeForm()
        {
            driver.FindElement(PracticeFormBtn).Click();

        }
        //Navigate to Forms Page
        public void Navigate()
        {

              click_MainFormsBtn();
            //Click on the Accordian of  Forms
            click_AccorFormBtn();
            click_PracticeForm();
            
        }
        public void pick_Date() {
            driver.FindElement(Calender).Click();
            driver.FindElement(By.XPath("//div[@class='react-datepicker__day react-datepicker__day--005']")).Click();
        }
        public void enterValue_LastName(string value)
        {
            driver.FindElement(LastNameTxt).Click();
            driver.FindElement(LastNameTxt).Clear();
            driver.FindElement(LastNameTxt).SendKeys(value);

        }

        public void enterValue_Email(string value)
        {

            driver.FindElement(EmailTxt).Click();
            driver.FindElement(EmailTxt).Clear();
            driver.FindElement(EmailTxt).SendKeys(value);

        }

        public void click_Male(string value)
        {  
             if (value.Equals("Male")) {
                 driver.FindElement(GenderMale).Click();
             } else if(value.Equals("Female")) {
                 driver.FindElement(GenderFemale).Click();
             }
             
            
        }

        public void click_Female()
        {
            driver.FindElement(GenderFemale).Click();
             
        }


        public void enterValue_MobileNumber(string value)
        {
            driver.FindElement(MobileNumber).Click();
            driver.FindElement(MobileNumber).Clear();
            driver.FindElement(MobileNumber).SendKeys(value);
             

        }
        public void click_SubmitBtn()
        {
            js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.Id("submit")));
            driver.FindElement(SubmitBtn).Click();

        }

        public string validate_Mandatary_FirstName() {

           js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(FirstNameTxt));
            string Color=driver.FindElement(FirstNameTxt).GetCssValue("border-color");
            string status= driver.FindElement(FirstNameTxt).GetAttribute("required");
            return status;
        }
        
        public string validate_Mandatary_LastName()
        {
            
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(LastNameTxt));
            string Color = driver.FindElement(FirstNameTxt).GetCssValue("border-color");
            string status = driver.FindElement(LastNameTxt).GetAttribute("required");
            return status;
             

        }
        public string validate_Mandatary_Gender()
        {
            string Color = driver.FindElement(GenderOther).GetCssValue("color");
            string status = driver.FindElement(GenderOther).GetAttribute("required");
            return status;
          
        }
        public string validate_Mandatary_MobileNumber()
        {
            js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(MobileNumber));
            string Color = driver.FindElement(MobileNumber).GetCssValue("border-color");
            string status = driver.FindElement(MobileNumber).GetAttribute("required");
            return status;
           
        }


    }
}

