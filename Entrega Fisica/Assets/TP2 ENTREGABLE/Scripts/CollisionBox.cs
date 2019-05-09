using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBox : MonoBehaviour
{
    [SerializeField] float _width = 0;
    [SerializeField] float _height = 0;
    [SerializeField] float _ratio = 0;


    public float Width {
        get { return _width; }
        set { _width = value; }
    }

    public float Height {
        get { return _height; }
        set { _height = value; }
    }

    public float GetRatio {
        get { return (_ratio / 2); }
    }
}
