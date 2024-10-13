using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace QAMars.Utilities
{
    [Binding]
    public class Hooks:CommonDriver
    {
        
        [BeforeScenario]
        public void BeforeScenario()
        {
            BrowserSetup();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            CloseBrowser();
        }
    }

}

