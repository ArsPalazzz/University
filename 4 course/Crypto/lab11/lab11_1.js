// Лабораторная работа №12: Поиск точек эллиптической кривой E751(-1, 1) для x от 36 до 70
// Язык программирования: JavaScript (Node.js)

// =============================
// Параметры эллиптической кривой E751(-1, 1)
// =============================

// Все параметры объявлены как BigInt для избежания ошибок типов
const a = -1n;     // Коэффициент a
const b = 1n;      // Коэффициент b
const p = 751n;    // Простое число p (модуль)
const xmin = 36n;  // Минимальное значение x
const xmax = 70n;  // Максимальное значение x

// =============================
// Основные функции
// =============================

// Быстрое возведение в степень по модулю (алгоритм "быстрого возведения в степень")
function modPow(base, exponent, modulus) {
    if (modulus === 1n) return 0n;
    let result = 1n;
    base = base % modulus;
    while (exponent > 0n) {
        if (exponent % 2n === 1n) { // Если нечетный
            result = (result * base) % modulus;
        }
        exponent = exponent >> 1n;   // Деление на 2
        base = (base * base) % modulus;
    }
    return result;
}

// Проверка, является ли число квадратным вычетом по модулю p с использованием критерия Эйлера
function isQuadraticResidue(ySquared, p) {
    const lhs = modPow(ySquared, (p - 1n) / 2n, p);
    return lhs === 1n;
}

// Поиск всех y, удовлетворяющих y^2 ≡ RHS mod p
function findYs(RHS, p) {
    const ys = [];
    for (let y = 0n; y < p; y++) {
        if (modPow(y, 2n, p) === RHS) {
            ys.push(y);
        }
    }
    return ys;
}

// Вычисление правой части уравнения кривой: RHS = x^3 - x + 1 mod p
function computeRHS(x, a, b, p) {
    return (modPow(x, 3n, p) + a * x + b) % p;
}

// Основная функция для поиска точек кривой в заданном диапазоне x
function findPoints(a, b, p, xmin, xmax) {
    const points = [];
    for (let x = xmin; x <= xmax; x++) {
        const RHS = computeRHS(x, a, b, p);
        // Проверяем, является ли RHS квадратным вычетом
        if (isQuadraticResidue(RHS, p)) {
            const ys = findYs(RHS, p);
            ys.forEach(y => {
                points.push({ x: Number(x), y: Number(y) });
            });
        }
    }
    return points;
}

// Запуск поиска точек
const pointsOnCurve = findPoints(a, b, p, xmin, xmax);

// Вывод результатов
if (pointsOnCurve.length === 0) {
    console.log(`Нет точек на кривой E${p}(${a}, ${b}) для x от ${xmin} до ${xmax}.`);
} else {
    console.log(`Точки эллиптической кривой E${p}(${a}, ${b}) для x от ${xmin} до ${xmax}:`);
    pointsOnCurve.forEach(point => {
        console.log(`(${point.x}, ${point.y})`);
    });
}
