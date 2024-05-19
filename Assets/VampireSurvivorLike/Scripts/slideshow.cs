using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
 
public class slideshow1 : MonoBehaviour
{
    [SerializeField] GameObject Tuto;
    [SerializeField] GameObject MainMenu;
    
    public Texture[] imageArray; 
    private int currentImage;
            
    void OnGUI()
    {
        
        int w = Screen.width, h = Screen.height;
        
        Rect imageRect = new Rect(0, 0, Screen.width, Screen.height);
        
        //dont need to make button transparent but would be cool to know how to.
        //Rect buttonRect = new Rect(0, Screen.height - Screen.height / 10, Screen.width, Screen.height / 10);
        
        //GUI.Label(imageRect, imageArray[currentImage]);
        //Draw texture seems more elegant
        GUI.DrawTexture(imageRect, imageArray[currentImage]);
    
        //if(GUI.Button(buttonRect, "Next"))
        //currentImage++;
    }
 
    // Start is called before the first frame update
    void Start()
    {
        currentImage = 0;

     }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        Screen.lockCursor = true;
            
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Pressed primary button.");
                    currentImage++;
        
                if(currentImage >= imageArray.Length)
                    Tuto.SetActive(false);
                    MainMenu.SetActive(true);
                    Cursor.visible= true;
                    Screen.lockCursor = false;
            }
            
            
             if (Input.GetMouseButtonDown(0) && currentImage >= 1)
            {
                currentImage--;
            }                   
    }
}