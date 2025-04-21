# 📟 Threshold Counter App (C# Delegates & Events)

A simple console-based application that demonstrates the use of **delegates**, **events**, and **event handlers** in C#. This app simulates a counter that triggers one or more actions when a defined threshold is reached.

---

## 🎯 Features

- Counts numbers in a loop.
- Triggers an **event** when the count reaches a defined threshold.
- Supports multiple **event handler** methods.
- Demonstrates how **delegates and events** decouple producers and consumers in C#.

---

## 🧠 Concepts Covered

- **Delegates**: A type-safe way to reference methods.
- **Events**: A way to notify other classes when something happens.
- **Event Handlers**: Methods that react to an event.

---

## 🚀 How It Works

1. `Counter` is initialized with a threshold (e.g., 5).
2. The app loops and adds `1` to the count each time.
3. When the count reaches or exceeds the threshold:
   - An event is triggered.
   - All subscribed event handler methods are called.

---

## 🧪 Sample Output

```
Current count: 1
Current count: 2
Current count: 3
Current count: 4
Current count: 5
>>> ALERT: Threshold reached!
>>> LOG: Counter crossed the limit.
Current count: 6
...
```

---
