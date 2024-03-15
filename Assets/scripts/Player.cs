
using System;
using UnityEngine;
using UnityEngine.Serialization;


public class Player : MonoBehaviour
{
    private PlayerInputMap _pInput;
    private Rigidbody _rb;
    [SerializeField] private UiHandler uiHandler;
    
    
    //private float _speed;
    [SerializeField] private float cAcceleration;

    private float _endtimer;

    //input variables
    private float _steerIn;
    private float _accelerateIn;
    private float _decelerateIn;
    
    public static bool paused;
    [SerializeField] private float finishTimer =8f;

    private void Awake()
    {
        _pInput = new PlayerInputMap();
        _rb = transform.GetComponent<Rigidbody>();
    }
    
    
    // Update is called once per frame
    void Update()
    {
        FetchInputVariables();

        if (_pInput.UI.Pause.triggered)
        {
            print("pause");
            if (!paused)
            {
                uiHandler.PauseGame();
            }
            else
            {
                uiHandler.Resume();
            }
        }

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
        _accelerateIn = _pInput.Movement.Accelerate.ReadValue<float>();
        _decelerateIn = _pInput.Movement.Decelerate.ReadValue<float>();
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag("Finish"))
        {
            _endtimer += Time.deltaTime;
            if (_accelerateIn + _decelerateIn != 0 ||
                // checking that the boat is docking at port-side
                Vector3.Dot(other.transform.forward,transform.forward)<0.9f)
            {
                _endtimer = 0;
            }

            if (_endtimer > finishTimer)
            {
                uiHandler.Win();
            }
        }
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

