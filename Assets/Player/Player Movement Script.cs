using UnityEngine;    // directory for Unity functions
using UnityEngine.InputSystem;    // directory for input system functions

public class PlayerMovementScript : MonoBehaviour
{


    // ---VARIABLES---


    [Header("Variable References")]    // headers & spaces organize this script in the inspector
    [Space(5)]
    public InputSystem_Actions actions;    // link to the input system
    public float moveInputValue;   // nonpublic variables such as this will not appear in the inspector
    Rigidbody2D rb;
    public Animator playerAnimator;   // link to the player animator
    public SpriteRenderer playerSprite;

    [Space(10)]
    [Header("Player Stat Values")]
    [Space(5)]
    [Range(0f, 20f)] public float speed;    // controls player move speed, range constricts this value to a min and max, 'f' stands for "float" (a number data type)
    [Range(0f, 20f)] public float jumpForce;    // controls player jump force variable & range

    [Space(10)]
    [Header("Jump Conditions")]
    [Space(5)]
    public Transform groundCheckTransform;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isGrounded;


    // ---UNITY LIBRARY FUNCTIONS---


    // Awake is called first of all, even if the object attached to the script (or the script) is disabled
    private void Awake()
    {
        Cursor.visible = false;
        actions = new InputSystem_Actions();
    }

    // OnEnable is called anytime after Awake whenever this script is enabled
    private void OnEnable()
    {
        actions.Player.Enable();   // inputs are disabled by default at start, so we enable them here
        actions.Player.Move.performed += Moves;    // looks for "Move" in the Input Actions Editor, uses it on Move method when Move input is received
        actions.Player.Jump.performed += Jumps;

        actions.Player.Move.canceled += Moves;
        actions.Player.Jump.canceled += Jumps;
    }

    // OnEnable is called whenever this script is disabled
    private void OnDisable()
    {
        actions.Player.Disable();
        actions.Player.Move.performed -= Moves;
        actions.Player.Jump.performed -= Jumps;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    // references the Rigidbody2D component of the script's parent game object (Player)
    }

    // Late Update is called 50x / second
    void LateUpdate()
    {
        rb.linearVelocityX = moveInputValue * speed;
        isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundLayer);

        if (rb.linearVelocityY == 0)
        {
            playerAnimator.SetBool("isJumping", false);
        }
        if (rb.linearVelocityX == 0)
        {
            playerAnimator.SetBool("isMoving", false);
        }

        // flip sprite left and right to match input:
        if (rb.linearVelocityX > 0)
        {
            playerSprite.flipX = false;
        }
        else
        {
            playerSprite.flipX = true;
        }
    }


    // ---CUSTOM FUNCTIONS---


    void Moves(InputAction.CallbackContext ctx)
    {
        moveInputValue = ctx.ReadValue<Vector2>().x;
        if (isGrounded)
        {
            playerAnimator.SetBool("isMoving", true);
        }
        else
        {
            playerAnimator.SetBool("isMoving", false);
        }
    }

    void Jumps(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)    // if condition restricts this code to on jump key down and not jump key up, prevents jumps on release of jump key
        {
            if (isGrounded)    // if condition restricts this code to when isGrounded is true, prevents mid-air jumps
            {
                rb.linearVelocityY = jumpForce;
                playerAnimator.SetBool("isJumping", true);
            }
        }
        else if (ctx.canceled)
        {
            playerAnimator.SetBool("isJumping", false);
            playerAnimator.Play("Player Jump Cancel Anim");
        }
    }

    void OnDrawGizmosSelected()   // visualize player movement in scene view
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckTransform.position, groundCheckRadius);
    }


}


