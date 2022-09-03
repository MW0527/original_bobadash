using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bigger : PowerUpBase
{
    //Giant Powerup
    //Player grows in size and destroys everything it comes into contact with (has invincibility)
    [SerializeField]
    private int move_speed;
    [SerializeField]
    private float multiplier;
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
        p.isBig = true;

        GetComponent<SpriteRenderer>().enabled = false; //makes the component disappear (but doesn't destroy the object)
        GetComponent<CircleCollider2D>().enabled = false;

        p.transform.localScale *= multiplier;
        
        yield return new WaitForSeconds(duration);
        
        p.transform.localScale /= multiplier;

        p.isInvincible = false;
        p.isBig = false;
        p.active_powerup_display.text = "None";
        
        Destroy(gameObject);
    }
}
