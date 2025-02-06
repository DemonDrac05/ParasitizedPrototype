using UnityEngine;

public class Base : MonoBehaviour, IComponents, IVariables
{
    // --- ICOMPONENTS ----------
    public Rigidbody2D Rigidbody2D { get; protected set; }
    public Collider2D Collider2D { get; protected set; }
    public Animator Animator { get; protected set; }

    // --- IVARIABLES ----------
    public bool IsGrounded { get; protected set; }

    protected void InitilizeComponent()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Collider2D = GetComponent<Collider2D>();
        Animator = GetComponent<Animator>();
    }
}
