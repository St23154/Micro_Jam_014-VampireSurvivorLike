using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stoptime : MonoBehaviour
{
    [SerializeField] private GameObject StopTime; // Reference to the StopTime GameObject

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

    // Update method to check for input each frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Slow();
        }
        else
        {
            Resume();
        }
    }
}