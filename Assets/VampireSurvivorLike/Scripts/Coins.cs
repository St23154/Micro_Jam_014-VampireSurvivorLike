using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public void Collect()
    {
        Destroy(gameObject);
    }
}
