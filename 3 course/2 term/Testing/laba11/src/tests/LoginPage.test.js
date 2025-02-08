const { createDriver } = require("../driver/WebDriver");
const HomePage = require("../pages/HomePage");
const LoginPage = require("../pages/LoginPage");

describe("Login Page Tests", function () {
  this.timeout(85000);
  let driver;
  let homePage;

  it("Sign in", async () => {
    driver = await createDriver();

    try {
      homePage = new HomePage(driver);
      loginPage = new LoginPage(driver);

      await homePage.open();
      await homePage.loginButton();
      await loginPage.sendNameField();
      await loginPage.sendPassField();
      await loginPage.signInBtn();

      await driver.sleep(2000);
    } catch (error) {
      console.log(error);
    } finally {
      await driver.quit();
    }
  });

  it("Sign up", async () => {
    driver = await createDriver();

    try {
      homePage = new HomePage(driver);
      loginPage = new LoginPage(driver);

      await homePage.open();
      await homePage.registerButton();
      await loginPage.sendLoginFieldRegister();
      await loginPage.sendEmailFieldRegister();
      await loginPage.sendPassFieldRegister();
      await loginPage.sendConfirmPassFieldRegister();
      await loginPage.sendNameFieldRegister();
      await loginPage.sendPhoneFieldRegister();
      await loginPage.submitRegistration();

      await driver.sleep(4000);
    } catch (error) {
      console.log(error);
    } finally {
      await driver.quit();
    }
  });
});
