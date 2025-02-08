
// java Main D:/Study/Testing/lab6/output.txt
import java.io.*;
import java.nio.file.*;
import java.nio.file.attribute.BasicFileAttributes;
import java.util.*;

public class Main {

    public static void main(String[] args) {
        if (args.length == 0) {
            System.out.println("No args provided");
            return;
        }

        Path path = Paths.get(args[0]);
        if (Files.isDirectory(path)) {
            try {
                writeTreeStructureToFile(path, "directory_structure_enhanced.txt");
            } catch (IOException e) {
                System.err.println("Error writing directory structure: " + e.getMessage());
            }
        } else if (Files.isRegularFile(path) && args[0].endsWith(".txt")) {
            try {
                analyzeAndPrintFileStatistics(path);
            } catch (IOException e) {
                System.err.println("Error reading file statistics: " + e.getMessage());
            }
        } else {
            System.out.println("Invalid input path. Please provide a directory or a .txt file path.");
        }
    }

    private static void writeTreeStructureToFile(Path startPath, String outputPath) throws IOException {
        try (BufferedWriter writer = Files.newBufferedWriter(Paths.get(outputPath))) {
            Files.walkFileTree(startPath, new SimpleFileVisitor<Path>() {
                private final Deque<Integer> depthStack = new ArrayDeque<>(Collections.singleton(0));

                @Override
                public FileVisitResult preVisitDirectory(Path dir, BasicFileAttributes attrs) throws IOException {
                    writer.write(String.format("%s|-----%s%n", "    ".repeat(depthStack.peek()), dir.getFileName()));
                    depthStack.push(depthStack.pop() + 1);
                    return FileVisitResult.CONTINUE;
                }

                @Override
                public FileVisitResult visitFile(Path file, BasicFileAttributes attrs) throws IOException {
                    writer.write(String.format("%s%s%n", "    ".repeat(depthStack.peek()), file.getFileName()));
                    return FileVisitResult.CONTINUE;
                }

                @Override
                public FileVisitResult postVisitDirectory(Path dir, IOException exc) {
                    depthStack.pop();
                    if (!depthStack.isEmpty()) {
                        depthStack.push(depthStack.pop() - 1);
                    }
                    return FileVisitResult.CONTINUE;
                }
            });
        }
    }

    private static void analyzeAndPrintFileStatistics(Path filePath) throws IOException {
        int folderCount = 0;
        int fileCount = 0;
        int totalFileNameLength = 0;

        List<String> lines = Files.readAllLines(filePath);
        for (String line : lines) {
            if (line.contains("|-----")) {
                folderCount++;
            } else if (!line.trim().isEmpty() && !line.contains("|-----")) {
                fileCount++;
                totalFileNameLength += line.trim().length();
            }
        }

        double averageFilesPerFolder = folderCount > 0 ? (double) fileCount / folderCount : 0;
        double averageFileNameLength = fileCount > 0 ? (double) totalFileNameLength / fileCount : 0;

        System.out.printf("Folders: %d%n", folderCount);
        System.out.printf("Files: %d%n", fileCount);
        System.out.printf("Average files per folder: %.2f%n", averageFilesPerFolder);
        System.out.printf("Average file name length: %.2f%n", averageFileNameLength);
    }
}
