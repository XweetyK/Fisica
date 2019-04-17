using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    [SerializeField] float _timer;
    GameObject _instance;

    void Start() {
        InvokeRepeating("Instantiate", 0, _timer);
    }

    void Update() {
        
    }

    void Instantiate() {
        _instance= Instantiate(_prefab);
    }
}
