const fs = require("fs").promises;

class Logger {
  constructor(driver) {
    this.driver = driver;
  }

  async log(message) {
    const timestamp = new Date().toISOString();
    const logMessage = `${timestamp}: ${message}\n`;

    // Логируем сообщение в файл
    try {
      await fs.appendFile("src/log.txt", logMessage); // Записываем сообщение в файл
      console.log("Сообщение успешно записано в файл.");
    } catch (error) {
      console.error("Ошибка при записи сообщения в файл:", error);
    }
  }
}

module.exports = Logger;
