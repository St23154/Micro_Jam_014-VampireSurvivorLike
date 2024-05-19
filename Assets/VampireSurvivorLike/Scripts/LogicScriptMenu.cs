using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScriptMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private int _Difficulté = 1;

    public void easy()
    {
        _Difficulté = 1;
        Debug.Log(_Difficulté);
       
    }

    public void medium()
    {
        _Difficulté = 2;
    
    }

    public void Hard()
    {
        _Difficulté = 3;

        Debug.Log(_Difficulté);
        
    }
}
