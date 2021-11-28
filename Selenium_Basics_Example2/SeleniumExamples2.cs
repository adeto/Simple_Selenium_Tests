using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
    public class Selenium_Automation_Examples2
{
    IWebDriver driver;

    [SetUp]
    public void Setup()
    { 
        driver = new ChromeDriver();
    }

    [Test]
    public void Test_Search_for_QA_in_Wikipedia()
        {
        driver.Navigate().GoToUrl("https://wikipedia.org");
        driver.FindElement(By.CssSelector("#searchInput")).Click();
        driver.SwitchTo().ActiveElement().SendKeys("QA");
        driver.FindElement(By.CssSelector("#search-form > fieldset > button > i")).Click();

        var firstHeading = driver.FindElement(By.CssSelector("#firstHeading")).Text;
        Assert.AreEqual("QA", firstHeading);
        }
    [Test]
    public void Automated_Test_for_Summator_of_Numbers_App()
    {
        driver.Navigate().GoToUrl("https://sum-numbers.nakov.repl.co");
        driver.FindElement(By.CssSelector("#number1")).Click();
        driver.SwitchTo().ActiveElement().SendKeys("2");
        driver.FindElement(By.CssSelector("#number2")).Click();
        driver.SwitchTo().ActiveElement().SendKeys("14");
        driver.FindElement(By.CssSelector("#calcButton")).Click();


        var sum = driver.FindElement(By.CssSelector("#result")).Text;
        Assert.AreEqual("Sum: 16", sum);
    }
    [Test]
    public void Automated_Test_for_Reset_Button_Of_Summator_App()
    {
        driver.Navigate().GoToUrl("https://sum-numbers.nakov.repl.co");
        driver.FindElement(By.CssSelector("#number1")).Click();
        driver.SwitchTo().ActiveElement().SendKeys("2");
        driver.FindElement(By.CssSelector("#number2")).Click();
        driver.SwitchTo().ActiveElement().SendKeys("14");
        driver.FindElement(By.CssSelector("#calcButton")).Click();

        var sum = driver.FindElement(By.CssSelector("#result")).Text;
        Assert.AreEqual("Sum: 16", sum);

        driver.FindElement(By.CssSelector("#resetButton")).Click();
        Assert.IsEmpty("#number1");
        Assert.IsEmpty("#number2");
        Assert.IsEmpty("#result");

    }

    [Test]
    public void Automated_Test_Google_Search_for_selenium()
    {
        driver.Navigate().GoToUrl("https://google.com");
        driver.SwitchTo().Frame(0);

        driver.FindElement(By.CssSelector("#introAgreeButton")).Click();

        driver.FindElement(By.CssSelector("#tsf > div:nth-child(2) > div.A8SBwf > div.RNNXgb > div > div.a4bIc > input")).Click();
        driver.SwitchTo().ActiveElement().SendKeys("selenium");
        driver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);
        driver.FindElement(By.CssSelector("#rso > div:nth-child(1) > div > div.yuRUbf > a > h3 > span")).Click();

        Assert.AreEqual("https://www.selenium.dev/", driver.Url);
        Assert.AreEqual("SeleniumHQ Browser Automation", driver.Title);
    }
    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}