using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanque : MonoBehaviour
{
    enum Player { PLAYER_1, PLAYER_2 };
    [SerializeField] GameObject _canon;
    [SerializeField] Player _player;
	[SerializeField] GameObject _bomb;
    [SerializeField] float _xVel;
    [SerializeField] float _angle;
    float _vel;
    float _mru;
	GameObject _cannonBall;

    void Update() {
        Movement();
		Shoot ();
    }

    void Movement() {
        _vel = 0;
        switch (_player)
        {
            case Player.PLAYER_1:
                if (Input.GetButton("Right")){
                    _vel = _xVel;
                }
                if (Input.GetButton("Left")) {
                    _vel = -_xVel;
                }
                if (Input.GetButton("Up")){
                    _canon.transform.Rotate(0, 0, -_angle);
                }
                if (Input.GetButton("Down")) {
                    _canon.transform.Rotate(0, 0, _angle);
                }

                break;
            case Player.PLAYER_2:
                if (Input.GetButton("Right2")){
                    _vel = _xVel;
                }
                if (Input.GetButton("Left2")){
                    _vel = -_xVel;
                }
                if (Input.GetButton("Up2")){
                    _canon.transform.Rotate(0, 0, _angle);
                }
                if (Input.GetButton("Down2")){
                    _canon.transform.Rotate(0, 0, -_angle);
                }

                break;
        }

        _mru = transform.position.x + _vel * Time.deltaTime;
        transform.position = new Vector3(_mru, transform.position.y, 0);
    }

	void Shoot(){
		switch (_player) {
		case Player.PLAYER_1:
			if (Input.GetButton("Space")){
				_cannonBall = Instantiate (_bomb);
				_cannonBall.transform.position = _canon.transform.position;
				_cannonBall.GetComponent<Bala> ().SetAngle (_canon.transform.rotation.z);
			}
			break;
		}
	}
}
