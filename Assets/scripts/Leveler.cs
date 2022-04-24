using UnityEngine;

public static class Leveler
{
    private static int level;
    private static int lenth;
    private static int width;
    private static int pupilCount;
    private static SceneLoader loader;
    private static float time;

    public static int Lenth { get { return lenth; } }
    public static int Width { get { return width; } }
    public static int PupilCount { get { return pupilCount; } }
    public static SceneLoader SceneLoader { get { return loader; } }
    public static float Time { get { return time; } }

    public static void Start(SceneLoader sceneLoader)
    {
        loader = sceneLoader;
        level = 2;
        lenth = level*3 + 20;
        width = level / 11 + 2;
        pupilCount =  lenth*width*4/(108-level);
        time = level*1.6f+40f;
    }
}
