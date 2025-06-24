using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallMultiplier;
    public InputAction action;
    private Rigidbody2D rb;
    private Vector2 vecgravity;
    private Animator animator;

    [SerializeField] private CapsuleCollider2D capsule;
    [SerializeField] private float checkDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    public bool IsGrounded()
    {
        Vector2 origin = capsule.bounds.center; // центр колайдера
        origin.y -= capsule.bounds.extents.y; // центр - половина висоти = самий низ

        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, checkDistance, groundLayer);
        return hit.collider != null;
    }


    //bool IsGrounded()
    //{
    //    ContactPoint2D[] contacts = new ContactPoint2D[10];
    //    int contactCount = rb.GetContacts(contacts);


    //    for (int i = 0; i < contactCount; i++)
    //    {
    //        if (contacts[i].collider.CompareTag("Platform")) // або перевірка по Layer'у
    //        {
    //            return true;
    //        }
    //    }

    //    return false;

    //}


    void Start()
    {
        vecgravity = new Vector2(0, -Physics2D.gravity.y); // змінює гравітацію з -9.81 на позитивне
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        action.Enable();
        //playerMove = GetComponent<PlayerMove>();
    }

    void Update()
    {

        //if(action.triggered && IsGrounded())
        //{
        //    //rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
        //    Debug.Log("X: " + rb.linearVelocityX);
        //    rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        //}

        if (action.triggered && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }


        if (rb.linearVelocityY < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime; // робиться приземлення. Чим більший falllMultiplier - тим швидше приземлення
        }

        animator.SetFloat("VerticalSpeed", rb.linearVelocityY);

    }
}
