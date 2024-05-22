


// using EventSourcing;
// using EventSourcing.Events;

// var studentDatabase = new StudentDatabase();

// var studentId = Guid.Parse("410efa39-917b-45d4-83ff-f9a618d760a3");

// var studentCreated = new StudentCreated
// {

//     StudentId = studentId,
//     Email = "Alexmateoweb3@gmail.com",
//     FullName = "Alex Mathew",
//     DateOfBirth = new DateTime(1993, 1, 1)
// };

// studentDatabase.Append(studentCreated);


// var studentsEnrolled = new StudentEnrolled
// {

//     StudentId = studentId,
//     CourseName = "El curso de Alex Mathew"
// };

// studentDatabase.Append(studentsEnrolled);


// var studentUpdated = new StudentUpdated
// {

//     StudentId = studentId,
//     Email = "AlexMateoweb3@gmail.com",
//     FullName = "Alejandro Mateo",
//     CreatedAtUtc = DateTime.UtcNow
// };


// studentDatabase.Append(studentUpdated);

// var student = studentDatabase.GetStudent(studentId);

// var studentFromView = studentDatabase.GetStudentView(studentId);

// Console.WriteLine();

using System;
using EventSourcing;
using EventSourcing.Events;

class Program
{
    static void Main(string[] args)
    {
        var studentDatabase = new StudentDatabase();

        var studentId = Guid.Parse("410efa39-917b-45d4-83ff-f9a618d760a3");

        Console.WriteLine("Creating student...");
        var studentCreated = new StudentCreated
        {
            StudentId = studentId,
            Email = "Alexmateoweb3@gmail.com",
            FullName = "Alex Mathew",
            DateOfBirth = new DateTime(1993, 1, 1)
        };
        studentDatabase.Append(studentCreated);
        DisplayStudentState(studentDatabase, studentId);

        Console.WriteLine("Enrolling student in a course...");
        var studentsEnrolled = new StudentEnrolled
        {
            StudentId = studentId,
            CourseName = "El curso de Alex Mathew"
        };
        studentDatabase.Append(studentsEnrolled);
        DisplayStudentState(studentDatabase, studentId);

        Console.WriteLine("Updating student information...");
        var studentUpdated = new StudentUpdated
        {
            StudentId = studentId,
            Email = "AlexMateoNUEVOEMAIL.com",
            FullName = "Alejandro Mateo García-Gil"
        };
        studentDatabase.Append(studentUpdated);
        DisplayStudentState(studentDatabase, studentId);

        Console.WriteLine("Unenrolling student from a course...");
        var studentUnEnrolled = new StudentUnEnrolled
        {
            StudentId = studentId,
            CourseName = "El curso de Alex Mathew"
        };
        studentDatabase.Append(studentUnEnrolled);
        DisplayStudentState(studentDatabase, studentId);

        Console.WriteLine("Enrolling student in another course...");
        var studentEnrolledInAnotherCourse = new StudentEnrolled
        {
            StudentId = studentId,
            CourseName = "Nuevo curso de Alejandro Mateo"
        };
        studentDatabase.Append(studentEnrolledInAnotherCourse);
        DisplayStudentState(studentDatabase, studentId);

        // Inscribir un nuevo estudiante en un curso
        var newStudentId = Guid.NewGuid();
        Console.WriteLine("Creating a new student...");
        var newStudentCreated = new StudentCreated
        {
            StudentId = newStudentId,
            Email = "newstudent@example.com",
            FullName = "New Student",
            DateOfBirth = new DateTime(2000, 1, 1)
        };
        studentDatabase.Append(newStudentCreated);
        DisplayStudentState(studentDatabase, newStudentId);

        Console.WriteLine("Enrolling new student in a course...");
        var newStudentEnrolled = new StudentEnrolled
        {
            StudentId = newStudentId,
            CourseName = "Curso para nuevo estudiante"
        };
        studentDatabase.Append(newStudentEnrolled);
        DisplayStudentState(studentDatabase, newStudentId);

        Console.WriteLine("Final state of the original student:");
        DisplayStudentState(studentDatabase, studentId);

        Console.WriteLine("Final state of the new student:");
        DisplayStudentState(studentDatabase, newStudentId);

        Console.ReadLine();
    }

    static void DisplayStudentState(StudentDatabase studentDatabase, Guid studentId)
    {
        var student = studentDatabase.GetStudentView(studentId);
        if (student != null)
        {
            Console.WriteLine($"Student ID: {student.Id}");
            Console.WriteLine($"Name: {student.FullName}");
            Console.WriteLine($"Email: {student.Email}");
            Console.WriteLine($"Date of Birth: {student.DateOfBirth}");
            Console.WriteLine($"Enrolled Courses: {string.Join(", ", student.EnrolledCourses)}");
            Console.WriteLine(new string('-', 40));
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
}
