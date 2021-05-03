using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using Tasks.Base;
using Tasks.Pages;
using System.Threading;

namespace Tasks.TestScripts
{
    [TestFixture]
    public class Test_Suit1 : Base_Class
    {
        public FormsPage formpage = null;


        /*Case 1
        •	Main steps:
        •	Open https://demoqa.com/
        •	Navigate to Forms
        •	Click 'Practice Form'
        •	Fill form using "Value object" pattern (only required fields), submit form
        •	Verify that form submitted successfully
         */

        [Test, Order(1)]
        public void TestMethod1()
        {
            formpage = new FormsPage(driver);
            formpage.Navigate();
            Thread.Sleep(1000);
            formpage.click_SubmitBtn();
            Thread.Sleep(1000);
            Assert.AreEqual("true", formpage.validate_Mandatary_FirstName());
            Assert.AreEqual("true", formpage.validate_Mandatary_LastName());
            Assert.AreEqual("true", formpage.validate_Mandatary_MobileNumber());
            Assert.AreEqual("true", formpage.validate_Mandatary_Gender());

        }

                 /*Case 2:
                •	Main steps:
                •	Open https://demoqa.com/
                •	Navigate to Forms
                •	Click 'Practice Form'
                •	Submit empty form
                •	Verify "First Name", "Last Name", "Gender" are required fields
                */

        [Test, Order(2)]
        public void TestMethod2()
        {
            formpage = new FormsPage(driver);
            formpage.Navigate();
            Thread.Sleep(1000);
            formpage.enterValue_FirstName("Adeel");
            formpage.enterValue_LastName("Bashir");
            formpage.click_Male("Male");
            formpage.enterValue_MobileNumber("923115515448");
            formpage.enterValue_Email("adeelkhan775@gmail.com");
            formpage.click_SubmitBtn();
            formpage.validate_SucessMessage();


        }

        [TearDown]
        public void teardown() {
        
            driver.Close();
        }

    }

}
