const CryptoJS = require("crypto-js");

// Новый 6-байтовый ключ
const keyArray = [61, 60, 23, 22, 21, 20];
// Преобразуем массив ключа в строку
const keyStr = keyArray.map((num) => String.fromCharCode(num)).join("");

// Произвольный текст для шифрования
const message = "Пример текста для шифрования";

// Функция для измерения времени выполнения
function measureExecutionTime(fn) {
  const start = process.hrtime.bigint();
  fn();
  const end = process.hrtime.bigint();
  return Number(end - start) / 1e6; // Время в миллисекундах
}

// Функция для RC4 шифрования и дешифрования
function encryptDecryptRC4(message, keyStr) {
  const encrypted = CryptoJS.RC4.encrypt(message, keyStr);
  const decrypted = CryptoJS.RC4.decrypt(encrypted, keyStr).toString(
    CryptoJS.enc.Utf8
  );

  console.log("Зашифрованное сообщение:", encrypted.toString());
  console.log("Расшифрованное сообщение:", decrypted);
}

// Оценка скорости генерации ПСП (примерная симуляция)
function randomPrimeGenerationTime() {
  measureExecutionTime(() => {
    for (let i = 0; i < 100000; i++) {
      Math.random(); // Симулируем генерацию случайных чисел
    }
  });
}

// Выполняем операции
console.log("Шифрование RC4 и дешифрование:");
encryptDecryptRC4(message, keyStr);

console.log("Оценка времени генерации ПСП:");
console.log(
  "Время генерации:",
  measureExecutionTime(randomPrimeGenerationTime),
  "мс"
);
