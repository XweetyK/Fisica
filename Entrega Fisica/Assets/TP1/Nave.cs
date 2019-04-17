using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    [SerializeField] private float _vel;
    [SerializeField] private float _const;
    private float _iPosY;
    private float _mru;
    private float _mruv;
    private float _accel;
    private float _timer;
    bool _pressed = false;

    void Start()
    {
        _iPosY = transform.position.y;
    }

    void Update()
    {
        _timer += 1 * Time.deltaTime;
        MovementUp();
        if (Input.GetButton("Left")) {
            _accel = -_const;
        }
        if (Input.GetButton("Right")){
            _accel = _const;
        }
        _mruv = transform.position.x + 0.5f * _accel * Mathf.Pow(Time.deltaTime, 2) + _vel * Time.deltaTime;
        transform.position = new Vector3(_mruv, transform.position.y, 0);
        _accel = 0;
    }
    void MovementUp() {
        if (Input.GetButton("Down"))
        {
            if (!_pressed)
            {
                _timer = 0;
                _iPosY = transform.position.y;
                _pressed = true;
            }
            _mru = _iPosY + (-_vel) * _timer;
            transform.position = new Vector3(transform.position.x, _mru, 0);
        }
        else if (Input.GetButton("Up"))
        {
            if (!_pressed)
            {
                _timer = 0;
                _iPosY = transform.position.y;
                _pressed = true;
            }
            _mru = _iPosY + _vel * _timer;
            transform.position = new Vector3(transform.position.x, _mru, 0);
        }
        else { _pressed = false; }
    }
}
