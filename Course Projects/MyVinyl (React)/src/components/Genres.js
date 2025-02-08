const GenresNotSorted = new Map([
  ["altRock", "Alternative rock"],
  ["indRock", "Industrial rock"],
  ["elRock", "Electronic rock"],
  ["pop", "Pop"],
  ["hRock", "Hard rock"],
  ["trMetall", "Trap-metal"],
  ["hCore", "Horrorcore"],
  ["rapRock", "Rap-rock"],
  ["hiphop", "Hip-hop"],
  ["rNb", "R&B"],
  ["rap", "Rap"],
  ["rock", "Rock"],
  ["psRap", "Psychedelic rap"],
  ["trap", "Trap"],
  ["hardcoreRap", "Hardcore rap"],
  ["emoRap", "Emo-rap"],
  ["mumbleRap", "Mumble-rap"],
  ["progrPop", "Progressive pop"],
  ["progrRock", "Progressive rock"],
  ["synthPunk", "Synth-punk"],
  ["dancePunk", "Dance-punk"],
  ["rockandroll", "Rock and roll"],
  ["dance", "Dance"],
  ["soul", "Soul"],
  ["funk", "Funk"],
]);

// Шаг 1: Преобразование Map в массив пар ключ-значение
const keyValueArray = Array.from(GenresNotSorted);

// Шаг 2: Сортировка массива по значениям
keyValueArray.sort((a, b) => a[1].localeCompare(b[1]));

// Шаг 3: Преобразование отсортированного массива обратно в Map
export const Genres = new Map(keyValueArray);
