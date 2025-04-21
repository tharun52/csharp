# AsyncAwait Console App

## 💡 Objective

To demonstrate asynchronous programming and multi-threading in C# using `async`, `await`, and `Task`. This application simulates fetching data concurrently from local and remote sources.

---

## 📋 Requirements Fulfilled

- ✅ Developed a **console application** that performs **multiple asynchronous operations concurrently**.
- ✅ Used `async` and `await` to simulate API calls and read from file.
- ✅ Aggregated results using `Task.WhenAll`.
- ✅ Handled potential exceptions using try-catch blocks (can be extended further).
  
---

## 🚀 Features

- **Local File Reading (Simulated Delay):**  
  Reads content from `data.txt` after a 1-second delay.

- **Remote API Call (Simulated Delay):**  
  Fetches data from `https://jsonplaceholder.typicode.com/posts/1` after a 2-second delay.

- **Result Aggregation:**  
  Combines and prints the results after both tasks complete.

---


## 🛠️ How It Works

```csharp
var tasks = new List<Task<string>> { Writelocaly(), TextfromURL(URL) };
var results = await Task.WhenAll(tasks);
```

- Both tasks (`Writelocaly()` and `TextfromURL(URL)`) are executed **asynchronously and concurrently**.
- Once **both are complete**, the results are **printed to the console**.

---

## 🧪 Sample Output

```
Hello world
Wrting a line locally ...
Writing txt from url...

--- Aggregated Results ---
Text in file : 
Presidio is a prominent digital systems integrator...
--------------------------
got the text from url
{
  "userId": 1,
  ...
}
--------------------------
```

---

