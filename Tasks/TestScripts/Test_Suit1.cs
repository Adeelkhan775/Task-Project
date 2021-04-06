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

            try
            {
                if (driver != null)
                {
                    formpage = new FormsPage(driver);
                    formpage.Navigate();
                    Thread.Sleep(1000);
                    formpage.Click_btnSubmit();
                    Thread.Sleep(1000);
                    formpage.Validate_Mandatary_FirstName();
                    formpage.Validate_Mandatary_LastName();
                    formpage.Validate_Mandatary_MobileNumber();
                    formpage.Validate_Mandatary_Gender();
                }
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }

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
            try
            {
                if (driver != null)
                {
                    formpage = new FormsPage(driver);
                    formpage.Navigate();
                    formpage.enterValue_firstName("Adeel");
                    formpage.enterValue_lastName("Bashir");
                    formpage.Click_Male("Male");
                    formpage.enterValue_MobileNumber("923115515448");
                    formpage.enterValue_Email("adeelkhan775@gmail.com");
                    formpage.Click_btnSubmit();
                    formpage.Validate_sucessMessage();
                }
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }


       


    }

}