using UnityEngine;

public class Leveler
{
    [SerializeField] [Range(1,100)]
    private static int level;
    private static int lenth;
    private static int width;

    public static int Lenth { get { return lenth; } }
    public static int Width { get { return width; } }
    public static void Start()
    {
        level = 1;
        lenth = level*3 + 20;
        width = level / 10 + 3;
    }
}
