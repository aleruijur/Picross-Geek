using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{

    Collider2D col;
    public int posX, posY;


    void Start(){
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            
            if(touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved){
                Collider2D collider = Physics2D.OverlapPoint(touchPos); 
                if(collider == col){

                    if(GM.activeTool == Tool.PENCIL){
                        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                    }else if(GM.activeTool == Tool.CROSS){
                        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                    }else if(GM.activeTool == Tool.ERASER){
                        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                    }
                    
                    if(GM.activeTool == Tool.PENCIL){
                        BoardScript.setValueBox(1,posX,posY);
                    }else{
                        BoardScript.setValueBox(0,posX,posY);
                    }
                }
                
            }
        }

        
    }

    public void setPosX(int x){
        posX = x;
    }

    public void setPosY(int y){
        posY = y;
    }
}