using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumSpecflowDemo.Drivers
{
    internal class AppiumDriver
    {
        public AppiumDriver<AppiumWebElement> Driver { get; set; }
        public AndroidDriver<AppiumWebElement> InitializeAppium()
        {
            var driverOptions = new AppiumOptions();
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "emulator-5554");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.NoReset, true);
            //driverOptions.AddAdditionalCapability("appPackage", "com.ncr.AlohaMobile");
            //driverOptions.AddAdditionalCapability("appActivity", "crc64d9654bb2b0029034.MainActivity");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.App, @"C:\\GitHub Repositories\\AppiumSpecflowDemo\\AppiumSpecflowDemo\\APK\\OrderPay.apk");

            //var AppiumService = new AppiumServiceBuilder().WithIPAddress("127.0.0.1").UsingPort(4723).Build();
            //or
            var AppiumService = new AppiumServiceBuilder().WithIPAddress("127.0.0.1").UsingAnyFreePort().Build();

            return new AndroidDriver<AppiumWebElement>(AppiumService, driverOptions);
            //return new AndroidDriver<AppiumWebElement>(new Uri("http://localhost:4723/wd/hub"), driverOptions);
        }
    }
}
