using System.Linq;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
    public int nRow = 5, nColumn = 5;
    public float xStart = -1.6f, yStart = 1.6f;
    public GameObject box;
    public float space = 0.25f;

    private static int[,] solution;
    private static int[,] matrix;
    private static Dictionary<String,List<int>> clues;
    void Start()
    {
        
        for(int i = 0; i< nColumn*nRow; i++){
            GameObject newBox = Instantiate(box);
            newBox.transform.SetParent(gameObject.transform);
            newBox.transform.position = new Vector3(xStart + space*(i%nColumn), yStart - space*(i/nColumn));
            BoxScript boxScript = newBox.GetComponent<BoxScript>();
            boxScript.setPosX(i%nColumn);
            boxScript.setPosY(i/nColumn);
        }
/*
        for(int i = 0; i < nRow; i++){
            for(int j = 0; j < nColumn; j++){
                
            }
        }
*/      
        solution = GM.currentLevel.getSolution();
        matrix = new int[nRow,nColumn];
        Array.Clear(matrix,0,matrix.Length);

        //clues = getClues();
    }

    public static void setValueBox(int val, int posX, int posY){
        matrix[posX,posY] = val;
        checkSolve();
    }

    private static void checkSolve(){
        if(Enumerable.SequenceEqual(matrix.OfType<int>(),solution.OfType<int>())){
            print("You win");
        }
    }
/*
    private Dictionary<String,List<int>> getClues(){
        Dictionary<String,List<int>> res = new Dictionary<string, List<int>>();
        for(int i = 0; i< nColumn; i++){
            List<int> clue = getClue(solution[i,0..nRow]);
            
        }
        return res;
    }
*/
    private List<int> getClue(int[] line){
        List<int> clue = new List<int>();
        int acum = 0;
        for(int i = 0; i<line.Length; i++){
            if(line[i]==1){
                acum++;
            }else if(acum!=0){
                clue.Add(acum);
                acum=0;
            }
        }

        if(acum!=0){
            clue.Add(acum);
        }

        return clue;
    }
}
