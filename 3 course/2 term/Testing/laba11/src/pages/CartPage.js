const { Builder, By, until } = require("selenium-webdriver");
const Logger = require("../utils/logger");

class CartPage {
  constructor(driver) {
    this.driver = driver;
    this.logger = new Logger(driver);
  }

  async increase() {
    let parentElem = await this.driver.findElement(
      By.className("basket-item-amount-btn-plus")
    );

    await parentElem.click();
    this.logger.log("Amount of books increased");
  }

  async remove() {
    let parentElem = await this.driver.findElement(
      By.className("basket-item-block-actions")
    );

    await parentElem.click();
    this.logger.log("Book removed from cart");
  }

  async recover() {
    let parentElem = await this.driver.findElement(
      By.className("basket-items-list-item-removed-block")
    );

    let link = await parentElem.findElement(By.tagName("a"));

    await link.click();
    this.logger.log("Book recovered in cart");
  }

  async filter() {
    let parentElem = await this.driver.findElement(
      By.css(`[placeholder="Фильтр"]`)
    );

    await parentElem.click();
    const filterWord = "JoJo";
    await parentElem.sendKeys(filterWord);

    this.logger.log(`Books filtered by word ${filterWord}`);
  }
}

module.exports = CartPage;
