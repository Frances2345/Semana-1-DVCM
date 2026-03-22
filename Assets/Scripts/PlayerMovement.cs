using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    private InputSystem_Actions inputs;
    private Vector2 moveInput;
    public float speed = 7;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputs = new InputSystem_Actions();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        inputs.Enable();

        inputs.Player.Move.started += OnMove;
        inputs.Player.Move.performed += OnMove;
        inputs.Player.Move.canceled += OnMove;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }
    private void ApplyMovement()
    {
        Vector3 targetVelocity = new Vector3(moveInput.x, 0, moveInput.y) * speed;

        targetVelocity.y = rb.linearVelocity.y;
        rb.linearVelocity = targetVelocity;
    }


    private void OnDisable()
    {
        inputs.Player.Move.started -= OnMove;
        inputs.Player.Move.performed -= OnMove;
        inputs.Player.Move.canceled -= OnMove;

        inputs.Disable();
    }
}
