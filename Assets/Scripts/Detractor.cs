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
        TriggerDistraction(goose.position, transform.position);
    }
}
