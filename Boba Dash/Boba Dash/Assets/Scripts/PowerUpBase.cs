using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpBase : MonoBehaviour
{
    //Parent class to Giantpowerup, HighJumppowerup, Invinciblepowerup
    [SerializeField]
    protected float duration; //how long the powerup lasts
    [SerializeField]
    public string powerup_name; //the name of the powerup //is public becauses it is used in the PlayerController script


}
