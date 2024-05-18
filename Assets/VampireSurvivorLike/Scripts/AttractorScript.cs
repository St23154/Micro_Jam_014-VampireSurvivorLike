using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractorScript : MonoBehaviour
{
    public float _attractorSpeed;
     void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Bat"))
        {
            transform.position = Vector3.MoveTowards(transform.position,other.transform.position,_attractorSpeed * Time.deltaTime);
        }
    }
}
