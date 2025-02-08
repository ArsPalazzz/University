import java.sql.*;

public class DBConnect {
    private Connection connection;
    private String url;
    private String user;
    private String pass;

    public DBConnect(String url, String user, String pass) throws ClassNotFoundException {
        this.url = url;
        this.user = user;
        this.pass = pass;
    }

    public void getConnection() throws SQLException {
        connection = DriverManager.getConnection("jdbc:postgresql://" + url, user, pass);
        if (!connection.isClosed())
            System.out.println("Connection successful");
    }

    public void removeConnection() throws SQLException {
        System.out.println("Close connection");
        if (connection != null && !connection.isClosed()) {
            connection.close();
        }
    }

    public void closeStatement(Statement statement) throws SQLException {
        if (statement != null && !statement.isClosed()) {
            statement.close();
        }
    }

    // Метод для получения полного пути заданного файла или каталога
    public String getFullPath(int id, boolean isFile) throws SQLException {
        String path = isFile ? getFileName(id) : getDirectoryName(id);
        Integer parentId = getParentId(id, isFile);

        while (parentId != null) {
            String parentName = getDirectoryName(parentId);
            path = parentName + "/" + path;
            parentId = getParentId(parentId, false);
        }

        return "/" + path; // Предполагаем, что корень находится в "/"
    }

    private String getDirectoryName(int directoryId) throws SQLException {
        String sql = "SELECT name FROM directories WHERE id = ?";
        try (PreparedStatement preparedStatement = connection.prepareStatement(sql)) {
            preparedStatement.setInt(1, directoryId);
            ResultSet resultSet = preparedStatement.executeQuery();
            if (resultSet.next()) {
                return resultSet.getString("name");
            }
        }
        return null;
    }

    private String getFileName(int fileId) throws SQLException {
        String sql = "SELECT name, directory_id FROM files WHERE id = ?";
        try (PreparedStatement preparedStatement = connection.prepareStatement(sql)) {
            preparedStatement.setInt(1, fileId);
            ResultSet resultSet = preparedStatement.executeQuery();
            if (resultSet.next()) {
                return resultSet.getString("name");
            }
        }
        return null;
    }

    private Integer getParentId(int id, boolean isFile) throws SQLException {
        if (isFile) {
            String sql = "SELECT directory_id FROM files WHERE id = ?";
            try (PreparedStatement preparedStatement = connection.prepareStatement(sql)) {
                preparedStatement.setInt(1, id);
                ResultSet resultSet = preparedStatement.executeQuery();
                if (resultSet.next()) {
                    return resultSet.getInt("directory_id");
                }
            }
        } else {
            String sql = "SELECT parent_id FROM directories WHERE id = ?";
            try (PreparedStatement preparedStatement = connection.prepareStatement(sql)) {
                preparedStatement.setInt(1, id);
                ResultSet resultSet = preparedStatement.executeQuery();
                if (resultSet.next()) {
                    return (Integer) resultSet.getObject("parent_id"); // NULL будет обработан как null
                }
            }
        }
        return null;
    }
}
