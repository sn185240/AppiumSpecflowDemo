using Dynamitey.DynamicObjects;
using NUnit.Framework;
using OpenQA.Selenium;
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

        [Given(@"I enroll device")]
        public void GivenIEnrollDevice()
        {
            Thread.Sleep(5000);
            if (appiumDriver.FindElementsById("com.android.permissioncontroller:id/permission_allow_button").Count > 0)
            {
                appiumDriver.FindElementById("com.android.permissioncontroller:id/permission_allow_button").Click();
                Thread.Sleep(500);
                appiumDriver.FindElementById("com.android.permissioncontroller:id/permission_allow_foreground_only_button").Click();
                Thread.Sleep(500);
                appiumDriver.FindElementById("com.android.permissioncontroller:id/permission_allow_button").Click();
                Thread.Sleep(500);
                appiumDriver.FindElementByAccessibilityId("Open navigation drawer").Click();
                Thread.Sleep(500);
                appiumDriver.FindElementByXPath("//*[@text=\"About\"]").Click();
                Thread.Sleep(500);
                appiumDriver.FindElementByXPath("//*[@text=\"Enroll Device\"]").Click();
                Thread.Sleep(500);
                appiumDriver.FindElementById("com.ncr.AlohaMobile:id/btnManualIpEntry").Click();
                Thread.Sleep(500);
                appiumDriver.FindElementByXPath("//android.view.ViewGroup[@content-desc=\"EnrollDeviceDialog\"]/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[1]/android.view.ViewGroup/android.widget.EditText").SendKeys("192.168.56.199");
                //Thread.Sleep(500);
                //appiumDriver.FindElementByXPath("//android.view.ViewGroup[@content-desc=\"EnrollDeviceDialog\"]/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.view.ViewGroup/android.widget.EditText").Click();
                Thread.Sleep(500);
                appiumDriver.FindElementByXPath("//android.view.ViewGroup[@content-desc=\"EnrollDeviceDialog\"]/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.view.ViewGroup/android.widget.EditText").SendKeys("8897");
                Thread.Sleep(500);
                appiumDriver.FindElementByXPath("//android.view.ViewGroup[@content-desc=\"EnrollDeviceDialog\"]/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[3]/android.view.ViewGroup/android.widget.EditText").Click();
                Thread.Sleep(500);
                appiumDriver.FindElementByXPath("//android.view.ViewGroup[@content-desc=\"EnrollDeviceDialog\"]/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[3]/android.view.ViewGroup/android.widget.EditText").SendKeys("TempOPAYPWD@123");
                Thread.Sleep(500);
                appiumDriver.FindElementByXPath("//*[@text=\"Begin Enrollment\"]").Click();
                Thread.Sleep(5000);
                appiumDriver.FindElementByXPath("//android.view.ViewGroup[@content-desc=\"AboutPortraitMode\"]/android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup/android.widget.FrameLayout[2]/android.view.ViewGroup/android.view.ViewGroup/android.widget.FrameLayout[1]/android.view.ViewGroup/android.widget.Button").Click();
                Thread.Sleep(500);
                while (appiumDriver.FindElementsByXPath("//*[contains(@text,\"23 aXi\")]").Count == 0)
                {
                    appiumDriver.FindElementByXPath("//android.view.ViewGroup[@content-desc=\"AboutPortraitMode\"]/android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup/android.widget.FrameLayout[2]/android.view.ViewGroup/android.view.ViewGroup/android.widget.FrameLayout[1]/android.view.ViewGroup/android.widget.Button").Click();
                    Thread.Sleep(1500);
                }
                appiumDriver.FindElementByXPath("//*[contains(@text,\"23 aXi\")]").Click();
                Thread.Sleep(500);
                appiumDriver.FindElementById("android:id/button1").Click();
                Thread.Sleep(500);
                appiumDriver.FindElementByXPath("//*[@text=\"Confirm Enrollment\"]").Click();
                Thread.Sleep(500);
                if (appiumDriver.FindElements(By.Id("android:id/message")).Count > 0)
                {
                    appiumDriver.FindElementById("android:id/button1").Click();
                    Thread.Sleep(500);
                }
            }
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


        [When(@"I add table with '([^']*)' guests")]
        public void WhenINavigateToOrderScreen(string numberOfGuests)
        {
            Thread.Sleep(500);
            appiumDriver.FindElementById("com.ncr.AlohaMobile:id/btnAddTable").Click();
            Thread.Sleep(500);
            appiumDriver.FindElementByXPath("//*[@text=\"2\"]").Click();
            Thread.Sleep(500);
            appiumDriver.FindElementByXPath($"//*[@text=\"{numberOfGuests}\"]").Click();
            appiumDriver.FindElementByXPath("//*[@text=\"OK\"]").Click();
            Thread.Sleep(500);
            //throw new PendingStepException();
        }

        [When(@"I search and select the item '([^']*)'")]
        public void WhenISearchAndSelectTheItem(string itemName)
        {
            Thread.Sleep(500);
            appiumDriver.FindElementById("com.ncr.AlohaMobile:id/btnSearch").Click();
            Thread.Sleep(500);
            appiumDriver.FindElementById("android:id/search_src_text").SendKeys(itemName);
            Thread.Sleep(500);
            appiumDriver.FindElementByXPath($"//android.widget.TextView[@class='android.widget.TextView' and @text='{itemName}']").Click();
            Thread.Sleep(500);
            appiumDriver.FindElementByAccessibilityId("Open navigation drawer").Click();
            Thread.Sleep(500);
        }

        [When(@"I validate that the item '([^']*)' has been added")]
        public void WhenIValidateThatTheItemHasBeenAdded(string itemToValidate)
        {
            Thread.Sleep(1500);
            bool elemnetFound = appiumDriver.FindElements(By.XPath($"//*[contains(@text,\"{itemToValidate}\")]")).Count > 0;
            Assert.AreEqual(true, elemnetFound);
            Thread.Sleep(500);
        }


        [Then(@"I pay with exact cash and close the order")]
        public void ThenIPayIPayWthExactCashAndCloseTheOrder()
        {
            Thread.Sleep(500);
            retryAndTouchElement("//android.widget.Button[@text='Pay']");
            //appiumDriver.FindElementByXPath("//android.widget.Button[@text='Pay']").Click();

            //click exact
            Thread.Sleep(500);
            retryAndTouchElement("//*[@text=\"Exact\"]");

            //click close
            Thread.Sleep(500);
            retryAndTouchElement("//android.widget.Button[@text='Close']");

            Thread.Sleep(500);
        }

        [Then(@"I pay with exact cash and generate receipt")]
        public void ThenIPayIPayWthExactCashAndGenerateReceipt()
        {
            Thread.Sleep(500);
            appiumDriver.FindElementByXPath("//android.widget.Button[@text='Pay']").Click();
            Thread.Sleep(1500);
            //click exact
            appiumDriver.FindElementByXPath("//*[@text=\"Exact\"]").Click();
            Thread.Sleep(1500);
            //click receipt
            appiumDriver.FindElementByXPath("//*[@text=\"Receipt\"]").Click();
            Thread.Sleep(1500);
            //click skip
            appiumDriver.FindElementByXPath("//*[@text=\"Skip\"]").Click();
            Thread.Sleep(1500);
            //checking for message element
            bool messageElementFound = appiumDriver.FindElementsByXPath("//*[@text=\"Thank you for your business, please come again!\"]").Count > 0;
            Assert.AreEqual(true, messageElementFound);
        }


        [Then(@"I remove item and close the order")]
        public void ThenIPayAndCompleteTheOrder()
        {
            Thread.Sleep(500);
            appiumDriver.FindElementByXPath("//android.widget.Button[@text='Pay']").Click();
            Thread.Sleep(500);
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

        [Then(@"I verify that table '([^']*)' is available")]
        public void ThenIVerifyThatTableIsAvailable(string tableToVerify)
        {
            Thread.Sleep(2500);
            appiumDriver.FindElementById("com.ncr.AlohaMobile:id/btnAddTable").Click();
            Thread.Sleep(500);
            bool elemnetFound = appiumDriver.FindElements(By.XPath($"//*[@text=\"{tableToVerify}\"]")).Count > 0;
            Assert.AreEqual(true, elemnetFound);
            Thread.Sleep(500);
            appiumDriver.FindElementByAccessibilityId("Open navigation drawer").Click();
            Thread.Sleep(500);
        }

        public void retryAndTouchElement(string xpath)
        {
            int retryCount = 10;
            while (retryCount > 0)
            {
                retryCount = retryCount - 1;
                var elements = appiumDriver.FindElementsByXPath(xpath);
                if (elements.Count > 0)
                {
                    var element = appiumDriver.FindElementByXPath(xpath);
                    if (element.Displayed)
                    {
                        element.Click();
                        break;
                    }
                    
                }
                Thread.Sleep(1000);
            }
            return;
        }

    }
}
