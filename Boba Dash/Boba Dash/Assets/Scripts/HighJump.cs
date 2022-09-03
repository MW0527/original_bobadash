using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJump : PowerUpBase
{
    //High Jump powerup
    //Allows player to jump higher
    [SerializeField]
    private int move_speed;
    [SerializeField]
    private float force;
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
            StartCoroutine( Pickup(collision) );
        }
        else if (collision.gameObject.CompareTag("Despawn")) //if objects enter despawner
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        PlayerController p = player.GetComponent<PlayerController>();
        
        p.upForce += force;
        
        GetComponent<SpriteRenderer>().enabled = false; //makes the component disappear (but doesn't destroy the object)
        GetComponent<CircleCollider2D>().enabled = false;
        
        yield return new WaitForSeconds(duration);

        p.upForce -= force;
        p.active_powerup_display.text = "None";
        
        Destroy(gameObject);
    }

    /*[SerializeField]
    private float time;

    private float start_time;
    private PlayerController p;
    public override void Apply(PlayerController player)
    {
        start_time = Time.time;
        p = player;
        p.AddJumpHeight(force);

    }

    private void Update()
    {
        if (Time.time - start_time > time)
        {
            p.AddJumpHeight(-force);
            Destroy(gameObject);
        }
    }*/
}
