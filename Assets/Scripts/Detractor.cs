using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detractor : MonoBehaviour
{
    [SerializeField]
    LayerMask layerMask;
    [SerializeField]
    float radius;
    [SerializeField]
    float forceStartPercent;
    [SerializeField]
    float maxForce;
    // Update is called once per frame
    void FixedUpdate()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, layerMask);
        if (hit != null)
        {
            Debug.Log("hit");
            Vector2 direction = (transform.position - hit.transform.position).normalized;
            float force = maxForce * 1 - forceStartPercent * (transform.position - hit.transform.position).sqrMagnitude / (radius * radius);
            hit.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
    }
}
