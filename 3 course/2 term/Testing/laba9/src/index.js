const { Builder, By, Key, until } = require("selenium-webdriver");
const assert = require("assert");

async function runTest() {
  let driver = await new Builder().forBrowser("chrome").build();
  //let TestResult = false;
  try {
    await driver.get("https://www.aviasales.by/?params=MSQ1");

    await driver.manage().setTimeouts({ implicit: 5000 });

    await driver.findElement(By.className("s__To9mtJ4hfX3P2uQY3VJ2")).click();

    await driver.findElement(By.className("s__pYAhaCkOP9mPTxKVg5Qi")).click();

    await driver
      .findElement(
        By.className(
          "s__pYAhaCkOP9mPTxKVg5Qi s__cQ6neS4ccCunOu9Ydn0k s__zSP50jyzjUujJHLXoQTv s__eEClvAD7BnPrQbwBW5zC s__p0epgEYgBbKyjc8MfJPw s__TUdVliOmtbp7_LIhzKiv s__HwTb5X6L7z4nYKZUc1JL s__as8afAOIALrrFQENKabF"
        )
      )
      .click();

    let newWindow = await driver.wait(async () => {
      let windows = await driver.getAllWindowHandles();
      return windows.length > 1 ? windows[windows.length - 1] : null;
    }, 10000); // Таймаут ожидания в миллисекундах (10 секунд)

    // Переключиться на новое окно
    await driver.switchTo().window(newWindow);

    //await driver.findElement(By.className("VV3oRb YZVTmd SmR8"));

    //await driver.manage().setTimeouts({ implicit: 25000 });

    let elem = await driver.findElement(By.name("identifier"));
    await elem.sendKeys("palaznika608@gmail.com");

    await driver
      .findElement(
        By.className(
          "VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc LQeN7 BqKGqe Jskylb TrZEUc lw1w4b"
        )
      )
      .click();

    // await driver.findElement(
    //   By.className(
    //     "VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc LQeN7 BqKGqe Jskylb TrZEUc lw1w4b"
    //   )
    // );

    let elem2 = await driver.findElement(By.name("Passwd"));
    await elem2.sendKeys("K508a178y271");

    await driver.findElement(
      By.className(
        "VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc LQeN7 BqKGqe Jskylb TrZEUc lw1w4b"
      )
    );
  } finally {
    await driver.quit();
    //return TestResult;
  }
}

async function runTest2() {
  let driver = await new Builder().forBrowser("chrome").build();

  try {
    await driver.get("https://www.aviasales.by/?params=MSQ1");

    await driver.findElement(By.className("s__YlNPz3wu9X6GcpqSC9fj")).click();

    await driver.findElement(By.className("s__GpXZPGffa2DSeC3vCoSG")).click();

    //await driver.manage().setTimeouts({ implicit: 1500000 });
    await driver
      .findElement(
        By.className(
          "s__pYAhaCkOP9mPTxKVg5Qi s__cQ6neS4ccCunOu9Ydn0k s__tkvB9amX28GXeWxPcrad s__eEClvAD7BnPrQbwBW5zC s__p0epgEYgBbKyjc8MfJPw s__VtKkhjd_g3s0MVyvRx1g"
        )
      )
      .click();
  } finally {
    await driver.quit();
  }
}

describe("Aviasales Tests", function () {
  this.timeout(85000); // Установите допустимый таймаут

  it("Authorization complete", async () => {
    await runTest();
  });

  it("Change theme", async () => {
    await runTest2();
  });
});
