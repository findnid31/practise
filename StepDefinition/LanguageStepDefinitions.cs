
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QAMars.Pages;
using QAMars.Utilities;
using System;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium.DevTools.V128.Page;

namespace ConsoleApp2.QAMars.StepDefinition
{
    [Binding]
    public class LanguageStepDefinitions: CommonDriver
    {
        LoginPage loginPageObj;
        LanguageTest languagePageObj;
        
        public LanguageStepDefinitions() 
        {
            loginPageObj = new LoginPage();
            languagePageObj = new LanguageTest();
            
        }

        [Given(@"I logged into Mars portal successfully")]
        public void GivenILoggedIntoMarsPortalSuccessfully()
        {
            
            //login page object initiallization and definition
            loginPageObj.LoginActions();
        }
        [When(@"I add a language ""([^""]*)"" and language level ""([^""]*)""")]
        public void WhenIAddALanguageAndLanguageLevel(string language, string level)
        {
            //Add language page object initialization and definition
             
           languagePageObj.ClearData();
           languagePageObj.AddLanguage(language,level);

        }
        //Verify if language record is created successfully

        [Then(@"the ""([^""]*)"" record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully(string language)
        {
            string newValue = languagePageObj.GetNewLanguage(language);
            Assert.That(newValue == language, "Actual value and expected value donot match");
           
        }

        // Adding invalid language and level
        [When(@"I add a language ""([^""]*)"" and level ""([^""]*)""")]
        public void WhenIAddALanguageAndLevel(string invalidlanguage, string invalidlevel)
        {            
            languagePageObj.AddLanguage(invalidlanguage, invalidlevel);

        }
        // Error message should be seen for invalid language and level
        [Then(@"error message should be seen successfully")]
        public void ThenErrorMessageShouldBeSeenSuccessfully()
        {
            IWebElement popupMsg = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            string popupMsgBox = popupMsg.Text;
            Console.Write(popupMsgBox);
            string popupMsgLang = "Please enter language and level";
            string popupMsgDupLang = "This language is already exist in your language list.";
            Assert.That(popupMsgBox == popupMsgLang || popupMsgBox == popupMsgDupLang, "Actual value and expected value donot match");
                        
        }

        //Edit language page object initialization and definition
        [When(@"I edit an existing language""([^""]*)"" and ""([^""]*)"" to ""([^""]*)"" and level to ""([^""]*)""")]
        public void WhenIEditAnExistingLanguageAndToAndLevelTo(string language, string level, string elang, string elevel)
        {
            languagePageObj.ClearData();
            languagePageObj.AddLanguage(language, level);
            languagePageObj.EditLanguageRecord(elang, elevel);
        }
               

        [Then(@"new ""([^""]*)"" record should be displayed successfully")]
        public void ThenNewRecordShouldBeDisplayedSuccessfully(string updatedlanguage)
        {
            //Verify if confirmation pop up is seen for edit language 

            IWebElement popupMsg = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            string popupMsgBox = popupMsg.Text;
            Console.Write(popupMsgBox);
            string popupMsgLang = updatedlanguage + " has been updated to your languages";
            Assert.That(popupMsgBox, Is.EqualTo(popupMsgLang),"Actual value and expected value donot match");
        }

        //Delete language page object initialization and definition
        [When(@"I have an existing ""([^""]*)"" and ""([^""]*)"" record to delete")]
        public void WhenIHaveAnExistingAndRecordToDelete(string language, string level)
        {
            languagePageObj.ClearData();
            languagePageObj.AddLanguage(language, level);
            languagePageObj.DeleteLanguageRecord();
        }

       
        [Then(@"the record should be deleted successfully")]
        public void ThenTheRecordShouldBeDeletedSuccessfully()
        {
            {
                Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 5);

                //Verify if confirmation pop up is seen for delete

                IWebElement delPopupMsg = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                string popupMsgBox = delPopupMsg.Text;
                Console.Write(delPopupMsg);
                string popupMsgDel = " has been deleted";
                Assert.That(popupMsgBox, Does.Contain(popupMsgDel), "Actual value and expected value donot match");

            }
            
        }

    }
}





