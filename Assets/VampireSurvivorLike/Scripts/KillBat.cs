using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBat : MonoBehaviour
{
    [SerializeField] GameObject BatKillZone;
    
    // Start is called before the first frame update
 private void OnTriggerEnter2D(Collider2D Collision)
    {
    Enemy_BatAI BAT = Collision.GetComponent<Enemy_BatAI>();
        
        if (BAT != null)
        {
            BAT.TakeDamage(100);
            //_cameraShakeScript.GetComponent<CameraShake>().ShakeCamera();
        }

        BatKillZone.SetActive(false);
    }
}
