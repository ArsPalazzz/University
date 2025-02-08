import java.util.Random;

public class RandomNumbers {
    public static void main(String[] args) {
        // Set the number of random numbers to generate
        int count = 5; // Replace with the desired count

        // Create a Random object for generating random numbers
        Random random = new Random();

        // Print the specified number of random numbers with a new line
        System.out.println("Random numbers with a new line:");
        for (int i = 0; i < count; i++) {
            int randomNumber = random.nextInt(100); // Generate a random number from 0 to 99
            System.out.println(randomNumber);
        }

        // Print the specified number of random numbers without a new line
        System.out.println("Random numbers without a new line:");
        for (int i = 0; i < count; i++) {
            int randomNumber = random.nextInt(100); // Generate a random number from 0 to 99
            System.out.print(randomNumber + " ");
        }
    }
}

