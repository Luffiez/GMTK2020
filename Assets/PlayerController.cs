using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2;
    public float honkCooldown = 0.5f;
    public float honkRadius = 2;
    public LayerMask gooseMask;

    private float honkTimer = 0;
    Vector2 movementInput;
    Rigidbody2D rb;
    private bool isFacingRight;
    private bool isFacingUp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = movementInput * moveSpeed;

        if(rb.velocity.x > 0 && !isFacingRight ||
            rb.velocity.x <0 && isFacingRight)
        {
            FlipX();
        }
        if(rb.velocity.y > 0 && !isFacingUp ||
            rb.velocity.y < 0 && isFacingUp)

        if (honkTimer > 0)
            honkTimer -= Time.deltaTime;
    }
   
    private void Honk()
    {
        if (honkTimer > 0)
            return;

        honkTimer = honkCooldown;
        Debug.Log("honk!");
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, honkRadius, transform.up,Mathf.Infinity, gooseMask);
       
        if(hit)
        {
            // send honk message to goose!
        }
    }

    void FlipX()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
    }

    void FlipY()
    {
        isFacingUp = !isFacingUp;
    }

    #region Inputs
    public void MoveInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void HonkInput(InputAction.CallbackContext context)
    {
        Honk();
        Debug.Log("Honk");
    }
    #endregion
}
