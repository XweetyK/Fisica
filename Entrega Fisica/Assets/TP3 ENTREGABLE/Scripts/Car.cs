using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float _limitY;

    void Update()
    {
        transform.Translate(-Vector3.up * Time.deltaTime*1.5f);
        if (transform.position.y<_limitY)
        {
            Destroy(gameObject);
        }
    }
}
