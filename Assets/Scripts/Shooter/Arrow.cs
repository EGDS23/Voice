using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Arrow : MonoBehaviour
{
    [SerializeField] float destroyTime = 2f;
    private Vector3 _dir;
    private float _speed;

    void Start()
    {
        transform.parent = null;

    }

    void Update()
    {
        transform.Translate(_dir * Time.deltaTime * _speed);
        Invoke("Destroy", destroyTime);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

    public void SetDirectionAndSpeed(Vector3 dir, float speed)
    {
        _dir = dir.normalized;
        _speed = speed;
    }
}
