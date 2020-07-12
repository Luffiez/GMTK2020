using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class LineCircle : MonoBehaviour
{
    [Range(3, 256)]
    public int numSegments = 64;
    public Color color;
    LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.endColor = color;
        lr.startColor = color;
    }

    public IEnumerator DisplayCircle(float duration)
    {
        lr.enabled = true;
        Color offColor = new Color(color.r, color.g, color.b, 0);
        
        //Color.Lerp()

        yield return new WaitForSeconds(duration);
        lr.enabled = false;
    }

    public void DoRenderer(float radius)
    {
        lr.enabled = true;
        lr.positionCount = numSegments + 1;
        lr.useWorldSpace = false;

        float deltaTheta = (float)(2.0 * Mathf.PI) / numSegments;
        float theta = 0f;

        for (int i = 0; i < numSegments + 1; i++)
        {
            float x = radius * Mathf.Cos(theta);
            float z = radius * Mathf.Sin(theta);
            Vector3 pos = new Vector3(x, z, 0);
            lr.SetPosition(i, pos);
            theta += deltaTheta;
        }
        lr.enabled = false;
    }
}