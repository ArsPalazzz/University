const HomePage = require("../pages/HomePage");
const LoginPage = require("../pages/LoginPage");
const CatalogPage = require("../pages/CatalogPage");
const CartPage = require("../pages/CartPage");
const { createDriver } = require("../driver/WebDriver");

describe("Catalog page Tests", function () {
  this.timeout(85000);
  let driver;

  it("Add book to cart", async () => {
    driver = await createDriver();
    let catalogPage = new CatalogPage(driver);
    let homePage = new HomePage(driver);

    try {
      await homePage.open();
      await homePage.findBookBtn();
      await catalogPage.pickBook();
      await catalogPage.buyBookBtn();

      await driver.sleep(4000);
    } catch (error) {
      console.log(error);
    } finally {
      await driver.quit();
    }
  });

  it("Increase amount of books in cart", async () => {
    driver = await createDriver();
    let catalogPage = new CatalogPage(driver);
    let homePage = new HomePage(driver);
    let cartPage = new CartPage(driver);

    try {
      await homePage.open();
      await homePage.findBookBtn();
      await catalogPage.pickBook();
      await catalogPage.buyBookBtn();

      await driver.sleep(4000);

      await cartPage.increase();

      await driver.sleep(4000);
    } catch (error) {
      console.log(error);
    } finally {
      await driver.quit();
    }
  });

  it("Delete book from cart", async () => {
    driver = await createDriver();

    let catalogPage = new CatalogPage(driver);
    let homePage = new HomePage(driver);
    let cartPage = new CartPage(driver);

    try {
      await homePage.open();
      await homePage.findBookBtn();
      await catalogPage.pickBook();
      await catalogPage.buyBookBtn();

      await driver.sleep(4000);

      await cartPage.increase();
      await driver.sleep(2000);
      await cartPage.remove();

      await driver.sleep(4000);
    } catch (error) {
      console.log(error);
    } finally {
      await driver.quit();
    }
  });

  it("Recover book from cart", async () => {
    driver = await createDriver();

    let catalogPage = new CatalogPage(driver);
    let homePage = new HomePage(driver);
    let cartPage = new CartPage(driver);

    try {
      await homePage.open();
      await homePage.findBookBtn();
      await catalogPage.pickBook();
      await catalogPage.buyBookBtn();

      await driver.sleep(4000);

      await cartPage.increase();
      await driver.sleep(2000);
      await cartPage.remove();

      await driver.sleep(2000);
      await cartPage.recover();

      await driver.sleep(4000);
    } catch (error) {
      console.log(error);
    } finally {
      await driver.quit();
    }
  });

  it("Filter books in cart", async () => {
    driver = await createDriver();

    let catalogPage = new CatalogPage(driver);
    let homePage = new HomePage(driver);
    let cartPage = new CartPage(driver);

    try {
      await homePage.open();
      await homePage.findBookBtn();
      await catalogPage.pickBook();
      await catalogPage.buyBookBtn();

      await driver.sleep(4000);

      await cartPage.filter();

      await driver.sleep(4000);
    } catch (error) {
      console.log(error);
    } finally {
      await driver.quit();
    }
  });
});
