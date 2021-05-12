using NUnit.Framework;
using Tasks.Base;
using Tasks.Pages;
using System.Threading;

namespace Tasks.TestScripts
{
    [TestFixture]
    public class TestSuit1 : BaseClass
    {
        public FormsPage formPage = null;

        /*Case 1:
       •	Main steps:
       •	Open https://demoqa.com/
       •	Navigate to Forms
       •	Click 'Practice Form'
       •	Submit empty form
       •	Verify "First Name", "Last Name", "Gender" are required fields
       */

        [Test, Order(1)]
        public void testMethod1()
        {
            formPage = new FormsPage(driver);
            formPage.navigate();
            Thread.Sleep(1000);
            formPage.clickSubmitBtn();
            Thread.Sleep(1000);
            Assert.AreEqual("true", formPage.validateMandataryFirstName());
            Assert.AreEqual("true", formPage.validateMandataryLastName());
            Assert.AreEqual("true", formPage.validateMandataryMobileNumber());
            Assert.AreEqual("true", formPage.validateMandataryGender());
        }

        /*Case 2
        •	Main steps:
        •	Open https://demoqa.com/
        •	Navigate to Forms
        •	Click 'Practice Form'
        •	Fill form using "Value object" pattern (only required fields), submit form
        •	Verify that form submitted successfully
         */

        [Test, Order(2)]
        public void testMethod2()
        {
            formPage = new FormsPage(driver);
            formPage.navigate();
            Thread.Sleep(1000);
            PersonInfo personInfo = new PersonInfo("Adeel", "Bashir", "Male", 03115515448, "adeelkhan775@gmail.com");
            formPage.enterFirstName(personInfo.firstName);
            formPage.enterLastName(personInfo.lastName);
            formPage.clickMale(personInfo.sex);
            formPage.enterMobileNumber(personInfo.mobileNumber);
            formPage.enterEmail(personInfo.emailAddress);
            formPage.clickSubmitBtn();
            Thread.Sleep(1000);
            formPage.validateSucessMessage();
        }

        [TearDown]
        public void closeTab()
        {   
            driver.Close();
        }

    }

}
