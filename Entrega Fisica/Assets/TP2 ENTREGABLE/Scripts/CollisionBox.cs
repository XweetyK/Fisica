using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBox : MonoBehaviour
{
    [SerializeField] float _width = 0;
    [SerializeField] float _height = 0;

    void Awake()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        if (sprite)
        {
            _width = sprite.bounds.extents.x * 2 * transform.localScale.x;
            _height = sprite.bounds.extents.y * 2 * transform.localScale.y;
            Debug.Log("Width: " + _width + " Height:  " + _height);
        }
    }
    public float Width
    {
        get { return _width; }
        set { _width = value; }
    }


    public float Height
    {
        get { return _height; }
        set { _height = value; }
    }
}
