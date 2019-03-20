using System;
using System.Runtime.InteropServices;

namespace csharp_with_golang {
    class Program {
        static void Main(string[] args) {
            var ins = new UnManagedInterop();
            ins.Test("Hello Go!");// invoke callback -> go -> back to csharp
            ins.StartTimer();
            Console.ReadLine();
        }
    }
}

/// <summary>
/// 调用非托管代码
/// </summary>
class UnManagedInterop {
    private delegate void Callback(string text);
    private Callback mInstance;   // Ensure it doesn't get garbage collected

    /// <summary>
    /// 
    /// </summary>
    public UnManagedInterop() {
        mInstance = new Callback(Handler);
        SetCallback(mInstance);
    }
    /// <summary>
    /// 从csharp端调用csharp的回调函数
    /// </summary>
    /// <param name="text"></param>
    public void Test(string text) {
        TestCallback(text);
    }

    /// <summary>
    /// 启动go定时器，go定时调用csharp回调函数
    /// </summary>
    public void StartTimer() {
        StartGoTimer();
    }
    /// <summary>
    /// 回调函数
    /// </summary>
    /// <param name="text"></param>
    private void Handler(string text) {
        // Do something...
        Console.WriteLine("Handle:" + text);
    }
    [DllImport("go.dll")]
    private static extern void SetCallback(Callback fn);
    [DllImport("go.dll")]
    private static extern void TestCallback(string text);
    [DllImport("go.dll")]
    private static extern void StartGoTimer();
}

