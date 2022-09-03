using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonPoint : PointsBase
{

    public override void AddToScore(PlayerController player)
    {
        player.addPoints(value);
    }
}
