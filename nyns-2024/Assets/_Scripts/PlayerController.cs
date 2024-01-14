using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _interactDistance;

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
    
    [SerializeField] Signal cameraLock;
    bool previousCameraLock;

    [SerializeField] Signal movementLock;
    bool previousMovementLock;

    [SerializeField] GameObject _interactivity;

    private void Awake() {
        UnlockCamera();
        movementLock.changeState(false);
    }
    private void Update() {
        HandleLook();

        // Handle Camera Locking
        bool currentLockState = cameraLock.getState();
        if (previousCameraLock != currentLockState)
        {
            previousCameraLock = currentLockState;
            if (currentLockState == true)
            {
                LockCamera();
                _interactivity.SetActive(false);
            } 
            else
            {
                UnlockCamera();
            }
        }
    }
    private void FixedUpdate() {
        // Handle movement locking
        bool currentMovementState = movementLock.getState();
        if (currentMovementState == false)
        {
            HandleMovement();
            HandleInteractions();
        }
    }
    public void LockCamera()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;      
    }

    public void UnlockCamera()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;  
    }

    private void HandleLook()
    {
        if (!cameraLock.getState())
        {
            float xMouseInput = Input.GetAxisRaw("Mouse X") * _cameraSens * Time.deltaTime;
            float yMouseInput = Input.GetAxisRaw("Mouse Y") * _cameraSens * Time.deltaTime;

            _yRotation += xMouseInput;
            _xRotation = Mathf.Clamp(_xRotation - yMouseInput, -90f, 90f);

            _cameraOrientation.rotation = Quaternion.Euler(_xRotation, _yRotation, 0.0f);
            _playerOrientation.rotation = Quaternion.Euler(0.0f, _yRotation, 0.0f);            
        }
    }

    private void HandleMovement()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");
        float zMovement = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = _playerOrientation.forward * zMovement + _playerOrientation.right * xMovement;

        _playerRigidbody.AddForce(moveDirection.normalized * _movementSpeed * 10f, ForceMode.Force);
    }

    private void HandleInteractions()
    {
        Vector3 playerPosition = _cameraOrientation.position;
        Vector3 crosshairDirection = _cameraOrientation.TransformDirection(Vector3.forward);

        if (Physics.Raycast(playerPosition, crosshairDirection, out RaycastHit hit, _interactDistance))
        {
            Interactable interactableObj = hit.collider.gameObject.GetComponent<Interactable>();

            if (interactableObj)
            {
                _interactivity.SetActive(true);
                if (Input.GetButton("Interact"))
                {
                    interactableObj.Action();
                }
            }
            else
            {
                _interactivity.SetActive(false);
            }
        }
        else
        {
            _interactivity.SetActive(false);
        }
    }
}
