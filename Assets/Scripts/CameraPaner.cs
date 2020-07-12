using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPaner : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    Transform pointsParent;
    List<Transform> points = new List<Transform>();
    int index = 0;
    Vector2 direction;
    Vector2 point1;
    Vector2 point2;
    float sqrStartLength;
    GameManager gm;

    private void Start()
    {
        points.AddRange(pointsParent.GetComponentsInChildren<Transform>());
        points.Remove(pointsParent);
        points.Reverse();

        point1 =  points[index].position;
        index++;
        point2 = points[index].position;
        sqrStartLength = (point1 - point2).sqrMagnitude;
        direction = (point2 - point1).normalized;
        transform.position = new Vector3(point1.x, point1.y, transform.position.z);
        gm = GameManager.instance;
    }

    private void Update()
    {
        transform.position = transform.position +(Vector3)direction * speed * Time.deltaTime;
        float sqrLength = ((Vector2)transform.position - point1).sqrMagnitude;
        if (sqrLength > sqrStartLength)
        {
            transform.position = new Vector3( point2.x, point2.y, transform.position.z);
            point1 = point2;
            index++;
            if (index >= points.Count)
            {
                //done call event
                gm.SetSceneState(true);
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
