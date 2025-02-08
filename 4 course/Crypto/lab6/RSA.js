// Приложение 1: RSA Key Generation
const bigintCryptoUtils = require("bigint-crypto-utils");

// Задаём значение для e, часто используемое значение - 65537
const e = BigInt(65537);

async function generateRSAKeys() {
  // Генерация 256-битных простых чисел p и q
  const p = await bigintCryptoUtils.prime(256);
  const q = await bigintCryptoUtils.prime(256);

  // Вычисляем n = p * q
  const n = p * q;

  // Вычисляем функцию Эйлера φ(n) = (p - 1) * (q - 1)
  const phi = (p - BigInt(1)) * (q - BigInt(1));

  // Проверка на то, что e и φ(n) - взаимно просты
  if (bigintCryptoUtils.gcd(e, phi) !== BigInt(1)) {
    throw new Error("e и φ(n) должны быть взаимно простыми");
  }

  // Вычисляем d - закрытую экспоненту, используя обратный элемент по модулю φ(n)
  const d = bigintCryptoUtils.modInv(e, phi);

  console.log("256-битные простые числа p и q:");
  console.log("p:", p.toString());
  console.log("q:", q.toString());
  console.log("Модуль n:", n.toString());
  console.log("Открытая экспонента e:", e.toString());
  console.log("Закрытая экспонента d:", d.toString());
}

generateRSAKeys().catch(console.error);
