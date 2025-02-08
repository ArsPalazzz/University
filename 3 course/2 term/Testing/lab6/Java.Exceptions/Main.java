// PS D:\Универ\6 семестр\AQA\Software-Testing\lab6\Java.Exceptions> javac Faculty.java Group.java Main.java Student.java Subject.java University.java
// PS D:\Универ\6 семестр\AQA\Software-Testing\lab6\Java.Exceptions> java Main

class GradeOutOfRangeException extends RuntimeException {
        public GradeOutOfRangeException(String message) {
                super(message);
        }
}

class NoSubjectsException extends RuntimeException {
        public NoSubjectsException(String message) {
                super(message);
        }
}

class NoStudentsInGroupException extends RuntimeException {
        public NoStudentsInGroupException(String message) {
                super(message);
        }
}

class NoGroupsInFacultyException extends RuntimeException {
        public NoGroupsInFacultyException(String message) {
                super(message);
        }
}

class NoFacultiesInUniversityException extends RuntimeException {
        public NoFacultiesInUniversityException(String message) {
                super(message);
        }
}

public class Main {
        public static void main(String[] args) {
                // Create a university
                University university = new University();

                // Create faculties
                Faculty faculty1 = new Faculty("Faculty of Information Technology");
                Faculty faculty2 = new Faculty("Faculty of Natural Sciences");

                // Add faculties to the university
                // Absence of faculties in the university (comment out the next 2 lines)
                university.addFaculty(faculty1);
                university.addFaculty(faculty2);

                // Create groups
                Group group1 = new Group("Group IT-1");
                Group group2 = new Group("Group NS-1");

                // Add groups to faculties
                // Absence of groups in the faculty (comment out the next 2 lines)
                faculty1.addGroup(group1);
                faculty2.addGroup(group2);

                // Create students
                Student student1 = new Student("Ivanov", group1);
                Student student2 = new Student("Petrov", group1);
                Student student3 = new Student("Sidorov", group2);

                // Add students to groups
                // Absence of students in the group (comment out the next 2 lines)
                group1.addStudent(student1);
                group1.addStudent(student2);
                group2.addStudent(student3);

                // Create subjects
                Subject subject1 = new Subject("Mathematics");
                Subject subject2 = new Subject("Physics");
                Subject subject3 = new Subject("Informatics");

                // Add subjects to students
                // Absence of subjects for the student (should be at least one) (comment out the next 2 lines)
                student1.addSubject(subject1);
                student1.addSubject(subject2);
                student2.addSubject(subject1);
                student3.addSubject(subject3);

                // Implement the following exceptions:

                // Grade below 0 or above 10
                // subject1.addGrade(-4);

                subject1.addGrade(10);
                subject1.addGrade(9);
                subject1.addGrade(8);

                subject2.addGrade(6);
                subject2.addGrade(7);
                subject2.addGrade(8);

                subject3.addGrade(6);
                subject3.addGrade(4);
                subject3.addGrade(8);

                // Calculate the average grade for all subjects of the student
                try {
                        double studentAverageGrade = student1.calculateAverageGrade();
                        System.out.println("Average grade of student " + student1.name + ": " + studentAverageGrade);
                } catch (NoSubjectsException e) {
                        System.out.println("Student " + student1.name + " has no subjects");
                }

                // Calculate the average grade by specific subject in a specific group and faculty
                try {
                        double subjectAverageGradeInGroup = group1.calculateAverageGradeBySubject(subject1);
                        System.out.println("Average grade for subject " + subject1.name + " in group "
                                        + group1.name + ": " + subjectAverageGradeInGroup);
                } catch (NoStudentsInGroupException e) {
                        System.out.println("There are no students in group " + group1.name);
                } catch (NoSubjectsException e) {
                        System.out.println("There are no students with subject " + subject1.name + " in group "
                                        + group1.name);
                }

                // Calculate the average grade by subject for the entire university
                try {
                        double subjectAverageGradeInUniversity = university.calculateAverageGradeBySubject(subject1);
                        System.out.println("Average grade for subject " + subject1.name + " in the university: "
                                        + subjectAverageGradeInUniversity);
                } catch (NoGroupsInFacultyException e) {
                        System.out.println("There are no groups in the faculty");
                } catch (NoFacultiesInUniversityException e) {
                        System.out.println("There are no faculties in the university");
                } catch (NoSubjectsException e) {
                        System.out.println("There are no groups with subject " + subject1.name + " in the university");
                }
        }
}
