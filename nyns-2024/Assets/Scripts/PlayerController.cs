using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _cameraSens;

    [SerializeField]
    [Tooltip("When adjusting the movement speed, also adjust the rigidbody's drag to reduce sliding.")]
    private float _movementSpeed;

    [SerializeField]
    private Transform _cameraOrientation;
    
    [SerializeField]
    private Transform _playerOrientation;

    [SerializeField]
    private Rigidbody _playerRigidbody;

    private float _xRotation;
    private float _yRotation;
    private InputAction _playerLook;
    private InputAction _playerMovement;
    private PlayerControls _playerControls;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        _playerControls = new PlayerControls();

        _playerLook = _playerControls.FindAction("Look");
        _playerMovement = _playerControls.FindAction("Movement");
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void FixedUpdate()
    {
        HandleLook();
        HandleMovement();
    }

    private void HandleLook()
    {
        Vector2 userInput = _playerLook.ReadValue<Vector2>() * _cameraSens * Time.deltaTime;

        _yRotation += userInput.x;
        _xRotation = Mathf.Clamp(_xRotation - userInput.y, -90f, 90f);

        _cameraOrientation.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        _playerOrientation.rotation = Quaternion.Euler(0, _yRotation, 0);
    }

    private void HandleMovement()
    {
        Vector2 userInput = _playerMovement.ReadValue<Vector2>();
        Vector3 moveDirection = _playerOrientation.forward * userInput.y + _playerOrientation.right * userInput.x;

        _playerRigidbody.AddForce(moveDirection.normalized * _movementSpeed * 10f, ForceMode.Force);
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }
}
