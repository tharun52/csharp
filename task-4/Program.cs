public class Student(string name, int grade, int age)
{
    public string Name { get; } = name;
    public int Grade { get; } = grade;
    public int Age { get; } = age;
}



internal class Program
{
    public static void Main(string[] args)
    {
        var s1 = new Student("John", 9, 21);
        var s2 = new Student("Bruce", 7, 23);
        var s3 = new Student("Jack", 8, 27);
        var s4 = new Student("Tony", 5, 19);

        List<Student> students = [s1, s2, s3, s4];


        IEnumerable<Student> studentQuery =
            from stud in students
            where stud.Grade > 5
            orderby stud.Age
            select stud;

        foreach (Student s in studentQuery)
        {
            Console.WriteLine($"Name : {s.Name}\tGrade : {s.Age}\tAge : {s.Age}");
        }

    }
}
