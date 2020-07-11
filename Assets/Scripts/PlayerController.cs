using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 2;
    [SerializeField]
    LayerMask gooseMask;

    [SerializeField]
    float honkCooldown = 0.5f;
    [SerializeField]
    float honkRadius = 2;
    [SerializeField]
    float forceStartPercent;
    [SerializeField]
    float maxForce;

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
        {
            FlipY();
        }

        if (honkTimer > 0)
            honkTimer -= Time.deltaTime;
    }
   
    private void Honk()
    {
        if (honkTimer > 0)
            return;

        honkTimer = honkCooldown;
        Debug.Log("honk!");
        Collider2D hit = Physics2D.OverlapCircle(transform.position, honkRadius, gooseMask);
       
        if(hit)
        {
            Debug.Log("Hit goose with honk, it's super effective!");
            Vector2 direction = (transform.position - hit.transform.position).normalized;
            float force = maxForce * 1 - forceStartPercent * (transform.position - hit.transform.position).sqrMagnitude / (honkRadius * honkRadius);
            hit.GetComponent<Rigidbody2D>().AddForce(direction * force);
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
        Debug.Log("Honk " + context.valueType);
    }
    #endregion
}
