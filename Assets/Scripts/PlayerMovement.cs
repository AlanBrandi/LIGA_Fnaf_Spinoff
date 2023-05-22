using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;


public class PlayerMovement : MonoBehaviour
{
    //Como funciona a camera: Basicamente toda colisão trigger com os lugares para trocar de camera, ele chama o método de trocar a referencia do jogador, assim atualiza qual a frente de fato.
    //Economiza muito mais do que, ficar chamando no update toda vez que o jogador andasse.
    
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
        ChangeCameraReference();
    }

    private void Update()
    {
        //gravity add.
        //_rb.AddForce(Vector3.down * gravity);
        
        
        //Trocar do updpate aqui.
        //Run system.
        if (run.action.IsPressed() && IsWalking)
        {
            IsRunning = true;
            _currentSpeed = runSpeed;
        }
        else if(run.action.WasReleasedThisFrame())
        {
            IsRunning = false;
            _currentSpeed = defaultSpeed;
        }
        
        //Input system.
        _moveInput = move.action.ReadValue<Vector2>();

        //State change.
        if (_moveInput.magnitude < 0.1f)
        {
            IsWalking = false;
        }
        else
        {
            IsWalking = true;
        }
        //InputNormalize.
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
    //Get camera reference method(Chama esse script, toda colisão trigger).
    public void GetNewCameraReference()
    {
        if (Camera.main != null)
        {
            if (Math.Abs(_moveInput.x - _lastHorizontalInput) > tolerance ||
                Math.Abs(_moveInput.y - _lastVerticalInput) > tolerance)
            {
                ChangeCameraReference();
            }
            else if ((Math.Abs(_moveInput.x - _lastHorizontalInput) < tolerance ||
                      Math.Abs(_moveInput.y - _lastVerticalInput) < tolerance) && move.action.triggered)
            {
                ChangeCameraReference();
            }
        }
    }
    private void ChangeCameraReference()
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