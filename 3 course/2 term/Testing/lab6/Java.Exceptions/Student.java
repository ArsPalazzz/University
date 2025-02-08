import java.util.ArrayList;
import java.util.List;

class Student {
    public String name;
    private Group group;
    private List<Subject> subjects;

    public Student(String name, Group group) {
        this.name = name;
        this.group = group;
        this.subjects = new ArrayList<>();
    }

    public void addSubject(Subject subject) {
        subjects.add(subject);
    }

    public List<Subject> getSubjects() {
        return subjects;
    }

    public double calculateAverageGrade() {
        if (subjects.isEmpty()) {
              throw new IllegalStateException("The student has no subjects");
        }
        double sum = 0;
        for (Subject subject : subjects) {
            sum += subject.calculateAverageGrade();
        }
        return sum / subjects.size();
    }
}