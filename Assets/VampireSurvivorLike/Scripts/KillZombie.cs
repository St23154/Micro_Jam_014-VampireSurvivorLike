using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZombie : MonoBehaviour
{
    [SerializeField] GameObject ZombieKillZone;
    
    // Start is called before the first frame update
 private void OnTriggerEnter2D(Collider2D Collision)
    {
    Ennemy_ZombieAI ZOMBIE = Collision.GetComponent<Ennemy_ZombieAI>();
        
        if (ZOMBIE != null)
        {
            ZOMBIE.TakeDamage(100);
            //_cameraShakeScript.GetComponent<CameraShake>().ShakeCamera();
        }

        ZombieKillZone.SetActive(false);
        Debug.Log("plus de Zombie");
    }
}
