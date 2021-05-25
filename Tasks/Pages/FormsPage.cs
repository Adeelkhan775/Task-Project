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
        By practiceFormBtn = By.XPath("//span[contains(text(),'Practice Form')]");
        By accorForm = By.XPath("//div[.='Forms']");
        By firstNameTxt = By.Id("firstName");
        By lastNameTxt = By.Id("lastName");
        By emailTxt = By.Id("userEmail");
        By genderMale = By.ClassName("custom-control-label");
        By genderOther = By.Id("gender-radio-3");
        By mobileNumber = By.Id("userNumber");
        By submitBtn = By.Id("submit");
        By successMessage = By.Id("example-modal-sizes-title-lg");
        public void enterFirstName(string value)
        {
            driver.FindElement(firstNameTxt).Click();
            driver.FindElement(firstNameTxt).Clear();
            driver.FindElement(firstNameTxt).SendKeys(value);
        }       
        public void validateSucessMessage()
        {
            string message = driver.FindElement(successMessage).Text;
            Assert.AreEqual("Thanks for submitting the form", message);
        }
        //Click on Form Accordian
        public void clickaccorFormBtn()
        {
            driver.FindElement(accorForm).Click();
        }
        //Click on the Practice form
        public void clickPracticeForm()
        {
            driver.FindElement(practiceFormBtn).Click();

        }
        //Navigate to Forms Page
        public void navigateToForms()
        {
            //Click on the Accordian of  Forms
            clickaccorFormBtn();
            clickPracticeForm();
            Thread.Sleep(1000);
        }
        public void enterLastName(string value)
        {
            driver.FindElement(lastNameTxt).Click();
            driver.FindElement(lastNameTxt).Clear();
            driver.FindElement(lastNameTxt).SendKeys(value);
        }
        public void enterEmail(string value)
        {
            driver.FindElement(emailTxt).Click();
            driver.FindElement(emailTxt).Clear();
            driver.FindElement(emailTxt).SendKeys(value);
        }
        public void clickMale(string value)
        {
            if (value.Equals("Male"))
            {
                driver.FindElement(genderMale).Click();
            }            
        }         
        public void enterMobileNumber(long value)
        {
            driver.FindElement(mobileNumber).Click();
            driver.FindElement(mobileNumber).Clear();
            driver.FindElement(mobileNumber).SendKeys(value.ToString());      
        }
         public void clickSubmitBtn()
        {
            js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.Id("submit")));
            driver.FindElement(submitBtn).Click();
            Thread.Sleep(1000);
        }
        // Method to fill and Submit form
        public void fillForm()
        {
            PersonInfo personInfo = new PersonInfo("Adeel", "Bashir", "Male", 03115515448, "adeelkhan775@gmail.com");
            enterDataInFields(firstNameTxt,personInfo.firstName);
            enterDataInFields(lastNameTxt,personInfo.lastName);
            enterDataInFields(mobileNumber,personInfo.emailAddress);
            enterDataInFields(mobileNumber,personInfo.emailAddress);
            clickMale(personInfo.gender);
            enterMobileNumber(personInfo.mobileNumber);
            clickSubmitBtn();
            Thread.Sleep(1000);
        }
        // Generic common method to enter data in text fields
        public void enterDataInFields(By element, string text)
        {
            js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(element));
            driver.FindElement(element).Click();
            driver.FindElement(element).Clear();
            driver.FindElement(element).SendKeys(text);

        }
        // Method to validate all mandatory fields
        public void validateAllMandatoryFields()
        {
            js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(submitBtn));
            clickSubmitBtn();
            Thread.Sleep(1000);
            validateField(firstNameTxt);
            validateField(lastNameTxt);
            validateField(mobileNumber);
            validateField(genderOther);
        }
        //Generic common method to validate fields
        public void validateField(By element)
        {
            js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(element));
            string status = driver.FindElement(element).GetAttribute("required");
            Assert.AreEqual("true", status);
        }
    }
}

