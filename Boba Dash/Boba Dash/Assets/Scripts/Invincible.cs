using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincible : PowerUpBase
{
    //Invincible powerup
    //Player does not die when colliding with an obstacle
    [SerializeField]
    private int move_speed;
    [SerializeField]
    private AudioClip collect;
    private void Update()
    {
        transform.position += new Vector3(-move_speed * Time.deltaTime, 0f, 0f);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.PlaySFX(collect);
            StartCoroutine(Pickup(collision));
        }
        else if (collision.gameObject.CompareTag("Despawn")) //if objects enter despawner
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Pickup(Collider2D player)
    {
        PlayerController p = player.GetComponent<PlayerController>();
        
        p.isInvincible = true;
        
        GetComponent<SpriteRenderer>().enabled = false; //makes the component disappear (but doesn't destroy the object)
        GetComponent<CircleCollider2D>().enabled = false;
        
        yield return new WaitForSeconds(duration);

        p.isInvincible = false;
        p.active_powerup_display.text = "None";
        
        Destroy(gameObject);
    }

}
