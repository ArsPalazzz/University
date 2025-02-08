const { Builder, By, until } = require("selenium-webdriver");
const Logger = require("../utils/logger");

class KantsPage {
  constructor(driver) {
    this.driver = driver;
    this.logger = new Logger(driver);
  }

  async sendNameField() {
    let elem = await this.driver.findElement(By.name("USER_LOGIN"));

    await elem.click();
    const word = "MugOfDrux";
    await elem.sendKeys(word);
    this.logger.log(`Login field filled with ${word}`);
  }

  async sendPassField() {
    let elem = await this.driver.findElement(By.name("USER_PASSWORD"));

    await elem.click();
    const word = "Qwerty123";
    await elem.sendKeys("Qwerty123");
    this.logger.log(`Pasword field filled with ${word}`);
  }

  async signInBtn() {
    let elem = await this.driver.findElement(By.name("AUTH_ACTION"));

    await elem.click();
    this.logger.log(`Sign in button was clicked`);
  }

  async fromCost() {
    let elem = await this.driver.findElement(
      By.className("min-price form-control form-control-sm")
    );

    await elem.click();
    const fromValue = 20;
    await elem.sendKeys(fromValue);
    this.logger.log(`From cost field filled with ${fromValue}`);
  }

  async toCost() {
    let elem = await this.driver.findElement(
      By.className("max-price form-control form-control-sm")
    );

    await elem.click();
    const toValue = 30;
    await elem.sendKeys(toValue);
    this.logger.log(`To cost field filled with ${toValue}`);
  }

  async applyFilters() {
    let elem = await this.driver.findElement(By.name("set_filter"));

    await elem.click();
    this.logger.log(`Apply filters button was clicked`);
  }

  async resetFilters() {
    let elem = await this.driver.findElement(By.name("del_filter"));

    await elem.click();
    this.logger.log(`Reset filters button was clicked`);
  }

  async toSecondPaginationPage() {
    let elem = await this.driver.findElement(
      By.xpath(`//a[@href='/goods/stationery/?PAGEN_1=2']`)
    );
    elem.click();
    this.logger.log(`Second pagination button was clicked`);
  }

  async toThirdPaginationPage() {
    let elem = await this.driver.findElement(
      By.xpath(`//a[@href='/goods/stationery/?PAGEN_1=3']`)
    );
    elem.click();
    this.logger.log(`Third pagination button was clicked`);
  }
}

module.exports = KantsPage;
