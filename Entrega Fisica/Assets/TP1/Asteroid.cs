using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float _vel;
    private float _iPosX;
    private float _iPosY;
    private float _mru;
    private float _timer;

    void Start() {
        _vel = Random.Range(-5.0f, -15.0f);
        _iPosX = 12;
        _iPosY = Random.Range(-5.0f, 5.0f);
        transform.position = new Vector3(_iPosX, _iPosY, 0);
        
    }

    void Update() {
        _timer += 1 * Time.deltaTime;
        _mru = _iPosX + _vel * _timer;

        transform.position = new Vector3(_mru, transform.position.y , 0);
        if (transform.position.x < -12) {
            Destroy (gameObject);
        }
    }
}
