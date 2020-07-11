using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScaler : MonoBehaviour
{
    RectTransform rectTransform;
    Vector2 originalScale;
    [SerializeField]
    float maxScale;
    [SerializeField]
    float ScaleTime;
    [SerializeField]
    Vector2 ScaleOffset;
    
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float scaleX = originalScale.x + maxScale * Mathf.Sin(Time.time * ScaleTime + ScaleOffset.x);
        float scaleY = originalScale.y + maxScale * Mathf.Sin(Time.time * ScaleTime + ScaleOffset.y);
        rectTransform.localScale = new Vector3(scaleX, scaleY, rectTransform.localScale.z);
    }
}
