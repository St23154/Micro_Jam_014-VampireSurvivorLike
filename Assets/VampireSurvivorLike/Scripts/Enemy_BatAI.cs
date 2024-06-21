using System.Collections;
using System.Collections.Generic;
using NavMeshComponents.Extensions;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Enemy_BatAI : MonoBehaviour
{

    public GameObject _coins;
   public Transform _player;
    public Vector3 _tourne;
    public Vector3 _tourne1;
    public float _speed;
    public float _health = 40;
    private float i = 0f;
    private float piecesnumber = 0f;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, _player.transform.position, _speed * Time.deltaTime);

        if(transform.eulerAngles != _tourne && transform.eulerAngles != _tourne1)
        {
            if(transform.eulerAngles.y - _tourne.y < transform.eulerAngles.y - _tourne1.y)
            {
                transform.eulerAngles = _tourne;
            }
            else
            {
                transform.eulerAngles = _tourne1;
            }
        }
        if(transform.position.x  - _player.position.x < 0)
        {
            if(transform.eulerAngles == _tourne)
            {
            transform.Rotate(_tourne);
            }
        }
        else
        {
            if(transform.eulerAngles != _tourne)
            {
            transform.Rotate(_tourne);
            }
        }
    }

    public void TakeDamage(float _amount)
    {
        _health -= _amount;
        if (_health <= 0)
        {
            Destroy(gameObject);
            AudioManager.instance.Play("EnnemyDeath");
            piecesnumber = UnityEngine.Random.Range(3,5);
            for(i=0; i<= piecesnumber; i++)
            {
                Instantiate(_coins, new Vector3(transform.position.x + UnityEngine.Random.Range(0.1f,0.5f), transform.position.y + UnityEngine.Random.Range(0.1f,0.5f), transform.position.z), transform.rotation);
            }
        }
    }

}
