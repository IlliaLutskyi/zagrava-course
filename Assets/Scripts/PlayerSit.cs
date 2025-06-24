using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSit : MonoBehaviour
{

    private Animator animator;
    public InputAction sitAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        sitAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator != null && sitAction.IsPressed())
        {
            animator.SetBool("isSitting", true);
            StartCoroutine(ResetPunch());
        }
    }

    IEnumerator ResetPunch()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("isSitting", false);
    }
}
