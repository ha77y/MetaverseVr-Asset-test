using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private PlayerInputMap _pInput;
    
    

    //input variables
    private float _steer;
    private float _accelerate;
    private float _decelerate;
    private Vector2 _camTurn;

    private void Awake()
    {
        _pInput = new PlayerInputMap();
    }

    
    // Update is called once per frame
    void Update()
    {
        FetchVariables();
        
        
        
    }

    private void FetchVariables()
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
