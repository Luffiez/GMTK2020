using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : Distraction
{
    void FixedUpdate()
    {
        if (!gm.IsActiveScene)
            return;
        audioTimer -= Time.fixedDeltaTime;
        if(TriggerDistraction(transform.position, goose.position))
        {
            if (!lineCircle.isActive)
            {
                lineCircle.StartCoroutine(lineCircle.DisplayCircle(0.5f));
            }
        }
    }
}
