using UnityEngine;
using System.Threading.Tasks;
using System;
public static class Timer
{
    public static float TimeLeft { get { return time; } }
    public static bool IsRuned{ get { return isTicked; } }

    private static float time;
    private static bool isTicked;
    private static EventHandler startHandler;
    private static EventHandler tickHandler;
    private static EventHandler endHandler;
    private static EventHandler finishHandler;

    public static void Start(float time) {
        isTicked = true;
        Timer.time = time;
        Tick();
        startHandler?.Invoke(null,new GeneralEventArgs<float>(time)) ;
    }
    private static async void Tick() {
        while (time > 0f)
        {
            if (!isTicked)
                return;
            await Task.Delay(10);
            time -= 0.01f;
            tickHandler?.Invoke(null, new GeneralEventArgs<float>(time));
        }

        //end
        time = 0f;
        endHandler?.Invoke(null,null);
    }
    public static void Finish(object finisher)
    {
        isTicked = false;
        finishHandler?.Invoke(finisher, new GeneralEventArgs<float>(time));
        time = 0f;
    }
    public static void AddActionToStart(EventHandler action)
        => startHandler += action;
    public static void AddActionToTick(EventHandler action) 
        => tickHandler += action;
    public static void AddActionToEnd(EventHandler action)
        => endHandler += action;
    public static void AddActionToFinish(EventHandler action)
        => finishHandler += action;
}
public class GeneralEventArgs<T> : EventArgs
{
    public T Value;
    public GeneralEventArgs(T value) => Value = value;
}
