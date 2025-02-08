const { Builder, By, until } = require("selenium-webdriver");
const Logger = require("../utils/logger");

class LoginPage {
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

  async sendLoginFieldRegister() {
    let elem = await this.driver.findElement(By.name("REGISTER[LOGIN]"));

    await elem.click();
    const word = "MugOfDrux";
    await elem.sendKeys(word);
    this.logger.log(`Login register field filled with ${word}`);
  }

  async sendEmailFieldRegister() {
    let elem = await this.driver.findElement(By.name("REGISTER[EMAIL]"));

    await elem.click();
    const word = "palaznika609@gmail.com";
    await elem.sendKeys(word);
    this.logger.log(`Email register field filled with ${word}`);
  }

  async sendPassFieldRegister() {
    let elem = await this.driver.findElement(By.name("REGISTER[PASSWORD]"));

    await elem.click();

    const word = "Qwerty123";
    await elem.sendKeys(word);
    this.logger.log(`Password register field filled with ${word}`);
  }

  async sendConfirmPassFieldRegister() {
    let elem = await this.driver.findElement(
      By.name("REGISTER[CONFIRM_PASSWORD]")
    );

    await elem.click();
    const word = "Qwerty123";
    await elem.sendKeys(word);
    this.logger.log(`Password confirm register field filled with ${word}`);
  }

  async sendNameFieldRegister() {
    let elem = await this.driver.findElement(By.name("REGISTER[NAME]"));

    await elem.click();

    const word = "Arseniy";
    await elem.sendKeys(word);
    this.logger.log(`Name register field filled with ${word}`);
  }

  async sendPhoneFieldRegister() {
    let elem = await this.driver.findElement(
      By.name("REGISTER[PERSONAL_PHONE]")
    );

    await elem.click();
    const word = "375441111111";
    await elem.sendKeys(word);
    this.logger.log(`Phone register field filled with ${word}`);
  }

  async submitRegistration() {
    let elem = await this.driver.findElement(By.name("register_submit_button"));

    await elem.click();
    this.logger.log(`Submit registration button was clicked`);
  }
}

module.exports = LoginPage;
