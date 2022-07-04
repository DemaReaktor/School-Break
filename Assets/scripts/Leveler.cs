using UnityEngine;

public static class Leveler
{
    private static int level;
    private static int lenth;
    private static int width;
    private static int pupilCount;
    private static SceneLoader loader;
    private static float time;

    public static int Lenth => lenth; 
    public static int Width => width; 
    public static int PupilCount => pupilCount; 
    public static SceneLoader SceneLoader => loader; 
    public static float Time => time; 

    public static void Start(SceneLoader sceneLoader)
    {
        loader = sceneLoader;
        level = 1;
        lenth = level*3 + 120;
        width = level / 11 + 2;
        pupilCount =  lenth*width*4/(108-level);
        time = level*1.6f+40f;
    }
}
