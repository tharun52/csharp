using System;

public class HelloWorld
{
    [Runnable]  // This method runs
    public void SayHello()
    {
        Console.WriteLine("Hello from HelloWorld!");
    }

    public void NotMarked() // This method does not run
    {
        Console.WriteLine("You should not see this.");
    }
}

public class MathOperations
{
    [Runnable] // This method runs
    public void ShowSquare()
    {
        Console.WriteLine("Square of 5 is " + (5 * 5));
    }
}
