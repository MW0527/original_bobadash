using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    public float upForce; //is declared public as it is used in HighJump class
    
    [SerializeField]
    private Text scoreDisplay;
    [SerializeField]
    private Text coinDisplay;
    private int score;
    private int coins = 0;
    [SerializeField]
    private Text highscoreDisplay;

    private float jumpTimeCounter;
    [SerializeField]
    private float jumpTime;
    private bool isJumping;
    private bool m_ground;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    public Text active_powerup_display; //is declared public as it is used in powerups child classes

    [SerializeField]
    private AudioClip jump_sound;

    public bool isInvincible = false;
    public bool isBig = false;
    void Start()
    {
        coinDisplay.text = "0";
        highscoreDisplay.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Jumping", false);
        if (m_ground && Input.GetKeyDown(KeyCode.Space)) //player must be on the ground to be able to jump
        {
            SoundManager.PlaySFX(jump_sound);
            isJumping = true;
            animator.SetBool("Jumping", true);
            jumpTimeCounter = jumpTime;
            rb.velocity = transform.up * upForce;
        }
        if (isJumping && Input.GetKey(KeyCode.Space)) //if the player is already in the air from jumping and space is still held down
        {
            if (jumpTimeCounter > 0) //continue rising up until jumpTimeCounter expires
            {
                rb.velocity = transform.up * upForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else //when jumpTimeCounter reaches 0, even if spacebar is still held down, player can not jump any higher
            {
                isJumping = false;
                animator.SetBool("Jumping", false);
            }
        }
        if (Input.GetKeyUp(KeyCode.Space)) //once spacebar is released, player can not jump in the middle of falling down
        {
            isJumping = false;
            animator.SetBool("Jumping", false);
        }
    }
    public void addPoints(int value)
    {
        score += value;
        scoreDisplay.text = score.ToString();
        if (score > PlayerPrefs.GetInt("HighScore",0)) //if the score becomes greater than the highscore, replace the highscore
        {
            PlayerPrefs.SetInt("HighScore", score);
            highscoreDisplay.text = score.ToString();
        }
    }

    public void resetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        highscoreDisplay.text = score.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            m_ground = true;
        }
        if (collision.gameObject.CompareTag("Platform") && isBig == true)
        {
            Destroy(collision.gameObject); //destroys the platform if the player that has the Giant powerup active comes into contact
        }
        if (collision.gameObject.CompareTag("Obstacle") && isInvincible == false)
        {
           GameStateManager.GameOver();
        }
        else if (collision.gameObject.CompareTag("Obstacle") && isInvincible || collision.gameObject.CompareTag("Platform") && isInvincible) 
        //does not make the player lose the game if the Invincibility powerup is active and they collide with an obstacle
        //for some reasons, the player would not be able to jump after colliding with an obstacle head on without this code
        {
            m_ground = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        m_ground = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Points"))
        {
            PointsBase x = collision.gameObject.GetComponent<PointsBase>();
            x.AddToScore(this);
            
        }
        else if (collision.gameObject.CompareTag("PowerUp"))
        {
            PowerUpBase y = collision.gameObject.GetComponent<PowerUpBase>();
            string name = y.powerup_name; //gets the collected powerup's name
            active_powerup_display.text = name;
        }
        else if (collision.gameObject.CompareTag("Coin"))
        {
            coins += 1;
            coinDisplay.text = coins.ToString();
        }
        else if (collision.gameObject.CompareTag("Despawn"))
        {
            Destroy(gameObject);
        }

    }
}
