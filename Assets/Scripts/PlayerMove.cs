using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] private InputAction moveAction;
    [SerializeField] private float speed = 3f;
    private Vector2 move;

    public Transform visual; // <-- посилання на Visual GameObject

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
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        moveAction.Enable();
    }

    void FixedUpdate()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();

        rb.linearVelocity = new Vector2(move.x * speed, rb.linearVelocity.y); // тепер X оновлюється завжди

        if(move.x != 0 && IsGrounded())
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (move.x > 0)
        {
            Flip("right");
        }
        else if (move.x < 0)
        {
            Flip("left");
        }

    }


    public void Flip(string direction)
    {
        Vector3 scale = visual.localScale;

        if (direction == "right")
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else if (direction == "left")
        {
            scale.x = -Mathf.Abs(scale.x);
        }

        visual.localScale = scale;
    }
}
