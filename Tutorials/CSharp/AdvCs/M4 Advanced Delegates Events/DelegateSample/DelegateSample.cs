using System;
using System.IO;

// Declare a delegate type
internal delegate void Feedback(int value);

public sealed class DelegateSample
{
    public static void Execute()
    {
        StaticDelegateDemo();
        InstanceDelegateDemo();
    }

    private static void StaticDelegateDemo()
    {
        Console.WriteLine("----- Static Delegate Demo -----");
        Counter(1, 3, null);
        Counter(1, 3, FeedbackToConsole);
        Counter(1, 3, FeedbackToMsgBox); // "Program." is optional
    }

    private static void InstanceDelegateDemo()
    {
        Console.WriteLine("----- Instance Delegate Demo -----");
        var p = new DelegateSample();
        Counter(1, 3, p.FeedbackToFile);
    }

    private static void Counter(int from, int to, Feedback fb)
    {
        for (var val = from; val <= to; val++)
        {
            // If any callbacks are specified, call them
            if (fb != null)
                fb(val);
        }
    }

    private static void FeedbackToConsole(int value)
    {
        Console.WriteLine("Item=" + value);
    }

    private static void FeedbackToMsgBox(int value)
    {
        Console.WriteLine("Item=" + value);
    }

    private void FeedbackToFile(int value)
    {
        var sw = new StreamWriter("Status", true);
        sw.WriteLine("Item=" + value);
        sw.Close();
    }
}