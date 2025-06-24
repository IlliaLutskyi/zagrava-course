using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Move : MonoBehaviour
{


    private Rigidbody2D rb;
    private Animator animator;
    public InputAction moveAction;
    public float speed = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveAction.Enable();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();

        Vector2 position = rb.position + move * speed * Time.fixedDeltaTime;


        rb.MovePosition(position);

        if (animator != null)
        {
            animator.SetBool("isRunning", move.x != 0);
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
        if (direction == "right")
        {
           transform.rotation = Quaternion.Euler(0, 0, 0);


        }
        else if (direction == "left")
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}