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

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        gm = GameManager.instance;
    }

    void LateUpdate()
    {
        if (!gm.IsActiveScene)
            return;

        if (rigidbody.velocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            float magnitude = rigidbody.velocity.magnitude;
            float deltaSpeed = magnitude - maxSpeed;
            rigidbody.velocity = Vector2.ClampMagnitude( rigidbody.velocity,maxSpeed);
        }
    }

    public void Addforce(Vector2 force)
    {
        rigidbody.AddForce(force);
    }
}
