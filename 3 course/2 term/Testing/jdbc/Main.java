// javac DBConnect.java Main.java

import java.sql.SQLException;

public class Main {
    public static void main(String[] args) {
        try {
            DBConnect connection = new DBConnect("localhost:5432/file_system", "postgres", "123");
            connection.getConnection();

            // Пример использования для получения пути каталога (предполагаем, что ID
            // каталога = 1)
            String directoryPath = connection.getFullPath(1, false);
            System.out.println("Полный путь каталога: " + directoryPath);

            // Пример использования для получения пути файла (предполагаем, что ID файла =
            // 1)
            String filePath = connection.getFullPath(1, true);
            System.out.println("Полный путь файла: " + filePath);

            connection.removeConnection();
        } catch (ClassNotFoundException | SQLException e) {
            e.printStackTrace();
        }
    }
}

// install posgresql
// pgAdmin - pass: 123