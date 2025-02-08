public class ReverseCommandLineArgs {
    public static void main(String[] args) {
        // Check if command-line arguments exist
        if (args.length == 0) {
            System.out.println("No command-line arguments to display.");
            return;
        }

        // Print command-line arguments in reverse order
        System.out.println("Command-line arguments in reverse order:");
        for (int i = args.length - 1; i >= 0; i--) {
            System.out.println(args[i]);
        }
    }
}
