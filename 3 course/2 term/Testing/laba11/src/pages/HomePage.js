const { Builder, By, until } = require("selenium-webdriver");
const Logger = require("../utils/logger");

class HomePage {
  constructor(driver) {
    this.driver = driver;
    this.logger = new Logger(driver);
  }

  async open() {
    await this.driver.get("https://thebooks.by");
  }

  async findBookBtn() {
    let elem = await this.driver.findElement(By.id("title-search-input"));

    await elem.click();
    const word = "Peppa pig";
    await elem.sendKeys(word);

    await elem.sendKeys("\n");

    this.logger.log(`Book ${word} was written in search bar`);
  }

  async loginButton() {
    let elem = await this.driver.findElement(
      By.className("basket-line-block-icon-profile")
    );

    await elem.click();
    this.logger.log(`Login button was clicked`);
  }

  async registerButton() {
    let registryBlock = await this.driver.findElement(By.className(`registry`));

    let registerLink = await registryBlock.findElement(By.tagName("a"));
    await registerLink.click();
    this.logger.log(`Registry button was clicked`);
  }

  async markdownButton() {
    let elem = await this.driver.findElement(
      By.xpath(`//a[@href='/goods/markdown/']`)
    );

    await elem.click();
    this.logger.log(`Markdown button was clicked`);
  }

  async kantsButton() {
    let elem = await this.driver.findElement(
      By.xpath(`//a[@href='/goods/stationery/']`)
    );

    await elem.click();
    this.logger.log(`Stationery button was clicked`);
  }
}

module.exports = HomePage;
