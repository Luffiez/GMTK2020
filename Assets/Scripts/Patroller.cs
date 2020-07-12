using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    Transform[] points;
    [SerializeField]
    Transform spriteTransform;
    int index = 0;
    Vector2 direction;
    Vector2 point1;
    Vector2 point2;
    float sqrStartLength;
    bool isFacingRight = true;

    GameManager gm;

    private void Start()
    {
        point1 = points[index].position;
        index++;
        point2 = points[index].position;
        sqrStartLength = (point1 - point2).sqrMagnitude;
        direction = (point2 - point1).normalized;
        transform.position = new Vector3(point1.x, point1.y, transform.position.z);
        gm = GameManager.instance;
    }

    private void Update()
    {
        if (!gm.IsActiveScene)
            return;

        if (direction.x > 0.1 && !isFacingRight || direction.x < -0.1 && isFacingRight)
        {
            isFacingRight = !isFacingRight;
            spriteTransform.localScale = new Vector3(spriteTransform.localScale.x * -1, spriteTransform.localScale.y, spriteTransform.localScale.z);
        }
            

        transform.position = transform.position + (Vector3)direction * speed * Time.deltaTime;
        float sqrLength = ((Vector2)transform.position - point1).sqrMagnitude;
        if (sqrLength > sqrStartLength)
        {
            transform.position = new Vector3(point2.x, point2.y, transform.position.z);
            point1 = point2;
            index++;
            if (index >= points.Length)
            {
                index = 0;
                point2 = points[index].position;
            }
            else
            {
                point2 = points[index].position;
            }

            sqrStartLength = (point1 - point2).sqrMagnitude;
            direction = (point2 - point1).normalized;
        }
    }
}
