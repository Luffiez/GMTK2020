using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detractor : Distraction
{
    void FixedUpdate()
    {
        TriggerDistraction(goose.position, transform.position);
    }
}
