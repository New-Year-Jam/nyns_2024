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

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void FixedUpdate()
    {
        HandleLook();
        HandleMovement();
    }

    private void HandleLook()
    {
        float xMouseInput = Input.GetAxisRaw("Mouse X") * _cameraSens * Time.deltaTime;
        float yMouseInput = Input.GetAxisRaw("Mouse Y") * _cameraSens * Time.deltaTime;

        _yRotation += xMouseInput;
        _xRotation = Mathf.Clamp(_xRotation - yMouseInput, -90f, 90f);

        _cameraOrientation.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        _playerOrientation.rotation = Quaternion.Euler(0, _yRotation, 0);
    }

    private void HandleMovement()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");
        float zMovement = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = _playerOrientation.forward * zMovement + _playerOrientation.right * xMovement;

        _playerRigidbody.AddForce(moveDirection.normalized * _movementSpeed * 10f, ForceMode.Force);
    }
}
