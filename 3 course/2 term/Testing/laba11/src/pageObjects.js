// const { Builder, By, until } = require("selenium-webdriver");

// class AviasalesHomePage {
//   constructor(driver) {
//     this.driver = driver;
//   }

//   async open() {
//     await this.driver.get("https://www.aviasales.by/?params=MSQ1");
//   }

//   async clickChangeTheme() {
//     await this.driver
//       .findElement(
//         By.className("s__yL9sDjhz6ndaRdJgBqvD s__Wcr1Yju5LqobArDS2yOA")
//       )
//       .click();
//   }

//   async clickAllCurrency() {
//     let allCurrencyBtn = await this.driver.findElement(
//       By.className("s__RSKC3cGxBSRB6WRCiPzC")
//     );
//     await allCurrencyBtn.click();
//   }

//   async clickUsdCurrency() {
//     let usdCurrencyBtn = await this.driver.findElement(
//       By.xpath(
//         "//*[contains(@class, 's__T9O5PZmfCrw2_31Rf8It s__eOL6Mcf34DUOC_LE_BF4')]/li[5]"
//       )
//     );
//     await usdCurrencyBtn.click();
//   }

//   async clickDestinationCity() {
//     let destinationCityBtn = await this.driver.findElement(
//       By.id("avia_form_destination-input")
//     );
//     await destinationCityBtn.click();
//     await destinationCityBtn.sendKeys("Москва");
//   }

//   //could you find the element by data-test-id="start-date-field" and click on it
//   async clickStartDateField() {
//     let startDateField = await this.driver.findElement(
//       By.xpath("//*[@data-test-id='start-date-field']")
//     );
//     await startDateField.click();
//   }
//   async clickDepartmentTime() {
//     const departmentTimeBtn = await this.driver.findElement(
//       By.className(
//         "s__iUCZVK_7pftNPmX5zeoS s__IwBVpRef_1GpuUeZuKUL s__QOH8_RMDyCm4BxeyrqOt s__OIqaFwbhkZg2cIA5d0zJ"
//       )
//     );
//     await departmentTimeBtn.click();

//     // const fromTimeBtn = await this.driver
//     //   .findElement(
//     //     By.xpath(/html/body/form/div/div/div/ul/li[2]/a/span[2]
//     //       "//*[contains(@class, 's__MyDSHR1cJnB4PdGBmvLm')]/div[1]/div[2]/div[0]/div[3]/div"
//     //     )
//     //   )
//     //   .click();

//     //@FindBy(xpath = "//*[@id='comp_5c11fd50eca000304bc4c3616bab9880']/div/form/div[1]/div[1]/input")

//     const toTimeBtn = await this.driver
//       .findElement(
//         By.xpath(
//           "//*[contains(@class, 's__MyDSHR1cJnB4PdGBmvLm')]/div[1]/div[2]/div[0]/div[5]/div"
//         )
//       )
//       .click();

//     //await departmentTimeBtn.sendKeys("Москва");
//   }

//   //write me a method where you find elementwith area-label="Thu May 02 2024" and click on it
//   async clickFromDateElement() {
//     let secondElement = await this.driver.wait(
//       until.elementLocated(By.css('[aria-label="Thu May 02 2024"]'))
//     );
//     await secondElement.click();
//   }

//   async clickToDateElement() {
//     let secondElement = await this.driver.wait(
//       until.elementLocated(By.css('[aria-label="Sun May 05 2024"]'))
//     );
//     await secondElement.click();
//   }

//   //find the element by data-test-id="form-submit" and click on it
//   async clickSearchButton() {
//     let searchButton = await this.driver.findElement(
//       By.xpath("//*[@data-test-id='form-submit']")
//     );
//     await searchButton.click();
//   }
// }

// class LoginPage {
//   constructor(driver) {
//     this.driver = driver;
//   }

//   async switchToNewWindow() {
//     let newWindowHandle = await this.driver.wait(async () => {
//       let windowHandles = await this.driver.getAllWindowHandles();
//       return windowHandles.length > 1
//         ? windowHandles[windowHandles.length - 1]
//         : null;
//     }, 10000); // 10 секунд таймаут

//     await this.driver.switchTo().window(newWindowHandle);
//   }

//   async enterEmail(email) {
//     let emailInput = await this.driver.findElement(By.name("identifier"));
//     await emailInput.sendKeys(email);
//   }

//   async clickNextButton() {
//     await this.driver.findElement(By.className("VfPpkd-LgbsSe")).click();
//   }

//   async enterPassword(password) {
//     let passwordInput = await this.driver.findElement(By.name("password"));
//     await passwordInput.sendKeys(password);
//   }

//   async clickSignInButton() {
//     await this.driver.findElement(By.className("VfPpkd-LgbsSe")).click();
//   }
// }

// // Теперь добавим тестовые методы

// async function runTest(driver) {
//   let aviasalesHomePage = new AviasalesHomePage(driver);
//   await aviasalesHomePage.open();
//   //await aviasalesHomePage.clickOriginCity();
//   //await aviasalesHomePage.clickDestinationCity();
//   //await aviasalesHomePage.clickDepartmentTime();
//   await aviasalesHomePage.clickAllCurrency();
//   await aviasalesHomePage.clickUsdCurrency();
//   //make a delay for 3 seconds
//   await new Promise((resolve) => setTimeout(resolve, 5000));
//   // await aviasalesHomePage.clickSearchButton();
// }

// async function runTest2(driver) {
//   let aviasalesHomePage = new AviasalesHomePage(driver);
//   await aviasalesHomePage.open();
//   await aviasalesHomePage.clickChangeTheme();
//   await new Promise((resolve) => setTimeout(resolve, 5000));
// }

// async function runTest3(driver) {
//   let aviasalesHomePage = new AviasalesHomePage(driver);
//   await aviasalesHomePage.open();
//   await aviasalesHomePage.clickDestinationCity();
//   await aviasalesHomePage.clickStartDateField();
//   await aviasalesHomePage.clickFromDateElement();
//   await aviasalesHomePage.clickToDateElement();
//   await new Promise((resolve) => setTimeout(resolve, 2000));
//   await aviasalesHomePage.clickSearchButton();
//   await new Promise((resolve) => setTimeout(resolve, 5000));
// }

// module.exports = {
//   runTest,
//   runTest2,
//   runTest3,
// };
