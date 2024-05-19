using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    // Start is called before the first frame update
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Debug.Log(Time.timeScale);
        Time.timeScale=0;
        Debug.Log(Time.timeScale);
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale=1;
    }

}
