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
        TriggerDistraction(transform.position, goose.position);
    }
}
