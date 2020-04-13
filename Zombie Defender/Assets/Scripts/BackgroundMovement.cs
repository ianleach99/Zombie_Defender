using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public bool isMainMenu;
    float speed = 2.0f;
    Vector3 velocity = new Vector3();

    // Use this for initialization
    void Start()
    {
        velocity.x = -1;
    }

    public void MoveSkullLeftAndRight()
    {
        if (transform.position.x > 4)
        {
            velocity.x = -1;
        }
        if (transform.position.x < -4)
        {
            velocity.x = 1;
        }
        transform.Translate(velocity * speed * Time.deltaTime);
    }

    private void Update()
    {
        if(isMainMenu)
        {
            MoveSkullLeftAndRight();
        }

        if(Player.score > 1000)
        {
            MoveSkullLeftAndRight();
        }
    }

}
