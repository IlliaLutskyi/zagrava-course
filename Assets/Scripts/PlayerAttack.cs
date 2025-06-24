using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    public InputAction punchAction;
    public Transform attackPoint; // точка удару (перед персонажем)
    public float attackRange = 0.5f;
    public LayerMask playerLayers;
    private Rigidbody2D rb;
    public float pushForce = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        punchAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator != null && punchAction.IsPressed())
        {
            animator.SetTrigger("Punch");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
            if(hitEnemies.Length > 0)
            {
                foreach (Collider2D enemy in hitEnemies)
                {

                    if (enemy.gameObject == this.gameObject) continue;

                    Rigidbody2D EnemyRB = enemy.GetComponent<Rigidbody2D>();
                    if (EnemyRB != null)
                    {
                        Vector2 pushDirection = (enemy.transform.position - transform.position).normalized;
                        EnemyRB.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
                    }
                }
            }
        }
    }
}
