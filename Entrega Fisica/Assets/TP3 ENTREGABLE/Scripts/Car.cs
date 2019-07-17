using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float _limitY;
    private CollisionBox _collisionBox;
    private CollisionManager _colManager;

    void Start(){
        _collisionBox = gameObject.GetComponent<CollisionBox>();
        _colManager = FindObjectOfType<CollisionManager>();
        _colManager.AddEntity(1, _collisionBox);
    }

    void Update()
    {
        transform.Translate(-Vector3.up * Time.deltaTime*1f);
        if (transform.position.y<_limitY)
        {
            Destroy(gameObject);
        }
    }
}
