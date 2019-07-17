using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    [SerializeField] private Wheel _leftWheel;
    [SerializeField] private Wheel _rightWheel;

    [SerializeField] private GameObject _explosion;
    
    private CollisionBox _collisionBox;
    CollisionManager _colManager;
    bool _i = false;

    void Start() {
        _collisionBox = gameObject.GetComponent<CollisionBox>();
        _colManager = FindObjectOfType<CollisionManager>();
        _colManager.AddEntity(0, _collisionBox);
    }

    void Update() {
        WheelMovementInput();
        WheelMovementPosition();
        CheckCollisions();
    }

    private void WheelMovementPosition() {

        float minRightWheelSpeed = (_rightWheel.accel == -_rightWheel.friction) ? 0f : -_rightWheel.friction;
        float minLeftWheelSpeed = (_leftWheel.accel == -_leftWheel.friction) ? 0f : -_leftWheel.friction;
        float maxRightWheelSpeed = (_rightWheel.accel == _rightWheel.friction) ? 0f : _rightWheel.friction;
        float maxLeftWheelSpeed = (_leftWheel.accel == _leftWheel.friction) ? 0f : _leftWheel.friction;

        LeosLib.Movement.ConstAccelCirc2D(_rightWheel.radius, _rightWheel.accel, ref _rightWheel.speed, minRightWheelSpeed, maxRightWheelSpeed);
        LeosLib.Movement.ConstAccelCirc2D(_leftWheel.radius, _leftWheel.accel, ref _leftWheel.speed, minLeftWheelSpeed, maxLeftWheelSpeed);

        float carSpeedRight = _rightWheel.radius * _rightWheel.speed;
        float carSpeedLeft = _leftWheel.radius * _leftWheel.speed;

        Vector3 dirRight = Mathf.Sign(carSpeedRight) * transform.up + transform.right;
        if (_rightWheel.speed < 0.0f)
        {
            dirRight.x *= -1.0f;
            dirRight.y *= -1.0f;
        }
        dirRight.Normalize();

        Vector3 dirLeft = Mathf.Sign(carSpeedLeft) * transform.up - transform.right;
        if (_leftWheel.speed < 0.0f)
        {
            dirLeft.x *= -1.0f;
            dirLeft.y *= -1.0f;
        }
        dirLeft.Normalize();

        transform.position += LeosLib.Movement.NextPositionMRU(carSpeedLeft, dirLeft);
        transform.position += LeosLib.Movement.NextPositionMRU(carSpeedRight, dirRight);
    }

    private void WheelMovementInput() {

        switch ((int)Input.GetAxisRaw("RightWheel")) {
            case 1:
                if (_rightWheel.accel < _rightWheel.maxAccel) {
                    _rightWheel.accel += Time.deltaTime;
                }
                break;


            case -1:
                if (_rightWheel.accel > -_rightWheel.maxAccel) {
                    _rightWheel.accel -= Time.deltaTime;
                }
                break;

            case 0:
                if (_rightWheel.accel != 0.0f) {
                    _rightWheel.accel = (_rightWheel.speed > 0.0f) ? -_rightWheel.friction : _rightWheel.friction;
                }
                break;
        }

        switch ((int)Input.GetAxisRaw("LeftWheel")) {
            case 1:
                if (_leftWheel.accel < _leftWheel.maxAccel) {
                    _leftWheel.accel += Time.deltaTime * 2.0f;
                }
                break;

            case -1:
                if (_leftWheel.accel > -_leftWheel.maxAccel) {
                    _leftWheel.accel -= Time.deltaTime * 2.0f;
                } 
                break;

            case 0:
                if (_leftWheel.accel != 0.0f){
                    _leftWheel.accel = (_leftWheel.speed > 0.0f) ? -_leftWheel.friction : _leftWheel.friction;
                }
                break;
        }
    }

    void CheckCollisions() {
        if (_colManager.CheckCollisions(1, ref _collisionBox)) {
            if (_i==false) {
                Instantiate(_explosion, transform.position, transform.rotation);
                _i = true;
            }
            Time.timeScale = 0.0f;
        }
    }

}




































namespace LeosLib {
    public class Movement : MonoBehaviour {

         public static Vector3 NextPositionMRU(float speed, Vector3 dir) {

        dir *= speed * Time.deltaTime;
        return dir;
    }

         public static void ConstAccelCirc2D(float radius, float acceleration, ref float initialAngularSpeed, float minSpeed, float maxSpeed) {

        float currentAngularSpeed = 0f;
        currentAngularSpeed = acceleration * Time.deltaTime + initialAngularSpeed;
        currentAngularSpeed = Mathf.Clamp(currentAngularSpeed, minSpeed, maxSpeed);
        initialAngularSpeed = currentAngularSpeed;
    }

    }
}
