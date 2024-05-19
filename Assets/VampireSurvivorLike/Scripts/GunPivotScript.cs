using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPivotScript : MonoBehaviour
{
    public float _turretRange = 13f;
    public float _bulletPerSecond = 2f;
    private float _timePassed = 0f;
    [SerializeField] private Transform _turretRotationPoint;
    public GameObject _bullet;
    public GameObject _shootPoint;
    private Transform _target;
    public LayerMask _ennemyMask;


    // Update is called once per frame
    void Update()
    {
        if (_target == null)
        {
            FindTarget();
            return;
        }
        RotateTowardsTarget();
        _timePassed += Time.deltaTime;

        if(_timePassed > 1/_bulletPerSecond)
        {
            Instantiate(_bullet, _shootPoint.transform.position, _turretRotationPoint.transform.rotation);
            _timePassed = 0f;
        }

        if (transform.eulerAngles.y > -90 && transform.eulerAngles.y < 90)
        {
            if (transform.eulerAngles.y == 0)
            {
            transform.eulerAngles = new Vector3(transform.rotation.y,180,transform.rotation.z);
            }
        }
        else
        {
            if (transform.eulerAngles.y == 180)
            {
            transform.eulerAngles = new Vector3(transform.rotation.y,0,transform.rotation.z);
            }
        }
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _turretRange, (Vector2)transform.position, 0f, _ennemyMask);

        if (hits.Length > 0)
        {
            _target = hits[0].transform;
        }
    }

    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(_target.position.y - transform.position.y, _target.position.x - 
        transform.position.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, angle));
        _turretRotationPoint.rotation = targetRotation;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _turretRange);
    }
}
