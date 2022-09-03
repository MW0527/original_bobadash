using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsBase : MonoBehaviour
{
    //Parent class to lemonpoints, strawberrypoints, and mangopoints

    protected int total_score; //stores the total score
    [SerializeField]
    protected int value;
    
    public virtual void AddToScore(PlayerController player)
    {
        total_score += 1;
    }
}
