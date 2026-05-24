using UnityEngine;
using UnityEngine.InputSystem;

public class CarMovement : MonoBehaviour
{
    public float forwardSpeed = 20f;
    public float turnSpeed = 8f;

    [Header("Road Settings")]
    public Transform roadCenter;
    public float roadWidth = 6f;

    [Header("Speed Increase")]
    public float speedIncreaseAmount = 2f;
    public float distanceForIncrease = 100f;

    private float nextDistanceThreshold = 100f;
    private Animator anim;

    private Vector2 moveInput;
    private InputSystem_Actions inputActions;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        anim = GetComponent<Animator>();
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
        //  movimiento hacia delante
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        //  movimiento lateral RELATIVO A LA CARRETERA
        Vector3 pos = transform.position;

        pos.x += moveInput.x * turnSpeed * Time.deltaTime;

        //  límites basados en el centro de la carretera
        float leftLimit = roadCenter.position.x - roadWidth;
        float rightLimit = roadCenter.position.x + roadWidth;

        pos.x = Mathf.Clamp(pos.x, leftLimit, rightLimit);

        transform.position = pos;

        // ANIMACIONES
        if (moveInput.x < -0.1f)
        {
            anim.SetBool("turnLeft", true);
            anim.SetBool("turnRight", false);
        }
        else if (moveInput.x > 0.1f)
        {
            anim.SetBool("turnLeft", false);
            anim.SetBool("turnRight", true);
        }
        else
        {
            anim.SetBool("turnLeft", false);
            anim.SetBool("turnRight", false);
        }

        //  aumento de velocidad por distancia
        float distance = transform.position.z;

        if (distance >= nextDistanceThreshold)
        {
            forwardSpeed += speedIncreaseAmount;
            nextDistanceThreshold += distanceForIncrease;
        }
    }
}