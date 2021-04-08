using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CommmentBot
{
    [TestClass]
    public class SeleniumTests
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            var option = new ChromeOptions()
            {
                BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe"
            };

            //option.AddArgument("--headless");
            driver = new ChromeDriver(option);
            //driver = new ChromeDriver();
            baseURL = "https://www.instagram.com/";
        }

        [ClassCleanup]
        public static void CleanupClass()
        {
            try
            {
                //driver.Quit();// quit does not close the window
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        [TestInitialize]
        public void InitializeTest()
        {
            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void CommentTest()
        {
            driver.Navigate().GoToUrl("https://www.instagram.com/p/CM8Fqm6gRna/");

            var choice = true;
            do
            {
                try
                {
                    Thread.Sleep(2000);
                    //driver.FindElement(By.ClassName("Ypffh")).SendKeys("Vou ganhar heim!");
                    driver.FindElement(By.XPath("//textarea[@aria-label='Adicione um coment�rio...']")).SendKeys("Vou ganhar heim!!!");
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("//button[contains(text(),'Publicar')]")).Click();
                    Thread.Sleep(2000);
                }
                catch (Exception ex)
                {
                    driver.Navigate().Refresh();
                    Thread.Sleep(60000);
                    try
                    {
                        driver.FindElement(By.XPath("//textarea[@aria-label='Adicione um coment�rio...']")).SendKeys("!!!");
                        driver.FindElement(By.XPath("//button[contains(text(),'Publicar')]")).Click();
                        Thread.Sleep(2000);

                        driver.FindElement(By.XPath("//textarea[@aria-label='Adicione um coment�rio...']")).SendKeys("qualquer coisa");
                        driver.FindElement(By.XPath("//button[contains(text(),'Publicar')]")).Click();
                    }
                    catch (Exception)
                    {
                        driver.Navigate().Refresh();
                        Thread.Sleep(3000);
                        //driver.FindElement(By.XPath("//textarea[@aria-label='Adicione um coment�rio...']")).SendKeys("nunca ganhei um sorteio :/ kkkk");
                        //driver.FindElement(By.XPath("//button[contains(text(),'Publicar')]")).Click();
                    }
                }
                finally
                {
                    choice = true;
                }
            } while (choice);

            //driver.FindElement(By.Id("nome")).Click();
            //driver.FindElement(By.Id("nome")).Clear();
            //driver.FindElement(By.Id("nome")).SendKeys("Paulo");
            //driver.FindElement(By.Id("Sobrenome")).Clear();
            //driver.FindElement(By.Id("Sobrenome")).SendKeys("Pellizzari");
            //new SelectElement(driver.FindElement(By.Id("sexo"))).SelectByText("M");
            //new SelectElement(driver.FindElement(By.Id("sexo"))).SelectByText("F");
            //new SelectElement(driver.FindElement(By.Id("sexo"))).SelectByText("M");
            //driver.FindElement(By.Id("Telefone")).Click();
            //driver.FindElement(By.Id("Telefone")).Clear();
            //driver.FindElement(By.Id("Telefone")).SendKeys("16516516651");
            //driver.FindElement(By.Id("CPF")).Clear();
            //driver.FindElement(By.Id("CPF")).SendKeys("1231232131");
            //driver.FindElement(By.Id("CEP")).Clear();
            //driver.FindElement(By.Id("CEP")).SendKeys("5161651");
            //driver.FindElement(By.Id("Endereco")).Clear();
            //driver.FindElement(By.Id("Endereco")).SendKeys("Rau Xpto");
            //driver.FindElement(By.Id("Cidade")).Clear();
            //driver.FindElement(By.Id("Cidade")).SendKeys("Sao Paulo");
            //driver.FindElement(By.Id("Cargo")).Clear();
            //driver.FindElement(By.Id("Cargo")).SendKeys("Programador Senior");
            //driver.FindElement(By.Id("nomeMae")).Clear();
            //driver.FindElement(By.Id("nomeMae")).SendKeys("Joana");
            //driver.FindElement(By.Id("btnEnviar")).Click();
            //driver.FindElement(By.XPath("//html")).Click();

            //Assert.IsNotNull(driver.FindElement(By.XPath("//pre[contains(text(),'Sucesso')]")));
        }


        //[TestMethod]
        //public void TestSemCPF_ReturnFalse()
        //{
        //    driver.Navigate().GoToUrl("http://localhost:57959/");
        //    driver.FindElement(By.Id("nome")).Click();
        //    driver.FindElement(By.Id("nome")).Clear();
        //    driver.FindElement(By.Id("nome")).SendKeys("Paulo");
        //    driver.FindElement(By.Id("Sobrenome")).Clear();
        //    driver.FindElement(By.Id("Sobrenome")).SendKeys("Pellizzari");
        //    new SelectElement(driver.FindElement(By.Id("sexo"))).SelectByText("M");
        //    new SelectElement(driver.FindElement(By.Id("sexo"))).SelectByText("F");
        //    driver.FindElement(By.Id("Telefone")).Click();
        //    driver.FindElement(By.Id("Telefone")).Clear();
        //    driver.FindElement(By.Id("Telefone")).SendKeys("16516516651");
        //    driver.FindElement(By.Id("CPF")).Clear();
        //    driver.FindElement(By.Id("CPF")).SendKeys("");
        //    driver.FindElement(By.Id("CEP")).Clear();
        //    driver.FindElement(By.Id("CEP")).SendKeys("5161651");
        //    driver.FindElement(By.Id("Endereco")).Clear();
        //    driver.FindElement(By.Id("Endereco")).SendKeys("Rau Xpto");
        //    driver.FindElement(By.Id("Cidade")).Clear();
        //    driver.FindElement(By.Id("Cidade")).SendKeys("Sao Paulo");
        //    driver.FindElement(By.Id("Cargo")).Clear();
        //    driver.FindElement(By.Id("Cargo")).SendKeys("Programador Senior");
        //    driver.FindElement(By.Id("nomeMae")).Clear();
        //    driver.FindElement(By.Id("nomeMae")).SendKeys("Joana");
        //    driver.FindElement(By.Id("btnEnviar")).Click();
        //    driver.FindElement(By.XPath("//html")).Click();

        //    ITakesScreenshot camera = driver as ITakesScreenshot;
        //    Screenshot screenshot = camera.GetScreenshot();
        //    screenshot.SaveAsFile($"{Guid.NewGuid()}.png");

        //    Assert.IsNotNull(driver.FindElement(By.XPath("//pre[contains(text(),'Erro')]")));
        //}


        //[TestMethod]
        //public void Invasao_LoginTest()
        //{
        //    Logger.LogMessage("entrou no Teste: Descobrindo a senha");
        //    bool descobriuSenha = false;
        //    int senha = 90;
        //    driver.Navigate().GoToUrl("http://localhost:57959/Privacy");


        //    while (!descobriuSenha)
        //    {
        //        driver.FindElement(By.Id("Login")).Click();
        //        driver.FindElement(By.Id("Login")).Clear();
        //        driver.FindElement(By.Id("Login")).SendKeys("thiago");
        //        driver.FindElement(By.Id("Senha")).Click();
        //        driver.FindElement(By.Id("Senha")).Clear();
        //        driver.FindElement(By.Id("Senha")).SendKeys(senha.ToString());
        //        driver.FindElement(By.Id("btnLog")).Click();

        //        descobriuSenha = driver.FindElement(By.Id("msgLog")).Text.Contains("Parab�ns");

        //        if (!descobriuSenha)
        //            senha++;
        //    }

        //    Logger.LogMessage($"A senha � {senha}");

        //    Assert.IsTrue(descobriuSenha);


        //}


        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}