using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawberryPoint : PointsBase
{

    public override void AddToScore(PlayerController player)
    {
        player.addPoints(value);
    }
}
