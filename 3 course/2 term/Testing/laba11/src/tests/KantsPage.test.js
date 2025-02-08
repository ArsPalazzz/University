const HomePage = require("../pages/HomePage");
const LoginPage = require("../pages/LoginPage");
const KantsPage = require("../pages/KantsPage");
const { createDriver } = require("../driver/WebDriver");

describe("Kants Page Tests", function () {
  this.timeout(85000);
  let driver;
  let homePage;

  it("Change pagination", async () => {
    driver = await createDriver();
    let kantsPage = new KantsPage(driver);

    try {
      homePage = new HomePage(driver);
      kantsPage = new KantsPage(driver);

      await homePage.open();

      await homePage.kantsButton();
      await kantsPage.toSecondPaginationPage();

      await driver.sleep(3000);

      await kantsPage.toThirdPaginationPage();

      await driver.sleep(5000);
    } catch (error) {
      console.log(error);
    } finally {
      await driver.quit();
    }
  });
});
