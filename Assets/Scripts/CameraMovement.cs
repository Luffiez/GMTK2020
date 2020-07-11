using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    Transform[] points;
    int index = 0;
    Vector2 direction;
    Vector2 point1;
    Vector2 point2;
    [SerializeField]
    float pointRadius = 0.6f;
    float sqrStartLength;
    [SerializeField]
    GameObject gooseObject;
    Rigidbody2D gooseRigidbody;
    GameManager gm;

    private void Start()
    {
        //gooseObject = GameObject.FindGameObjectWithTag("gesse");
        point1 = points[index].position;
        index++;
        point2 = points[index].position;
        sqrStartLength = (point1 - point2).sqrMagnitude;
        direction = (point2 - point1).normalized;
        transform.position = new Vector3(point1.x, point1.y, transform.position.z);
        gooseRigidbody = gooseObject.GetComponent<Rigidbody2D>();
        gm = GameManager.instance;
    }

    private void Update()
    {
        if (!gm.IsActiveScene)
            return;
        float scalar = Vector2.Dot((Vector2)gooseObject.transform.position -  (Vector2)transform.position, direction);
        Vector2 target = direction * scalar;
        if(scalar > 0.1f || scalar < -0.1f)
        transform.position = transform.position + (Vector3)(((Vector2)transform.position + target)  - (Vector2)transform.position).normalized * speed * Time.deltaTime;
        float sqrLength = ((Vector2)transform.position - point1).sqrMagnitude;
        float directionScalar = Vector2.Dot(gooseRigidbody.velocity, direction);
        if (sqrLength >= sqrStartLength - (pointRadius*pointRadius) && directionScalar > 0)
        {
            point1 = point2;
            index++;
            if (index <points.Length)
            { 
                point2 = points[index].position;
                sqrStartLength = (point1 - point2).sqrMagnitude;
                direction = (point2 - point1).normalized;
            }
        }
        float sqrLength2 = ((Vector2)transform.position - point2).sqrMagnitude;
        if (sqrLength2 >= sqrStartLength - (pointRadius * pointRadius) && directionScalar < 0)
        {
            index-=2;
            if (index < 0)
            {
                index = 0;
            }
            else
            {
                point2 = point1;
                point1 = points[index].position;
                sqrStartLength = (point1 - point2).sqrMagnitude;
                direction = (point2 - point1).normalized;
            }
            index++;
        }
    }
}
