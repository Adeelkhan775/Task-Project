using NUnit.Framework;
using Tasks.Base;
using Tasks.Pages;


namespace Tasks.TestScripts
{
    [TestFixture]
    public class TestSuit1 : BaseClass
    {
        public FormsPage formPage = null;

        /*Case 1:
       •	Main steps:
       •	Open https://demoqa.com/forms
       •	Navigate to Forms
       •	Click 'Practice Form'
       •	Submit empty form
       •	Verify "First Name", "Last Name", "Gender" "Mobile Number "are required fields
       */

        [Test, Order(1)]
        public void TestMethod1()
        {
            formPage = new FormsPage(driver);
            formPage.NavigateToForms();
            formPage.ValidateAllMandatoryFields();
        }

        /*Case 2
        •	Main steps:
        •	Open https://demoqa.com/forms
        •	Navigate to Forms
        •	Click 'Practice Form'
        •	Fill form using "Value object" pattern (only required fields), submit form
        •	Verify that form submitted successfully
         */

        [Test, Order(2)]
        public void TestMethod2()
        {
            formPage = new FormsPage(driver);
            formPage.NavigateToForms();
            formPage.FillForm();
            formPage.ValidateSucessMessage();
        }

    }

}
