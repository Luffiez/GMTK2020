using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : Distraction
{
    void FixedUpdate()
    {
        TriggerDistraction(transform.position, goose.position);
    }
}
