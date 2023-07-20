using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AppiumSpecflowDemo.StepDefinitions
{
    [Binding]
    public class AppiumTestStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        AndroidDriver<AppiumWebElement> appiumDriver;
        public AppiumTestStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            //appiumDriver = _scenarioContext.Get<AndroidDriver<AppiumWebElement>>();
            appiumDriver = _scenarioContext.Get<AndroidDriver<AppiumWebElement>>("AppiumDriver");
        }

        [Given(@"I enter password and login")]
        public void GivenIEnterPasswordAndLogin(Table table)
        {
            Thread.Sleep(5000);
            dynamic data = table.CreateDynamicInstance();
            AppiumWebElement okButton= appiumDriver.FindElementById("android:id/button1");
            Thread.Sleep(500);
            okButton.Click();

            appiumDriver.FindElementByXPath("//android.view.ViewGroup[@content-desc=\"NumpadButtons\"]/android.widget.Button[2]").Click();
            appiumDriver.FindElementByXPath("//android.view.ViewGroup[@content-desc=\"NumpadButtons\"]/android.widget.Button[11]").Click();
            appiumDriver.FindElementByXPath("//android.view.ViewGroup[@content-desc=\"NumpadButtons\"]/android.widget.Button[11]").Click();
            appiumDriver.FindElementByXPath("//android.view.ViewGroup[@content-desc=\"NumpadButtons\"]/android.widget.Button[12]").Click();
            Thread.Sleep(500);
        }

        [When(@"I add table with two guests")]
        public void WhenINavigateToOrderScreen()
        {
            Thread.Sleep(500);
            appiumDriver.FindElementById("com.ncr.AlohaMobile:id/btnAddTable").Click();
            appiumDriver.FindElementByXPath("//*[@text=\"2\"]").Click();
            appiumDriver.FindElementByXPath("//*[@text=\"2\"]").Click();
            appiumDriver.FindElementByXPath("//*[@text=\"OK\"]").Click();
            Thread.Sleep(500);
            //throw new PendingStepException();
        }

        [When(@"I search and select the item '([^']*)'")]
        public void WhenISearchAndSelectTheItem(string itemName)
        {
            Thread.Sleep(500);
            appiumDriver.FindElementById("com.ncr.AlohaMobile:id/btnSearch").Click();
            appiumDriver.FindElementById("android:id/search_src_text").SendKeys(itemName);
            appiumDriver.FindElementByXPath($"//android.widget.TextView[@class='android.widget.TextView' and @text='{itemName}']").Click();
            appiumDriver.FindElementByAccessibilityId("Open navigation drawer").Click();
            Thread.Sleep(500);
        }


        [Then(@"I remove item and close the order")]
        public void ThenIPayAndCompleteTheOrder()
        {
            Thread.Sleep(500);
            appiumDriver.FindElementByXPath("//android.widget.Button[@text='Pay']").Click();
            Thread.Sleep(1000);
            appiumDriver.FindElementByAccessibilityId("Open navigation drawer").Click();
            Thread.Sleep(500);
            appiumDriver.FindElementById("com.ncr.AlohaMobile:id/btnDelete").Click();
            Thread.Sleep(500);
            appiumDriver.FindElementByXPath("//android.widget.TextView[@text='SELECT ALL']/preceding-sibling::*").Click();
            appiumDriver.FindElementByXPath("//android.widget.Button[@text='OK']").Click();
            Thread.Sleep(500);
            appiumDriver.FindElementByXPath("//android.widget.CheckedTextView[@text='TESTING']").Click();
            appiumDriver.FindElementById("android:id/button1").Click();
            Thread.Sleep(500);
            appiumDriver.FindElementByXPath("//android.widget.Button[@text='Pay']").Click();
            Thread.Sleep(500);
            appiumDriver.FindElementByXPath("//android.widget.Button[@text='Close']").Click();
        }
    }
}
