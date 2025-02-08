const { createDriver } = require("../driver/WebDriver");
const HomePage = require("../pages/HomePage");
const LoginPage = require("../pages/LoginPage");
const CatalogPage = require("../pages/CatalogPage");
const MarkdownPage = require("../pages/MarkdownPage");

describe("Markdown page Tests", function () {
  this.timeout(85000);
  let driver;

  it("Test applying filters", async () => {
    driver = await createDriver();

    let catalogPage = new CatalogPage(driver);
    let homePage = new HomePage(driver);
    let markdownPage = new MarkdownPage(driver);

    try {
      await homePage.open();
      await homePage.markdownButton();
      await markdownPage.fromCost();
      await markdownPage.toCost();
      await markdownPage.applyFilters();

      await driver.sleep(5000);
    } catch (error) {
      console.log(error);
    } finally {
      await driver.quit();
    }
  });

  it("Test reseting filters", async () => {
    driver = await createDriver();

    let catalogPage = new CatalogPage(driver);
    let homePage = new HomePage(driver);
    let markdownPage = new MarkdownPage(driver);

    try {
      await homePage.open();
      await homePage.markdownButton();
      await markdownPage.fromCost();
      await markdownPage.toCost();
      await markdownPage.applyFilters();

      await driver.sleep(4000);

      await markdownPage.resetFilters();
      await driver.sleep(3000);
    } catch (error) {
      console.log(error);
    } finally {
      await driver.quit();
    }
  });
});
