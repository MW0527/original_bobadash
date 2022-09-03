using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    //This script is ALSO USED FOR COINS
    [SerializeField]
    private int move_speed;
    [SerializeField]
    private AudioClip collect;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-move_speed * Time.deltaTime, 0f, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.PlaySFX(collect); //Note: points do not have a sfx on them, but coins do
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Despawn")) //if objects enter despawner
        {
            Destroy(gameObject);
        }



    }
}