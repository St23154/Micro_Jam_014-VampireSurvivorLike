using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{

    public float _speed = 2f;
    public GameObject _arrows;
    private Vector3 _target;
    private GameObject _arrowsToDelete;
    public Camera _mainCamera;
    private bool _isMolletteButtonDown = false;
    private bool _stop = false;

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

        //Move
        
        if (_isMolletteButtonDown)
        {
            _arrowsToDelete = GameObject.FindGameObjectWithTag("ArrowPointer");
            _target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _target.z = transform.position.z;
            Destroy(_arrowsToDelete);
            Instantiate(_arrows, _target, transform.rotation);
            _isMolletteButtonDown = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        
        if (transform.position == _target)
        {
            _arrowsToDelete = GameObject.FindGameObjectWithTag("ArrowPointer");
            Destroy(_arrowsToDelete);
        }
    }
}
