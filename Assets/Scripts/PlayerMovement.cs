using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;


public class PlayerMovement : MonoBehaviour
{
    //FUTURE IMPROVEMENTS:
    //Change the way of reference the camera every time you walk.
    
    [Header("Speed value")]
    [SerializeField] private float defaultSpeed = 200f;
    [SerializeField] private float runSpeed = 400f;

    private float _currentSpeed;

    [Header("Gravity")]
    [SerializeField] private float gravity;
    
    [Header("InputSystem")]
    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference run;
    
    [Header("Tolerance value")] 
    [SerializeField] float tolerance;
    
    //Last input variables.
    private float _lastHorizontalInput = 0f;
    private float _lastVerticalInput = 0f;

    //Movement variables.
    private Vector2 _moveInput;
    private Vector3 _moveDirection;
    private Vector3 _viewForward = Vector3.zero;
    private Vector3 _viewRight = Vector3.zero;

    //Player simple state.
    public bool IsRunning { get; private set; }
    public bool IsWalking { get; private set; }

    //Rigidbody.
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _currentSpeed = defaultSpeed;
        GetNewCameraReference();
    }

    private void Update()
    {
        //gravity add.
        _rb.AddForce(Vector3.down * gravity);
        //Run system.
        if (run.action.IsPressed() && IsWalking)
        {
            IsRunning = true;
            _currentSpeed = runSpeed;
        }
        else
        {
            IsRunning = false;
            _currentSpeed = defaultSpeed;
        }
        //Input system.
        _moveInput = move.action.ReadValue<Vector2>();

        //GetCameraReference.
        if (_moveInput.magnitude > 0.1f)
        {
            IsWalking = true;
            if (Camera.main != null)
            {
                if (Math.Abs(_moveInput.x - _lastHorizontalInput) > tolerance || Math.Abs(_moveInput.y - _lastVerticalInput) > tolerance)
                {
                    GetNewCameraReference();
                }
                else if ((Math.Abs(_moveInput.x - _lastHorizontalInput) < tolerance || Math.Abs(_moveInput.y - _lastVerticalInput) < tolerance) && move.action.triggered)
                {
                    GetNewCameraReference();
                }
            }
        }
        else
        {
            IsWalking = false;
        }
        _moveInput = MapJoystickInput();
    }
   //Move direction calculation.
    private void FixedUpdate()
    {
        _moveDirection = _moveInput.y * _viewForward + _moveInput.x * _viewRight;
        if (_moveDirection.sqrMagnitude > 1f)
        {
            _moveDirection.Normalize();
        }
        if (_moveDirection.sqrMagnitude != 0f)
        {
            transform.forward = _moveDirection;
        }
        Move();
    }

    //Move method.
    private void Move()
    {
        _rb.velocity = _moveDirection * (_currentSpeed * Time.fixedDeltaTime);
    }
    //Get camera reference method.
    void GetNewCameraReference()
    {
        _viewForward = Camera.main.GetComponent<CameraFront>().GetRealFront().forward;
        _viewRight = Camera.main.GetComponent<CameraFront>().GetRealFront().right;
        _viewForward.y = 0f;
        _viewRight.y = 0f;
        _viewForward.Normalize();
        _viewRight.Normalize();
        _lastHorizontalInput = _moveInput.x;
        _lastVerticalInput = _moveInput.y;
    }
    //Unify values.
    private Vector2 MapJoystickInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        return new Vector2(x, y);
    }
}