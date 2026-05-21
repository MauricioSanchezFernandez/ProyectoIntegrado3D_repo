using UnityEngine;
using UnityEngine.InputSystem;

public class CarMovement : MonoBehaviour
{
    public float forwardSpeed = 20f;
    public float turnSpeed = 8f;

    public float xLimit = 6f;

    [Header("Speed Increase")]
    public float speedIncreaseAmount = 2f;
    public float distanceForIncrease = 100f;

    private float nextDistanceThreshold = 100f;

    private Vector2 moveInput;
    private InputSystem_Actions inputActions;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
    }

    private void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        // Movimiento hacia delante
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Movimiento lateral
        Vector3 pos = transform.position;
        pos.x += moveInput.x * turnSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -xLimit, xLimit);

        transform.position = pos;

        // Aumento velocidad
        float distance = transform.position.z;

        if (distance >= nextDistanceThreshold)
        {
            forwardSpeed += speedIncreaseAmount;

            nextDistanceThreshold += distanceForIncrease;
        }
    }
}