using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopEffect : Effect
{
    public override void giveEffect(IEffectable effectable)
    {
        effectable.Stop();
    }
    
}
