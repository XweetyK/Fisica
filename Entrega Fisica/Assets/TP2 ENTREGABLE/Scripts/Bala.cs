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
    CollisionManager _colManager;
    CollisionBox _cBox;
    GameManager _GM;

	private bool _fired;

    void Start()
    {
        _GM = FindObjectOfType<GameManager>();
        _colManager = FindObjectOfType<CollisionManager>();
        _cBox = gameObject.GetComponent<CollisionBox>();
        _colManager.AddEntity(1, _cBox);
        _timer = 0;
		_fired = false;
		_posXi = gameObject.transform.position.x;
		_posYi = gameObject.transform.position.y;

    }

    void Update()
    {
        Movement();
        if (_colManager.CheckCollisions(0, ref _cBox)) {
            Invoke("Destroid",0.05f);
        }
        else if (this.transform.position.y < -3.42f) {
            _GM.SetTurn = _GM.SetTurn;
            Destroy(gameObject);
        }
    }
    void Movement() {
        _sinA = Mathf.Sin(_alfa * Mathf.Deg2Rad);
        _cosA = Mathf.Cos(_alfa * Mathf.Deg2Rad);
        _timer += Time.deltaTime;
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
    void Destroid() {
        _GM.SetTurn = _GM.SetTurn;
        Destroy(gameObject);
    }
}
