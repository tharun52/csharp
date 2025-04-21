public delegate void ThresholdReachedEventHandler(object sender, EventArgs e);


public class Counter
{
    public event ThresholdReachedEventHandler ThresholdReached;

    private int _threshold; // limit
    private int _count;     // current count

    public Counter(int threshold)
    {
        _threshold = threshold;
        _count = 0;
    }

    public void Add(int x)
    {
        _count += x;
        Console.WriteLine($"Current count: {_count}");

        if (_count >= _threshold)
        {
            // Raise the event
            OnThresholdReached(EventArgs.Empty);
        }
    }

    protected virtual void OnThresholdReached(EventArgs e)
    {
        // Call all attached event handlers
        ThresholdReached?.Invoke(this, e);
    }
}

public class HandlerClass
{
    public void Alert(object sender, EventArgs e)
    {
        Console.WriteLine(">>> ALERT: Threshold reached!");
    }

    public void Log(object sender, EventArgs e)
    {
        Console.WriteLine(">>> LOG: Counter crossed the limit.");
    }
}

class Program
{
    static void Main()
    {
        Counter counter = new Counter(5); // Set threshold to 5
        HandlerClass handler = new HandlerClass();

        // Attach event handler methods to the event
        counter.ThresholdReached += handler.Alert;
        counter.ThresholdReached += handler.Log;

        // Count from 1 to 10
        for (int i = 0; i < 10; i++)
        {
            counter.Add(1);
            System.Threading.Thread.Sleep(500); // Slow down the loop
        }
    }
}
