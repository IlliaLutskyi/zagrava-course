using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] int movementspeed = 5;

    private Rigidbody2D rb; // ��������� �� ��������� Rigidbody2D ��� ��������� ����
    private Animator animator; // ��������� �� ��������� Animator ��� ��������� ���������
    private SpriteRenderer spriteRenderer; // ��������� �� ��������� SpriteRenderer ��� ��������� ��������� ������� (������������)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (rb == null)
        {
            Debug.LogError("RigidBody2d is null!");
        }
        if (animator == null)
        {
            Debug.LogError("Animator is null!");
        }
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer is null!");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveinput = Input.GetAxis("Horizontal") * movementspeed * Time.fixedDeltaTime;

        transform.Translate(new Vector3(moveinput, 0, 0));
        //rb.linearVelocity = new Vector2(moveinput, rb.linearVelocityY);

        if (animator != null)
        {
            animator.SetBool("isRunning", moveinput != 0);
        }

        if (moveinput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveinput < 0)
        {
            spriteRenderer.flipX = true;
        }

    }
}
