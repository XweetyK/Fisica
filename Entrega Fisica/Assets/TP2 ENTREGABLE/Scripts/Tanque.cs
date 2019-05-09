using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanque : MonoBehaviour
{
    enum Player { PLAYER_1, PLAYER_2 };
    [SerializeField] GameObject _canon;
    [SerializeField] Transform _canonTarget;
    [SerializeField] Player _player;
	[SerializeField] GameObject _bomb;
    [SerializeField] float _angle;
    [SerializeField] float _xVel;
    float _vel;
    float _balaVelP1;
    float _balaVelP2;
    float _mru;
	GameObject _cannonBall;
	Bala _bala;
    CollisionManager _colManager;
    CollisionBox _cBox;
    Vida _vida;
    GameManager _GM;

    bool _turno= true;
    void Start() {
        _colManager = FindObjectOfType<CollisionManager>();
        _cBox = gameObject.GetComponent<CollisionBox>();
        _colManager.AddEntity(0, _cBox);
        _vida = gameObject.GetComponent<Vida>();
        _GM = FindObjectOfType<GameManager>();
    }


    void Update() {
        if (!_GM.GameOver)
        {
            Movement();
            if (Input.GetButton("Space"))
            {
                if (_turno)
                {
                    _balaVelP1 += 10 * Time.deltaTime;
                }
                else { _balaVelP2 += 10 * Time.deltaTime; }

            }
            if (Input.GetButtonUp("Space"))
            {
                Shoot();
                _balaVelP1 = _balaVelP2 = 0;
            }
            if (_colManager.CheckCollisions(1, ref _cBox))
            {
                _vida.Life = -5;
            }

            _turno = _GM.SetTurn;
        }
    }

    void Movement() {
        _vel = 0;
        switch (_player)
        {
            case Player.PLAYER_1:
                if (_turno == true)
                {
                    if (Input.GetButton("Right"))
                    {
                        _vel = _xVel;
                    }
                    if (Input.GetButton("Left"))
                    {
                        _vel = -_xVel;
                    }
                    if (Input.GetButton("Up"))
                    {
                        _canon.transform.Rotate(0, 0, -_angle);
                    }
                    if (Input.GetButton("Down"))
                    {
                        _canon.transform.Rotate(0, 0, _angle);
                    }
                }
                break;

            case Player.PLAYER_2:
                if (_turno == false)
                {
                    if (Input.GetButton("Right2"))
                    {
                        _vel = _xVel;
                    }
                    if (Input.GetButton("Left2"))
                    {
                        _vel = -_xVel;
                    }
                    if (Input.GetButton("Up2"))
                    {
                        _canon.transform.Rotate(0, 0, _angle);
                    }
                    if (Input.GetButton("Down2"))
                    {
                        _canon.transform.Rotate(0, 0, -_angle);
                    }
                }
                break;
        }

        _mru = transform.position.x + _vel * Time.deltaTime;
        transform.position = new Vector3(_mru, transform.position.y, 0);
    }

	void Shoot(){
		switch (_player) {
	    	case Player.PLAYER_1:
                if (_turno==true)
                {
                    _cannonBall = Instantiate(_bomb);
                    _bala = _cannonBall.GetComponent<Bala>();
                    _cannonBall.transform.position = _canonTarget.position;
                    _bala.Angle = _canon.transform.eulerAngles.z;
                    _bala.Vel = _balaVelP1;
                    _bala.Fired = true;
                }      
			break;

		    case Player.PLAYER_2:
                if (_turno==false)
                {
                    _cannonBall = Instantiate(_bomb);
                    _bala = _cannonBall.GetComponent<Bala>();
                    _cannonBall.transform.position = _canonTarget.position;
                    _bala.Angle = _canon.transform.eulerAngles.z;
                    _bala.Vel = _balaVelP2;
                    _bala.Fired = true;
                }
			break;
		}
    }
    public float Vel1 {
        get { return _balaVelP1;}
    }
    public float Vel2 {
        get { return _balaVelP2; }
    }
}
