using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace Tasks.Pages
{
  public class FormsPage
    { 
        public IWebDriver driver;
        public IJavaScriptExecutor js;
        public FormsPage(IWebDriver driver)
        {
            this.driver = driver;            
        }
        public By practiceFormBtn = By.XPath("//span[contains(text(),'Practice Form')]");
        public By accorForm = By.XPath("//div[.='Forms']");
        public By firstNameTxt = By.Id("firstName");
        public By lastNameTxt = By.Id("lastName");
        public By genderMale = By.ClassName("custom-control-label");
        public By genderOther = By.Id("gender-radio-3");
        public By mobileNumber = By.Id("userNumber");
        public By submitBtn = By.Id("submit");
        public By successMessage = By.Id("example-modal-sizes-title-lg");
        public void ValidateSucessMessage()
        {
            string message = driver.FindElement(successMessage).Text;
            Assert.AreEqual("Thanks for submitting the form", message);
        }
        //Click on Form Accordian
        public void ClickAccorFormBtn()
        {
            driver.FindElement(accorForm).Click();
        }
        //Click on the Practice form
        public void ClickPracticeForm()
        {
            driver.FindElement(practiceFormBtn).Click();

        }
        //Navigate to Forms Page
        public void NavigateToForms()
        {
            //Click on the Accordian of  Forms
            ClickAccorFormBtn();
            Thread.Sleep(1000);
            ClickPracticeForm();
            Thread.Sleep(1000);
        }
        public void ClickMale(string value)
        {
            if (value.Equals("Male"))
            {
                driver.FindElement(genderMale).Click();
            }            
        }         
        public void EnterMobileNumber(long value)
        {
            driver.FindElement(mobileNumber).Click();
            driver.FindElement(mobileNumber).Clear();
            driver.FindElement(mobileNumber).SendKeys(value.ToString());      
        }
         public void ClickSubmitBtn()
        {
            js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.Id("submit")));
            driver.FindElement(submitBtn).Click();
            Thread.Sleep(1000);
        }
        // Method to fill and Submit form
        public void FillForm()
        {
            PersonInfo personInfo = new PersonInfo("Adeel", "Bashir", "Male", 03115515448);
            EnterDataInFields(firstNameTxt,personInfo.firstName);
            EnterDataInFields(lastNameTxt,personInfo.lastName);
            ClickMale(personInfo.gender);
            EnterMobileNumber(personInfo.mobileNumber);
            ClickSubmitBtn();
            Thread.Sleep(1000);
        }
        // Generic common method to enter data in text fields
        public void EnterDataInFields(By element, string text)
        {
            js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(element));
            driver.FindElement(element).Click();
            driver.FindElement(element).Clear();
            driver.FindElement(element).SendKeys(text);

        }
        // Method to Validate all mandatory fields
        public void ValidateAllMandatoryFields()
        {
            js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(submitBtn));
            ClickSubmitBtn();
            Thread.Sleep(1000);
            ValidateField(firstNameTxt);
            ValidateField(lastNameTxt);
            ValidateField(mobileNumber);
            ValidateField(genderOther);
        }
        //Generic common method to Validate fields
        public void ValidateField(By element)
        {
            js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(element));
            string status = driver.FindElement(element).GetAttribute("required");
            Assert.AreEqual("true", status);
        }
    }
}

