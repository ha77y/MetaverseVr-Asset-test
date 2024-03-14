
using UnityEngine;


public class Player : MonoBehaviour
{
    private PlayerInputMap _pInput;
    private Rigidbody _rb;
    
    //private float _speed;
    [SerializeField] private float cAcceleration;
    

    //input variables
    private float _steerIn;
    private float _accelerateIn;
    private float _decelerateIn;
    private Vector2 _camTurnIn = Vector2.zero;

    private void Awake()
    {
        _pInput = new PlayerInputMap();
        _rb = transform.GetComponent<Rigidbody>();
    }
    
    
    // Update is called once per frame
    void Update()
    {
        FetchInputVariables();

        var acceleration  =  (_accelerateIn + _decelerateIn);
        
        /*
        _speed = _speed + acceleration > maxSpeed ? maxSpeed : 
            _speed = _speed+ acceleration < - maxSpeedReverse ? -maxSpeedReverse:
                acceleration;
                */
        
        //_speed = Mathf.Clamp(_speed + acceleration, - maxSpeedReverse, maxSpeed);
        

        transform.Rotate(0,
            (0.2f*_steerIn +_steerIn * (2 * _rb.velocity.magnitude *acceleration) )*Time.deltaTime,
            0);
        
        _rb.AddForce(transform.forward * (acceleration * cAcceleration), ForceMode.Acceleration);
    }

    private void FetchInputVariables()
    {
        _steerIn = _pInput.Movement.Steering.ReadValue<float>();
        _camTurnIn = _pInput.Movement.Camera.ReadValue<Vector2>();
        _accelerateIn = _pInput.Movement.Accelerate.ReadValue<float>();
        _decelerateIn = _pInput.Movement.Decelerate.ReadValue<float>();
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

