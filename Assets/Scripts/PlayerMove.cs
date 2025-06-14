using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{


    private Rigidbody2D rd;
    private Animator animator;
    public InputAction moveAction;
    public SpriteRenderer sr;
    public float speed = 3f;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        moveAction.Enable();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();

        Vector2 position = (Vector2)rd.position + move * Time.deltaTime * speed;
        rd.MovePosition(position);
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
            sr.flipX = false;
        }
        else if (direction == "left")
        {
            sr.flipX = true;
        }
    }
}