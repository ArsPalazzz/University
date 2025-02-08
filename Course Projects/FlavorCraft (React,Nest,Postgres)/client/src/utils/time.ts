import dayjs from "dayjs";

export const fromMinutesToHours = (minutes: number) => {
  if (minutes < 60) return `${minutes}m`;

  return `${minutes / 60}h ${minutes % 60}m`;
};

export function fromPatternToMinutes(input: string): number {
  const regex = /(?:(\d+)h)?\s*(?:(\d+)min)?/i;
  const match = regex.exec(input);

  if (!match) {
    throw new Error("Invalid time format");
  }

  const hours = match[1] ? parseInt(match[1], 10) : 0;
  const minutes = match[2] ? parseInt(match[2], 10) : 0;

  return hours * 60 + minutes;
}

export const formatDateToLongString = (date: Date): string => {
  return dayjs(date).format("MMMM D, YYYY");
};
