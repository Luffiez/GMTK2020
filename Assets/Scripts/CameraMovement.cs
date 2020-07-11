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
    float sqrStartLength;
    [SerializeField]
    GameObject gooseObject;
    private void Start()
    {
        //gooseObject = GameObject.FindGameObjectWithTag("gesse");
        point1 = points[index].position;
        index++;
        point2 = points[index].position;
        sqrStartLength = (point1 - point2).sqrMagnitude;
        direction = (point2 - point1).normalized;
        transform.position = new Vector3(point1.x, point1.y, transform.position.z);
    }

    private void Update()
    {
        float scalar = Vector2.Dot((Vector2)gooseObject.transform.position -  (Vector2)transform.position, direction);
        Vector2 target = direction * scalar;
        if(scalar > 0.1f || scalar < -0.1f)
        transform.position = transform.position + (Vector3)(((Vector2)transform.position + target)  - (Vector2)transform.position).normalized * speed * Time.deltaTime;

        float sqrLength = ((Vector2)transform.position - point1).sqrMagnitude;
        if (sqrLength > sqrStartLength)
        {
            transform.position = new Vector3(point2.x, point2.y, transform.position.z);
            point1 = point2;
            index++;
            if (index >= points.Length)
            {
                //done call event
                Destroy(this);
            }
            else
            {
                point2 = points[index].position;
                sqrStartLength = (point1 - point2).sqrMagnitude;
                direction = (point2 - point1).normalized;
            }
        }
    }
}
