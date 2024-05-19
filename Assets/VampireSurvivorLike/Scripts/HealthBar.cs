using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float _max_time = 1;
    public float _elapsedTime = 0;
    [SerializeField] private Image _HealthBarFill;

    // Update is called once per frame
    void Start(){
        
    }
    void Update()
    {
        _elapsedTime = 0;
        TimeF();
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
