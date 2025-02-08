import java.util.ArrayList;
import java.util.List;

class University {
    private List<Faculty> faculties;

    public University() {
        this.faculties = new ArrayList<>();
    }

    public void addFaculty(Faculty faculty) {
        faculties.add(faculty);
    }

    public double calculateAverageGradeBySubject(Subject subject) {
    if (faculties.isEmpty()) {
        throw new IllegalStateException("There are no faculties in the university");
    }
    double sum = 0;
    int count = 0;
    for (Faculty faculty : faculties) {
        try {
            sum += faculty.calculateAverageGradeBySubject(subject);
            count++;
        } catch (IllegalStateException e) {
            // Skipping faculties without groups for this subject
        }
    }
    if (count == 0) {
        throw new IllegalStateException("There are no groups in the university for this subject");
    }
    return sum / count;
}

}
