using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Flee : MonoBehaviour
{
    [SerializeField]
    float maxSpeed;
    [SerializeField]
    float maxDistance;
    [SerializeField]
    float force;
    GameObject gesseObject;
    Rigidbody2D rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        gesseObject = GameObject.FindGameObjectWithTag("Gesse");
    }

    private void FixedUpdate()
    {
        Vector2 gessePosition = gesseObject.transform.position;
        Vector2 position = transform.position;
        float sqrMagnitude = (gessePosition - position).sqrMagnitude;
        if (sqrMagnitude < maxDistance*maxDistance)
        {
            Vector2 direction = (position - gessePosition).normalized;
            rigidbody.AddForce(direction * force);
        }
    }

    private void LateUpdate()
    {
        if (rigidbody.velocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            rigidbody.velocity = Vector2.ClampMagnitude(rigidbody.velocity, maxSpeed);
        }
    }
}
