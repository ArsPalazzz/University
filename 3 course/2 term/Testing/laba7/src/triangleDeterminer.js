//jest
//jest --coverage

function isTriangle(side1, side2, side3) {
  if (
    typeof side1 !== "number" ||
    typeof side2 !== "number" ||
    typeof side3 !== "number" ||
    isNaN(side1) ||
    isNaN(side2) ||
    isNaN(side3) ||
    side1 <= 0 ||
    side2 <= 0 ||
    side3 <= 0
  ) {
    return false;
  }

  // Проверяем условие существования треугольника: сумма любых двух сторон должна быть больше третьей
  return (
    side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1
  );
}

module.exports = isTriangle;
