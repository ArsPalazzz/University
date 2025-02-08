public class SumAndProduct {
    public static void main(String[] args) {
        // Check if command-line arguments exist
        if (args.length == 0) {
            System.out.println("No command-line arguments for counting.");
            return;
        }

        // Initialize variables for sum and product
        int sum = 0;
        int product = 1;

        // Iterate through each command-line argument
        for (int i = 0; i < args.length; i++) {
            // Parse the current argument into an integer
            try {
                int num = Integer.parseInt(args[i]);
                // Add the number to the sum
                sum += num;
                // Multiply the number by the product
                product *= num;
            } catch (NumberFormatException e) {
                // In case of number format error, print a message and move to the next argument
                System.out.println("Incorrect number format: " + args[i]);
            }
        }

        // Print the results to the console
        System.out.println("Sum of numbers: " + sum);
        System.out.println("Multiply of numbers: " + product);
    }
}
