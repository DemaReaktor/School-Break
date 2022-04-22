using UnityEngine;
//using System.Threading;
using System.Threading.Tasks;

public static class Timer
{
    public static float TimeLeft { get { return time; } }

    private static float time=0;
    private static bool isTicked=false;

    public static void Start(float time) {
        isTicked = true;
        Timer.time = time;
        Tick();
    }
    private static async void Tick() {
        while (time > 0f)
        {
            if (!isTicked)
                return;
            await Task.Delay(10);
            time -= 0.01f;
        }

        //end
        time = 0f;
    }
    public static void Finish()
    {
        time = 0f;
        isTicked = false;
    }
}
