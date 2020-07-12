using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distraction : MonoBehaviour
{
    [SerializeField]
    protected LayerMask layerMask;
    [SerializeField]
    protected float radius;
    [SerializeField]
    protected float forceStartPercent;
    [SerializeField]
    protected float maxForce;

    protected Rigidbody2D goose;

    protected GameManager gm;

    private void Start()
    {
        goose = GameObject.FindGameObjectWithTag("Gesse").GetComponent<Rigidbody2D>();

        if (!goose)
        {
            Debug.LogError("Can't find ze goose!!");
        }
        gm = GameManager.instance;
    }

    protected void TriggerDistraction(Vector2 pos1, Vector2 pos2)
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, layerMask);
        if (hit != null)
        {
            Vector2 direction = (pos1 - pos2).normalized;
            float force = maxForce * 1 - forceStartPercent * (transform.position - hit.transform.position).sqrMagnitude / (radius * radius);
            goose.AddForce(direction * force);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
