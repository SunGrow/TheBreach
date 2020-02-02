using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public LayerMask fixableObjectsLayers;
    public float fixRadius = 1f;

    private Vector2 m_Move;

    

    // Update is called once per frame

    private void FixedUpdate()
    {
        Move(m_Move);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        m_Move = context.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        animator.SetTrigger("Fix");
        Collider2D[] triggeredFixableObjects = Physics2D.OverlapCircleAll(rb.position, fixRadius, fixableObjectsLayers);
        foreach(Collider2D barrel in triggeredFixableObjects)
        {
            barrel.GetComponent<FixableObject>().Repair();
        }
    }
    
    private void Move(Vector2 direction)
    {
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        animator.SetFloat("Horisontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    private void OnDrawGizmosSelected()
    {
        if (rb == null)
            return;
        Gizmos.DrawWireSphere(rb.position, fixRadius);
    }
}
