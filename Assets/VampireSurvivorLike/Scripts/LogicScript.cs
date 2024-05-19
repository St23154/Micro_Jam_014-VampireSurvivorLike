using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class LogicScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float _max_time = 1;
    public float _elapsedTime = 0;
    [SerializeField] private Image _HealthBarFill;
    [SerializeField] private GameObject StopTime;

    // Update is called once per frame
    // Method to slow down time and activate StopTime
    public void Slow()
    {
        StopTime.SetActive(true);
        Time.timeScale = 0.2f;
    }

    // Method to resume time and deactivate StopTime
    public void Resume()
    {
        StopTime.SetActive(false);
        Time.timeScale = 1f;
    }
    void Update()
    {
         if (Input.GetMouseButton(1) && _elapsedTime<1){
            Slow();
            TimeF();

         }
         else{
            Resume();
            _elapsedTime = 0;
         }

        
    }

public void TimeF(){
     _elapsedTime += Time.deltaTime;     
    UpdateHealthBar(); 
          
}

    public void UpdateHealthBar(){
        float targetFillAmount = 1 - _elapsedTime;
        Debug.Log(_elapsedTime +" ze "+ targetFillAmount);
        _HealthBarFill.fillAmount = targetFillAmount;
    }
}