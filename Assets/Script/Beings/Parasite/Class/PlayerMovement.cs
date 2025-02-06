using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("=== Movement Properties ==========")]
    [SerializeField] public float jumpForce = 14f;
    [SerializeField] public float moveSpeed = 10f;

    // --- MOVEMENT INPUT PROPERTIES -----------
    [HideInInspector] public float posX;
    [HideInInspector] public float posY;

    // --- FLIPPING PROPERTIES ----------
    public bool IsFacingRight { get; private set; } = true;
    private Vector3 _flip;

    // --- SINGLETON CLASS ----------
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        UpdateFlip();
    }

    private void Update()
    {
        InputMovement(out posX, out posY);

        player.Rigidbody2D.linearVelocityX = posX * moveSpeed;
        if (player.IsGrounded)
        {
            if (posX != 0f)
            {
                player.Animator.SetBool("isMoving", true);
                player.Animator.Play("Run");
            }
            else
            {
                player.Animator.SetBool("isMoving", false);
                player.Animator.Play("Idle");
            }
            Debug.Log("On Ground");
        }
        else if (!player.IsGrounded) 
        {
            if (posY < .1f)
            {
                player.Animator.Play("Fall");
            }
            else
            {
                player.Animator.Play("Jump");
            }
        }
    }

    public void UpdateFlip()
    {
        if (posX > 0 && !IsFacingRight)
        {
            CheckIsFacingRight();
        }
        else if (posX < 0 && IsFacingRight)
        {
            CheckIsFacingRight();
        }
    }

    public void CheckIsFacingRight()
    {
        if (!player.IsMoveable) return;

        IsFacingRight = !IsFacingRight;

        _flip = transform.localScale;
        _flip.x = -1;

        float yRot = _flip.x > 0 ? 0f : 180f;
        transform.Rotate(0, yRot, 0);
    }

    public Vector3 GetFlip() => _flip;

    public void InputMovement(out float horizontal, out float vertical)
    {
        horizontal = !player.IsMoveable ? 0f : Input.GetAxisRaw("Horizontal");
        vertical = !player.IsMoveable ? 0f : Input.GetAxisRaw("Vertical");
    }
}
