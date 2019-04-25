using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    //[SerializeField] float velocity;
    float _posY;
    float _posX;
    float _gravedad = 9.8f;
    float _posYi;
    float _posXi;
    float _alfa=90;
    float _timer;
    float _vel;
	float _sinA;
	float _cosA;

	private bool _fired;

    void Start()
    {
        _timer = 0;
       // _vel = velocity;
		_fired = false;
		_posXi = gameObject.transform.position.x;
		_posYi = gameObject.transform.position.y;
    }

    void Update()
    {
        Movement();
    }
    void Movement() {
        _sinA = Mathf.Sin(_alfa * Mathf.Deg2Rad);
        _cosA = Mathf.Cos(_alfa * Mathf.Deg2Rad);
        _timer += 1 * Time.deltaTime;
        _posY = _posYi + (_vel * _sinA * _timer - (_gravedad / 2) * Mathf.Pow(_timer, 2));
        _posX = _posXi + _vel * _cosA * _timer;

        transform.position = new Vector3(_posX, _posY, 0);
    }

	public float Angle{

        set{ _alfa = value; }
	}
    public float Vel {
        set { _vel = value; }
    }
    public bool Fired {
        set { _fired = value; }
    }
}
