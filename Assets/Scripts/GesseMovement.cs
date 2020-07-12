using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GesseMovement : MonoBehaviour
{

    Rigidbody2D rigidbody;
    [SerializeField]
    float maxSpeed;
    GameManager gm;

    bool isFacingRight = true;

    Animator anim;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        gm = GameManager.instance;
        anim = GetComponent<Animator>();
    }

    void LateUpdate()
    {
        anim.SetFloat("Horizontal", rigidbody.velocity.x);
        anim.SetFloat("Vertical", rigidbody.velocity.y);

        if (!gm.IsActiveScene)
            return;

        if (rigidbody.velocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            float magnitude = rigidbody.velocity.magnitude;
            float deltaSpeed = magnitude - maxSpeed;
            rigidbody.velocity = Vector2.ClampMagnitude( rigidbody.velocity,maxSpeed);
        }

        if(rigidbody.velocity.x > 0.1 && !isFacingRight ||
            rigidbody.velocity.x < -0.1 && isFacingRight)
        {
            FlipX();
        }

    }

    public void Addforce(Vector2 force)
    {
        rigidbody.AddForce(force);
    }

    void FlipX()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
    }
}
