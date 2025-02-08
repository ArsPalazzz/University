import java.util.ArrayList;
import java.util.List;

class Faculty {
    private String name;
    private List<Group> groups;

    public Faculty(String name) {
        this.name = name;
        this.groups = new ArrayList<>();
    }

    public void addGroup(Group group) {
        groups.add(group);
    }

    public double calculateAverageGradeBySubject(Subject subject) {
        if (groups.isEmpty()) {
             throw new IllegalStateException("There are no groups in the faculty");
        }
        double sum = 0;
        int count = 0;
        for (Group group : groups) {
            try {
                sum += group.calculateAverageGradeBySubject(subject);
                count++;
            } catch (IllegalStateException e) {
                // Пропускаем группы без студентов по этому предмету
            }
        }
        if (count == 0) {
             throw new IllegalStateException("There are no groups with this subject in the faculty");
        }
        return sum / count;
    }
}