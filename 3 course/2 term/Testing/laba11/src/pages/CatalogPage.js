const { Builder, By, until } = require("selenium-webdriver");
const Logger = require("../utils/logger");

class CatalogPage {
  constructor(driver) {
    this.driver = driver;
    this.logger = new Logger(driver);
  }

  async pickBook() {
    let parentElem = await this.driver.findElement(By.className("search-page"));

    const links = await parentElem.findElements(By.tagName("a"));

    await links[3].click();

    this.logger.log("Book picked in catalog");
  }

  async buyBookBtn() {
    let elem = await this.driver.findElement(
      By.className("btn btn-primary product-item-detail-buy-button")
    );

    await elem.click();

    this.logger.log("Book added to cart");
  }

  async removeBookBtn() {
    let elem = await this.driver.findElement(
      By.className("basket-item-actions-remove")
    );

    await elem.click();
    this.logger.log("Book removed from cart");
  }
}

module.exports = CatalogPage;
