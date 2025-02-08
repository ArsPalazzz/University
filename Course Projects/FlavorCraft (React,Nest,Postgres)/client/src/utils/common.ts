export function calculateCalories(
  protein: number,
  fat: number,
  carbs: number
): number {
  const proteinCalories = protein * 4; // 1 грамм белка = 4 калории
  const fatCalories = fat * 9; // 1 грамм жира = 9 калорий
  const carbsCalories = carbs * 4; // 1 грамм углеводов = 4 калории

  return proteinCalories + fatCalories + carbsCalories;
}
