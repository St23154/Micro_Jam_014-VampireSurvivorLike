using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{

    public float _speed = 2f;
    public Vector3 _target;
    public Camera _mainCamera;
    private bool _isMolletteButtonDown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Click Detection
        if (Input.GetMouseButtonDown(0))
        {
            _isMolletteButtonDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isMolletteButtonDown = false;
        }

        //Move
        

        if (_isMolletteButtonDown)
        {
            _target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _target.z = transform.position.z;
        }

        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }
}
