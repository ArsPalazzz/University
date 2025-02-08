import java.util.Scanner;

public class MonthName {
    public static void main(String[] args) {
        // Create a Scanner object to read user input
        Scanner scanner = new Scanner(System.in);

        // Ask the user to enter a number from 1 to 12
        int monthNumber;
        do {
            System.out.print("Enter a number from 1 to 12: ");
            while (!scanner.hasNextInt()) {
                System.out.println("Incorrect input. Please enter a number from 1 to 12.");
                System.out.print("Enter a number from 1 to 12: ");
                scanner.next();
            }
            monthNumber = scanner.nextInt();
        } while (monthNumber < 1 || monthNumber > 12);

        // Determine the name of the month
        String monthName;
        switch (monthNumber) {
            case 1:
                monthName = "January";
                break;
            case 2:
                monthName = "February";
                break;
            case 3:
                monthName = "March";
                break;
            case 4:
                monthName = "April";
                break;
            case 5:
                monthName = "May";
                break;
            case 6:
                monthName = "June";
                break;
            case 7:
                monthName = "July";
                break;
            case 8:
                monthName = "August";
                break;
            case 9:
                monthName = "September";
                break;
            case 10:
                monthName = "October";
                break;
            case 11:
                monthName = "November";
                break;
            case 12:
                monthName = "December";
                break;
            default:
                monthName = "Invalid month";
                break;
        }

        // Print the name of the month to the console
        System.out.println("Month name: " + monthName);
    }
}
