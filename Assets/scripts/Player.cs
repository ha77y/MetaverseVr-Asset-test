
using UnityEngine;


public class Player : MonoBehaviour
{
    private PlayerInputMap _pInput;
    
    private float _speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float maxSpeedReverse;
    [SerializeField] private float cAcceleration;
    [SerializeField] private float maxWheelTurns;

    private float currentwheelTurns;

    //input variables
    private float _steer;
    private float _accelerate;
    private float _decelerate;
    private Vector2 _camTurn = Vector2.zero;

    private void Awake()
    {
        _pInput = new PlayerInputMap();
    }

    private void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        FetchInputVariables();

        _speed += Acceleration();
        
        transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
        
        
        var turnPercent = currentwheelTurns / maxWheelTurns;
        var turnSpeed = _steer  * _speed * Time.deltaTime;
        
        transform.eulerAngles +=  Vector3.up * turnSpeed;



    }

    private float ClampedSteering()
    {
        if (Mathf.Abs(currentwheelTurns + _steer) >= maxWheelTurns)
        {
            return 0;
        }
        
        return _steer;
    }

    private float Acceleration()
    {
        var rv = 0f;
        
        /*if (_accelerate!=0)
        {
            if (_speed < maxSpeed)
            {
                rv += _accelerate*Time.deltaTime;
            }
        }

        if (_decelerate != 0)
        {
            if (_speed > Mathf.Abs(maxSpeedReverse)*-1)
            {
                rv -= _decelerate*Time.deltaTime;
            }
        }*/
        
        var addedAcceleration = _accelerate - _decelerate;
        rv += addedAcceleration * Time.deltaTime;
        //rv =Mathf.Clamp(rv, maxSpeedReverse, maxSpeed);
        return rv*cAcceleration;
    }

    private void FetchInputVariables()
    {
        _steer = _pInput.Movement.Steering.ReadValue<float>();
        _camTurn = _pInput.Movement.Camera.ReadValue<Vector2>();
        _accelerate = _pInput.Movement.Accelerate.ReadValue<float>();
        _decelerate = _pInput.Movement.Decelerate.ReadValue<float>();
    }
    
    
    private void OnEnable()
    {
        _pInput.Enable();
    }

    private void OnDisable()
    {
        _pInput.Disable();
    }
    
    
    
}

