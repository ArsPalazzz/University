const isTriangle = require("../src/triangleDeterminer");

describe("Triangle Determiner", () => {
  // Тесты для случаев, когда треугольник существует
  describe("Valid Triangles", () => {
    it("should return true for valid triangle with sides 3, 4, 5", () => {
      expect(isTriangle(3, 4, 5)).toBe(true);
    });

    it("should return true for valid triangle with sides 5, 12, 13", () => {
      expect(isTriangle(5, 12, 13)).toBe(true);
    });

    it("should return true for valid triangle with sides 8, 15, 17", () => {
      expect(isTriangle(8, 15, 17)).toBe(true);
    });
  });

  // Тесты для случаев, когда треугольник не существует
  describe("Invalid Triangles", () => {
    it("should return false for sides 1, 1, 3", () => {
      expect(isTriangle(1, 1, 3)).toBe(false);
    });

    it("should return false for sides 0, 0, 0", () => {
      expect(isTriangle(0, 0, 0)).toBe(false);
    });

    it("should return false for sides 2, 4, 6", () => {
      expect(isTriangle(2, 4, 6)).toBe(false);
    });

    it("should return false if any side is negative", () => {
      expect(isTriangle(-1, 2, 3)).toBe(false);
    });

    it("should return false if any side is not a number", () => {
      expect(isTriangle("a", 2, 3)).toBe(false);
    });
  });

  // Тесты для граничных случаев
  describe("Edge Cases", () => {
    it("should return false for sides 1, 2, Infinity", () => {
      expect(isTriangle(1, 2, Infinity)).toBe(false);
    });

    it("should return false for sides 1, 2, NaN", () => {
      expect(isTriangle(1, 2, NaN)).toBe(false);
    });

    it("should return false for sides -1, 2, 3", () => {
      expect(isTriangle(-1, 2, 3)).toBe(false);
    });

    it("should return true for sides 1, 1, 1 (equilateral triangle)", () => {
      expect(isTriangle(1, 1, 1)).toBe(true);
    });

    it("should return true for sides 2, 2, 3 (isosceles triangle)", () => {
      expect(isTriangle(2, 2, 3)).toBe(true);
    });

    it("should return true for sides 3, 4, 5 (Pythagorean triple)", () => {
      expect(isTriangle(3, 4, 5)).toBe(true);
    });
  });
});
