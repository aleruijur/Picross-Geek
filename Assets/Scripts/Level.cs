using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    private int levelId;
    private int[,] solution;
    
    public Level(int levelId, int[,] solution)
    {
        this.levelId = levelId;
        this.solution = solution;
    }

    public int getLevelId(){
        return levelId;
    }

    public int[,] getSolution(){
        return solution;
    }
}
