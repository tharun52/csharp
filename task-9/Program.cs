using System;
using System.Reflection;

public class Program
{
    public static void Main()
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();

        foreach (var type in types)
        {
            object? obj = Activator.CreateInstance(type);

            foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance))
            {
                var hasRunnable = method.GetCustomAttribute(typeof(Runnable)) != null;

                if (hasRunnable)
                {
                    Console.WriteLine($"Running {type.Name}.{method.Name}()");
                    method.Invoke(obj, null); 
                }
            }
        }
    }
}
