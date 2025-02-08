const readline = require("readline-sync");

function main() {
  let c = 5;
  console.log(
    "Приложение для подсчёта НОД двух и трёх чисел, а также для поиска простых чисел"
  );

  while (c === 5) {
    console.log();
    console.log("Нажмите:");
    console.log("1 - Поиск НОД двух чисел");
    console.log("2 - Поиск НОД трёх чисел");
    console.log("3 - Поиск простых чисел от 1 до n");
    console.log("4 - Поиск простых чисел от m до n");
    console.log("0 - Выход из консоли");

    const selection = readline.question();

    switch (selection) {
      case "1":
        console.log("Поиск НОД двух чисел!");
        const a = parseInt(readline.question("a(>0): "), 10);
        const b = parseInt(readline.question("b(>0): "), 10);
        const result = nod(a, b);
        console.log("NOD:", result);
        break;
      case "2":
        console.log("Поиск НОД трёх чисел!");
        const x = parseInt(readline.question("x(>0): "), 10);
        const y = parseInt(readline.question("y(>0): "), 10);
        const z = parseInt(readline.question("z(>0): "), 10);
        const resultForThree = nodForThree(x, y, z);
        console.log("NOD для трёх чисел:", resultForThree);
        break;
      case "3":
        const n = parseInt(readline.question("n: "), 10);
        simple(n);
        break;
      case "4":
        const m = parseInt(readline.question("m: "), 10);
        const n2 = parseInt(readline.question("n: "), 10);
        simple2(m, n2);
        break;
      case "0":
        console.log("Выход из программы.");
        process.exit(0);
      default:
        console.log("Вы выбрали неизвестный вариант");
        break;
    }
  }
}

function nod(a, b) {
  if (a !== 0 && b !== 0) {
    if (a > b) {
      return nod(a % b, b);
    } else {
      return nod(a, b % a);
    }
  } else {
    return a + b;
  }
}

function nodForThree(a, b, c) {
  const nodAB = nod(a, b);
  return nod(nodAB, c);
}

function simple(z) {
  let num = [];
  for (let i = 2; i <= z; i++) {
    num.push(i);
  }

  for (let i = 0; i < num.length; i++) {
    for (let j = 2; num[i] * j <= z; j++) {
      const index = num.indexOf(num[i] * j);
      if (index !== -1) num.splice(index, 1);
    }
  }

  if (num.length > 0) {
    console.log(`Простые числа от 1 до ${z}:`);
    console.log(num.join("; ") + ";");
    console.log(`Количество простых чисел: ${num.length}`);
  } else {
    console.log("Простых чисел в данном диапазоне нет!!!");
  }
}

function simple2(m, z) {
  let num = [];
  for (let i = 2; i <= z; i++) {
    num.push(i);
  }

  for (let i = 0; i < num.length; i++) {
    for (let j = 2; num[i] * j <= z; j++) {
      const index = num.indexOf(num[i] * j);
      if (index !== -1) num.splice(index, 1);
    }
  }

  const primesInRange = num.filter((w) => w > m);

  if (primesInRange.length > 0) {
    console.log(`Простые числа от ${m} до ${z}:`);
    console.log(primesInRange.join("; ") + ";");
  } else {
    console.log("Простых чисел в данном диапазоне нет!!!");
  }
}

main();
