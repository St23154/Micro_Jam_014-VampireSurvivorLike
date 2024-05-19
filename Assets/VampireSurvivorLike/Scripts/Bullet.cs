using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _speed = 40;
    public float _damageAmount = 20;
    public float _timeUntilDestroying;
    private float _time = 0.0f;
    private Rigidbody2D _myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        _damageAmount = 20;
        _myRigidBody = GetComponent<Rigidbody2D>();
        _myRigidBody.velocity = transform.right*_speed;
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        Ennemy_ZombieAI ZOMBIE = Collision.GetComponent<Ennemy_ZombieAI>();
        Enemy_BatAI BAT = Collision.GetComponent<Enemy_BatAI>();
        
        if (ZOMBIE != null)
        {
            ZOMBIE.TakeDamage(_damageAmount);
            Destroy(gameObject);
            //_cameraShakeScript.GetComponent<CameraShake>().ShakeCamera();
        }


        if (BAT != null)
        {
            BAT.TakeDamage(_damageAmount);
            Destroy(gameObject);
            //_cameraShakeScript.GetComponent<CameraShake>().ShakeCamera();
        }
    }

    void Update()
    {
        _time += Time.deltaTime;
        if (_time >= _timeUntilDestroying)
        {
            Destroy(gameObject);     
        }
    }

}
