using UnityEngine;

public class Player : Base
{
    public LayerMask Ground;
    public float jumpForce;
    public bool IsMoveable { get; private set; } = true;
    

    private void OnEnable()
    {
        InitilizeComponent();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Rigidbody2D.linearVelocityY = jumpForce;
            Animator.Play("Jump");
        }
        else if (Input.GetKey(KeyCode.K))
        {
            Animator.SetTrigger("Attack");
        }
    }

    private void FixedUpdate()
    {
        IsGrounded = Physics2D.BoxCast(Collider2D.bounds.center, Collider2D.bounds.size, 0f, Vector2.down, .1f, Ground);
    }
}
