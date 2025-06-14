using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class StickmanAttack : MonoBehaviour
{

    private Animator animator;
    private bool isPunch = false;
    public InputAction punchAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        punchAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator != null && punchAction.IsPressed() && !isPunch)
        {
            isPunch = true;
            animator.SetBool("Punch", true);
            StartCoroutine(ResetPunch());
        }
    }

    IEnumerator ResetPunch()
    {
        yield return new WaitForSeconds(0.4f);
        isPunch = false;
        animator.SetBool("Punch", false);
    }
}
