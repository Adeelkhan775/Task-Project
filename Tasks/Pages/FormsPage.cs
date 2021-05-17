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
        }
        public string validateMandatoryFirstName() 
        {
            js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(firstNameTxt));
            string Color=driver.FindElement(firstNameTxt).GetCssValue("border-color");
            string status= driver.FindElement(firstNameTxt).GetAttribute("required");
            return status;
        }
        
        public string validateMandatoryLastName()
        {           
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(lastNameTxt));
            string Color = driver.FindElement(firstNameTxt).GetCssValue("border-color");
            string status = driver.FindElement(lastNameTxt).GetAttribute("required");
            return status;
        }
        public string validateMandatoryGender()
        {
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(genderMale));
            string Color = driver.FindElement(genderOther).GetCssValue("color");
            string status = driver.FindElement(genderOther).GetAttribute("required");
            return status;          
        }
        public string validateMandatoryMobileNumber()
        {
            js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(mobileNumber));
            string Color = driver.FindElement(mobileNumber).GetCssValue("border-color");
            string status = driver.FindElement(mobileNumber).GetAttribute("required");
            return status;           
        }
    }
}
