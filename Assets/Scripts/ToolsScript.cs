using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsScript : MonoBehaviour
{
    private GameObject pencil;
    private GameObject cross;
    private GameObject eraser;
    private Transform frame;

    void Start()
    {
        pencil = transform.GetChild(0).gameObject;
        cross = transform.GetChild(1).gameObject;
        eraser = transform.GetChild(2).gameObject;
        frame = transform.GetChild(3);
    }

    void Update()
    {
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            
            if(touch.phase == TouchPhase.Began){
                Collider2D collider = Physics2D.OverlapPoint(touchPos); 
                if(collider == pencil.GetComponent<Collider2D>()){
                    GM.activeTool = Tool.PENCIL;
                    frame.position = pencil.transform.position;
                }else if(collider == cross.GetComponent<Collider2D>()){
                    GM.activeTool = Tool.CROSS;
                    frame.position = cross.transform.position;
                }else if(collider == eraser.GetComponent<Collider2D>()){
                    GM.activeTool = Tool.ERASER;
                    frame.position = eraser.transform.position;
                }
            }
        }
    }
}
