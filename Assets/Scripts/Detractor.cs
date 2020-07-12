using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detractor : Distraction
{
    void FixedUpdate()
    {
        if (!gm.IsActiveScene)
            return;
        audioTimer -= Time.fixedDeltaTime;
        if(TriggerDistraction(goose.position, transform.position))
        {
            if (!lineCircle.isActive)
            {
                lineCircle.StartCoroutine(lineCircle.DisplayCircle(0.5f));
            }
        }
    }
}
