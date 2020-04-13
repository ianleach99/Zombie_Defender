using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int score;                        //Score of the game
    public static int lives;                        //Player health
    public float speed = 7;                         //Speed of player
    public float fireDelay = 0.0f;                  //Delay time before player can fire weapon again
    public GameObject projectile;                   //Bullet or projectile player shoots
    public GameObject HUDMenu;
    public GameObject GameOverMenu;

    private Vector2 velocity = new Vector2();       //Speed and direction of player
    private Rigidbody2D myRigidbody2D;              //Rigidbody of player
    private Animator anim;                          //For player animations
    private bool hasFired;
    private bool hasStartedEnemySpawner;
    private bool hasPlayedLaughterSound1;

    // Start is called before the first frame update
    void Start()
    {
        hasPlayedLaughterSound1 = false;
        hasStartedEnemySpawner = false;
        transform.position = new Vector3(0, -4, 0); //Start position
        hasFired = false;
        score = 0;
        lives = 5;
        myRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetMotionInput();
    }

    private void Update()
    {
        GetFireInput();

        if(!hasStartedEnemySpawner)
        {
            if (score > 1000)
            {
                if (!hasPlayedLaughterSound1)
                {
                    Audio.PlaySound("evilLaughterSound");
                    hasPlayedLaughterSound1 = true;
                }
                Debug.Log("Strong enemies have entered");
                hasStartedEnemySpawner = true;
                GameObject.FindGameObjectWithTag("Spawner").GetComponent<StrongEnemySpawner>().StartStrongEnemySpawner();
            }
        }
    }

    private void UpdateHighScore()
    {
        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            Debug.Log("New high score of " + PlayerPrefs.GetInt("HighScore", 0).ToString());
        }
    }

    //When the player dies
    public void OnPlayerDeath()
    {
        GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<AudioSource>().Stop();
        FinalScore.finalScore = score;
        UpdateHighScore();
        Audio.PlaySound("gameOver");
        Spawner.stop = true;
        StrongEnemySpawner.stop = true;
        PowerUpSpawner.stop = true;
        HUDMenu.SetActive(false);
        GameOverMenu.SetActive(true);
        Debug.Log("You are dead!");
        Destroy(gameObject);
    }

    //Get player input for movement
    private void GetMotionInput()
    {
        velocity.y = 0;
        velocity.x = Input.GetAxisRaw("Horizontal");
        myRigidbody2D.MovePosition(myRigidbody2D.position + velocity * speed * Time.fixedDeltaTime);    
    }

    //Get player inputfor firing a weapon
    private void GetFireInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(!hasFired)
            {
                StartCoroutine(playerFire()); //Fire weapon when fire button is pressed
            }           
        }
    }

    //Do this when the player fires weapon
    private IEnumerator playerFire()
    {
        int offSetY = 1;
        GameObject instanceProjectile = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + offSetY, transform.position.z), Quaternion.identity);
        Audio.PlaySound("playerFire");
        hasFired = true;
        yield return new WaitForSeconds(fireDelay);
        hasFired = false;
    }

}
