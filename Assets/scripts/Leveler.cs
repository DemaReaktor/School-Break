﻿using UnityEngine;

public class Leveler
{
    [SerializeField]
    [Range(1, 100)]
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
        width = level / 10 + 2;
        pupilCount =  (level-1)*3 + 1;
        time = lenth / Mathf.Sqrt(level);
    }
}
