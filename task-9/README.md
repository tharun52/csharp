# C# Reflection and Custom Attributes Example

## Overview

This project demonstrates how to use **reflection** in C# to discover and execute methods that are marked with a **custom attribute**. The custom attribute is named `[Runnable]`, and only methods with this attribute are executed when the program runs. This allows you to dynamically run specific methods in your classes without needing to know their names in advance.

---

## Key Concepts

- **Custom Attributes**: A way to attach metadata to classes, methods, properties, etc.
- **Reflection**: A way for a program to examine and interact with its own structure (like classes, methods, and properties) during runtime.
- **Method Invocation**: Dynamically calling methods based on metadata.

---

## Files in the Project

1. **RunnableAttribute.cs**: Defines the custom attribute `[Runnable]`.
2. **SampleClasses.cs**: Contains sample classes with methods marked by `[Runnable]`.
3. **Program.cs**: Contains the reflection logic that discovers and runs methods marked with `[Runnable]`.

---

## How the Program Works

### 1. Custom Attribute `[Runnable]`

The program uses a **custom attribute** to mark methods that should be run. The `RunnableAttribute` class is defined as:

```csharp
[AttributeUsage(AttributeTargets.Method)]
public class RunnableAttribute : Attribute
{
}
```

This class does not contain any behavior, it just marks methods with the `[Runnable]` tag, telling the program, "This method should be executed."

### 2. Sample Classes with `[Runnable]` Methods

The `SampleClasses.cs` file contains classes with methods that are either marked with `[Runnable]` or not:

```csharp
public class HelloWorld
{
    [Runnable]  // This method is marked to be run
    public void SayHello()
    {
        Console.WriteLine("Hello from HelloWorld!");
    }

    public void NotMarked()
    {
        Console.WriteLine("You should not see this.");
    }
}
```

In this example:
- The method `SayHello()` is marked with `[Runnable]`, so it will be discovered and executed by the program.
- The method `NotMarked()` is **not marked** and will be ignored by the program.

### 3. Reflection to Discover and Invoke Methods

The `Program.cs` file is the main entry point that discovers and runs methods marked with `[Runnable]`. The key lines of code are:

```csharp
// Step 1: Get all types (classes) in the current project
var types = Assembly.GetExecutingAssembly().GetTypes();

// Step 2: Loop through each class and create an instance of it
foreach (var type in types)
{
    object? obj = Activator.CreateInstance(type);

    // Step 3: Loop through all methods in the class
    foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
    {
        // Step 4: Check if the method is marked with [Runnable]
        var hasRunnable = method.GetCustomAttribute(typeof(RunnableAttribute)) != null;

        // Step 5: If the method has [Runnable], invoke it
        if (hasRunnable)
        {
            Console.WriteLine($"Running {type.Name}.{method.Name}()");
            method.Invoke(obj, null); // Dynamically invoke the method
        }
    }
}
```

#### Important Code Sections:

1. **Get Types in the Assembly**:
   ```csharp
   var types = Assembly.GetExecutingAssembly().GetTypes();
   ```
   This retrieves all the classes in the current project.

2. **Create Instances of Classes**:
   ```csharp
   object? obj = Activator.CreateInstance(type);
   ```
   This dynamically creates an object of each class.

3. **Get Methods in Each Class**:
   ```csharp
   foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
   ```
   This gets all the public, instance methods that are declared in the class (ignoring inherited methods).

4. **Check for the `[Runnable]` Attribute**:
   ```csharp
   var hasRunnable = method.GetCustomAttribute(typeof(RunnableAttribute)) != null;
   ```
   This checks if the method has the `[Runnable]` attribute.

5. **Invoke the Method Dynamically**:
   ```csharp
   method.Invoke(obj, null);
   ```
   This line calls the method dynamically, running it on the object that was created earlier.

---

## Output Example

When you run the program, the output will look like:

```
Running HelloWorld.SayHello()
Hello from HelloWorld!
Running MathOperations.ShowSquare()
Square of 5 is 25
```

---