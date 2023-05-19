using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    private Animator animator;
    private int isRunningHash;

    private PlayerInput playerInput;
    private Rigidbody rb;

    private Vector2 currentMovementInput;
    private Vector3 currentMovement;
    [Header("Dirección")]
    private Vector3 finalDirection;
    [Header("Velocidad")]
    [SerializeField] private float rotationVelocity = 300.0f;
    [SerializeField] private float playerSpeed = 10.0f;
    bool isMovementPressed;
    [Header("Salto")]
    [SerializeField] private float jumpForce = 10f; // La fuerza con la que el personaje saltará
    [SerializeField] private float jumpDuration = 0.5f; // La duración en segundos que durará el salto
    [SerializeField] private int maxJumpCount = 2; // El número máximo de saltos que el jugador puede hacer

    [SerializeField] private bool isJumping = false; // Indica si el personaje está saltando
    [SerializeField] private float jumpTimer = 0f; // Contador para controlar la duración del salto
    [SerializeField] private float DelayDoubleJump = 0.2f; // Contador para controlar la duración del salto

    private int jumpCount = 0; // Contador para controlar el número de saltos
    [SerializeField] private bool canDoubleJump = false; // Nueva variable para el doble salto
    private bool isGrounded = false; // Indica si el personaje está tocando el suelo



    private void Awake()
    {

        playerInput = new PlayerInput();
        rb = GetComponent<Rigidbody>();

        animator = GetComponentInChildren<Animator>();

        playerInput.Player.Move.started += onMovementInput;
        playerInput.Player.Move.canceled += onMovementInput;
        playerInput.Player.Move.performed += onMovementInput;

        playerInput.Player.Jump.started += onJumpInput;
        playerInput.Player.Jump.canceled += onJumpInput;
        playerInput.Player.Jump.performed += onJumpInput;
    }

    // Start is called before the first frame update
    void Start()
    {
        isRunningHash = Animator.StringToHash("isRunning");

    }

    // Update is called once per frame
    void Update()
    {
        if (isJumping)
        {
            jumpTimer += Time.deltaTime;

            if (jumpTimer > jumpDuration)
            {
                isJumping = false;
                jumpCount = 0;
                canDoubleJump = false;
            }
        }
        // Mover al personaje
        Move();
        playerAnimation();
    }

    void onMovementInput(InputAction.CallbackContext ctx)
    {
        currentMovementInput = ctx.ReadValue<Vector2>();
        //Se ingresa el Input X el Vector3.x
        currentMovement.x = currentMovementInput.x;
        currentMovement.y = 0;
        //Se ingresa el Input Y el Vector3.z
        currentMovement.z = currentMovementInput.y;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;

    }

    void onJumpInput(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValueAsButton() && isGrounded)
        {
            Jump();
        }
        else if (ctx.ReadValueAsButton() && canDoubleJump)
        {
            DoubleJump();
        }
    }

    void Move()
    {
        if (isMovementPressed)
        {

        // Obtiene la rotación actual del objeto con Rigidbody
        Quaternion currentRotation = rb.transform.rotation;

        // Obtiene la dirección hacia adelante en base al input de movimiento del usuario
        Vector3 forwardDirection = Vector3.forward * currentMovement.z;

        // Calcula la rotación actual en formato Quaternion
        Quaternion currentRotationQuaternion = Quaternion.Euler(0f, currentRotation.eulerAngles.y, 0f);

        // Combina la dirección hacia adelante con la rotación actual para obtener la dirección de movimiento final
        Vector3 currentDirection = currentRotationQuaternion * forwardDirection;

        // Multiplica la dirección de movimiento por la velocidad del jugador para obtener la velocidad final en cada eje
        finalDirection.x = currentDirection.x * playerSpeed;
        finalDirection.z = currentDirection.z * playerSpeed;

        // Rota el objeto en el eje Y en base al input de rotación del usuario
        rb.transform.Rotate(new Vector3(0f, currentMovement.x * rotationVelocity, 0f) * Time.deltaTime);

        // Mueve el objeto en base a la velocidad final en cada eje multiplicada por el tiempo transcurrido
        rb.MovePosition(rb.position + finalDirection * Time.deltaTime);
        }
    }

   void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            jumpTimer = 0f;
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            StartCoroutine(WaitForDoubleJump());
        }
    }

    IEnumerator WaitForDoubleJump()
    {
        yield return new WaitForSeconds(DelayDoubleJump);
        canDoubleJump = true;
    }
    void DoubleJump()
    {
        if (jumpCount < maxJumpCount)
        {
            jumpCount++;
            canDoubleJump = false;
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }
    void playerAnimation()
    {
        bool isRunning = animator.GetBool(isRunningHash);

        if (isMovementPressed && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }
        else if (!isMovementPressed && isRunning)
        {
            animator.SetBool(isRunningHash, false);
        }
    }

    
    

   void FixedUpdate()
    {
        // Verifica si el jugador está en el suelo
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.2f);
        
        // Actualizar el temporizador del salto
        if (isGrounded)
        {
            jumpCount = 0;
            isJumping = false;
            isGrounded = true;
            canDoubleJump = false;
        }
    }

    void OnEnable()
    {
        playerInput.Player.Enable();
    }
    void OnDisable()
    {
        playerInput.Player.Disable();
    }
}