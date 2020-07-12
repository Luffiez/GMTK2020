using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Distraction
{
    [SerializeField]
    float moveSpeed = 2;
    [SerializeField]
    float honkCooldown = 0.5f;
    [SerializeField]
    float honkRadius = 2;

    private float honkTimer = 0;
    Vector2 movementInput;
    Rigidbody2D rb;
    private bool isFacingRight = true;
    private bool isFacingUp;

    LineCircle circleRadius;
    Animator anim;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        circleRadius = GetComponentInChildren<LineCircle>();
        circleRadius.DoRenderer(radius);
    }

    private void Update()
    {
        anim.SetFloat("Horizontal", rb.velocity.x);
        anim.SetFloat("Vertical", rb.velocity.y);

        if (!gm.IsActiveScene)
            return;

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
        if (honkTimer > 0 || !gm.IsActiveScene)
            return;

        circleRadius.StartCoroutine(circleRadius.DisplayCircle(1f));

        gm.IncreaseHonks();
        honkTimer = honkCooldown;

        TriggerDistraction(transform.position, goose.position);
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
    }
    #endregion
}
