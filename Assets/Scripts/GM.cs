using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tool {PENCIL,CROSS,ERASER};

public class GM : MonoBehaviour
{
    public static Tool activeTool;
    public static Level currentLevel;

    private static List<Level> levelList = new List<Level>();
    void Awake()
    {
        activeTool = Tool.PENCIL;
        Level l = new Level(1, new int[5,5] {{0,0,0,0,0},{0,1,1,1,0},{0,1,0,1,0},{0,1,1,1,0},{0,0,0,0,0}});
        levelList.Add(l);
        currentLevel = l;
    }

    public static void setCurrentLevel(int newLevelId){
        Level newLevel = levelList.Find(x=> x.getLevelId() == newLevelId);
        currentLevel = newLevel;
    }
}
