using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Timeline;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{

    public float _speed = 2f;
    public GameObject _arrows;
    private Vector3 _target;
    private GameObject _arrowsToDelete;
    public Camera _mainCamera;
    private Animator _animator;
    private bool _isMolletteButtonDown = false;
    private bool _stop = false;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //Click Detection
        if (Input.GetMouseButtonDown(2))
        {
            _isMolletteButtonDown = true;
        }
        if (Input.GetMouseButtonUp(2))
        {
            _isMolletteButtonDown = false;
        }
        
        //Display arrows and set target where the player click

        if (_isMolletteButtonDown)
        {
            _arrowsToDelete = GameObject.FindGameObjectWithTag("ArrowPointer");
            _target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _target.z = transform.position.z;
            Destroy(_arrowsToDelete);
            Instantiate(_arrows, _target, transform.rotation);
            _isMolletteButtonDown = false;
            RotatePlayerAnimation(_target.x - transform.position.x, _target.y - transform.position.y);
            
        }

        //Move

        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        //Destroy arrows if player is on
        
        if (transform.position == _target)
        {
            _arrowsToDelete = GameObject.FindGameObjectWithTag("ArrowPointer");
            Destroy(_arrowsToDelete);
        }
    }

    private void RotatePlayerAnimation(float Xpos, float Ypos)
    {
        if ((Xpos != 0) || (Ypos != 0))
            {
                if (Xpos < 0)
                {
                    if (Xpos * - 1 > math.abs(Ypos))
                    {
                        _animator.SetFloat("X", -1);
                        _animator.SetFloat("Y", 0);
                    }
                }
                if (Ypos < 0)
                {
                    if (Ypos * - 1 > math.abs(Xpos))
                    {
                        _animator.SetFloat("Y", -1);
                        _animator.SetFloat("X", 0);
                    }
                }
                if (Xpos > 0)
                {
                    if (Xpos > math.abs(Ypos) )
                    {
                        _animator.SetFloat("X", 1);
                        _animator.SetFloat("Y", 0);
                    }
                }
                if (Ypos > 0)
                {
                    if (Ypos > math.abs(Xpos) )
                    {
                        _animator.SetFloat("Y", 1);
                        _animator.SetFloat("X", 0);
                    }
                }
            }
    }

}
