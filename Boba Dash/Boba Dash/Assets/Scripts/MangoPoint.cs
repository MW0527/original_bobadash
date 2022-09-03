using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangoPoint : PointsBase
{

    public override void AddToScore(PlayerController player)
    {
        player.addPoints(value);
    }
}
