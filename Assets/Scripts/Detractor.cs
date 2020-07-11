using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detractor : Distraction
{
    void FixedUpdate()
    {
        if (!gm.IsActiveScene)
            return;

        TriggerDistraction(goose.position, transform.position);
    }
}
