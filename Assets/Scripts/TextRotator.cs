using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRotator : MonoBehaviour
{
    RectTransform rectTransform;
    float originalRotation;
    [SerializeField]
    float rotationTime;
    [SerializeField]
    float maxRotation;
    [SerializeField]
    float timeOffset;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalRotation = rectTransform.rotation.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        float rotationTemp = originalRotation + Mathf.Sin(Time.time * rotationTime + timeOffset) * maxRotation;
        rectTransform.eulerAngles = new Vector3(rectTransform.eulerAngles.x, rectTransform.eulerAngles.y, rotationTemp);
    }
}
