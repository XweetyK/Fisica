using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    [SerializeField] private Wheel _leftWheel;
    [SerializeField] private Wheel _rightWheel;

    [SerializeField] private GameObject _explosion;
    
    private CollisionBox _collisionBox;
    CollisionManager _colManager;
    bool _i = false;

    float minRightWheelSpeed;
    float minLeftWheelSpeed;
    float maxRightWheelSpeed;
    float maxLeftWheelSpeed;
    float carSpeedRight;
    float carSpeedLeft;

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

    private void WheelMovementInput() {

        switch ((int)Input.GetAxisRaw("RightWheel")) {
            case 1:
                if (_rightWheel.accel < _rightWheel.maxAccel) {
                    _rightWheel.accel += Time.deltaTime * 2.0f;
                }
                break;

            case -1:
                if (_rightWheel.accel > -_rightWheel.maxAccel) {
                    _rightWheel.accel -= Time.deltaTime * 2.0f;
                }
                break;

            case 0:
                if (_rightWheel.accel != 0.0f) {
                    if (_rightWheel.speed > 0.0f) { 
                        _rightWheel.accel = -_rightWheel.friction;
                    } else {
                        _rightWheel.accel = _rightWheel.friction;
                    };
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
                    if (_leftWheel.speed > 0.0f){
                        _leftWheel.accel = -_leftWheel.friction;
                    } else {
                        _leftWheel.accel = _leftWheel.friction;
                    };
                }
                break;
        }
    }

    private void WheelMovementPosition() {

        //MinRightWheel-------------------------------------
        if (_rightWheel.accel == -_rightWheel.friction){
            minRightWheelSpeed = 0f;
        }
        else {
            minRightWheelSpeed = -_rightWheel.friction;
        }

        //MinLeftWheel-------------------------------------
        if (_leftWheel.accel == -_leftWheel.friction){
            minLeftWheelSpeed = 0f;
        }
        else {
            minLeftWheelSpeed = -_leftWheel.friction;
        }

        //MaxRightWheel-------------------------------------
        if (_rightWheel.accel == _rightWheel.friction){
            maxRightWheelSpeed = 0f;
        }
        else {
            maxRightWheelSpeed = _rightWheel.friction;
        }

        //MaxLeftWheel-------------------------------------
        if (_leftWheel.accel == _leftWheel.friction){
            maxLeftWheelSpeed = 0f;
        }
        else {
            maxLeftWheelSpeed = _leftWheel.friction;
        }

        //Aceleracion Circular------------------------------
        LeosLib.Movement.AceleracionCircular(_rightWheel.radius, _rightWheel.accel, ref _rightWheel.speed,
            minRightWheelSpeed, maxRightWheelSpeed);
        LeosLib.Movement.AceleracionCircular(_leftWheel.radius, _leftWheel.accel, ref _leftWheel.speed,
            minLeftWheelSpeed, maxLeftWheelSpeed);

        //Velocidad por rueda------------------------------
        carSpeedLeft = _leftWheel.radius * _leftWheel.speed;
        carSpeedRight = _rightWheel.radius * _rightWheel.speed;


        Vector3 dirLeft = Mathf.Sign(carSpeedLeft) * transform.up - transform.right;
        if (_leftWheel.speed < 0.0f)
        {
            dirLeft.x *= -1.0f;
            dirLeft.y *= -1.0f;
        }
        Vector3 dirRight = Mathf.Sign(carSpeedRight) * transform.up + transform.right;
        if (_rightWheel.speed < 0.0f)
        {
            dirRight.x *= -1.0f;
            dirRight.y *= -1.0f;
        }

        transform.position += LeosLib.Movement.MRU(carSpeedLeft, dirLeft);
        transform.position += LeosLib.Movement.MRU(carSpeedRight, dirRight);
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

        public static Vector3 MRU(float speed, Vector3 dir)
        {
            dir *= speed * Time.deltaTime;
            return dir;
        }

        public static void AceleracionCircular(float radius, float acceleration, ref float initialAngularSpeed, float minSpeed, float maxSpeed)
        {
            float currentAngularSpeed = 0f;
            currentAngularSpeed = acceleration * Time.deltaTime + initialAngularSpeed;
            currentAngularSpeed = Mathf.Clamp(currentAngularSpeed, minSpeed, maxSpeed);
            initialAngularSpeed = currentAngularSpeed;
        }

    }
}
