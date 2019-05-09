using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField] private int _vida;
    
    public int Life {
        get { return _vida; }
        set { _vida += value; }
    }
}
