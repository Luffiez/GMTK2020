using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class LineCircle : MonoBehaviour
{
    [Range(3, 256)]
    public int numSegments = 64;
    public Color startColor, endColor;
    public AnimationCurve widthCurve;
    LineRenderer lr;
    float radius;
    public float startWidth, endWidth;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.endColor = startColor;
        lr.startColor = startColor;
    }

    public IEnumerator DisplayCircle(float duration)
    {
        float elapsedTime = 0;

        Color currentColor = startColor;
        float currentWidth = startWidth;
        float startRadius = radius * 0.8f;
        float endRadius = radius ;
        float curRadius = startRadius;
        lr.enabled = true;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            currentColor = Color.Lerp(startColor, endColor, elapsedTime / duration);
            currentWidth = widthCurve.Evaluate(elapsedTime / duration);
            curRadius = Mathf.Lerp(startRadius, endRadius, elapsedTime / duration);
            DoRenderer(curRadius);
            //lr.endWidth = currentWidth;
            //lr.startWidth = currentWidth;
            lr.startColor = currentColor;
            lr.endColor = currentColor;

            yield return null;
        }

        DoRenderer(endRadius);
        lr.enabled = false;
        yield return null;
    }

    public void DoRenderer(float newRadius)
    {
        radius = newRadius;
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
    }
}