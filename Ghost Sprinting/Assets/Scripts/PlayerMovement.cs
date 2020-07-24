using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;

    GhostSpriteSpawner ghostSpriteSpawner;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ghostSpriteSpawner = GetComponent<GhostSpriteSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    #region Movement
    [SerializeField] float Speed = 5f; //Player Base Speed
    float currentSpeed = 0;
    float currentDirection = 0;

    bool CanMove = true;

    void Move()
    {
        float inputHor = Input.GetAxisRaw("Horizontal"); //Get Input

        //Sprite Stuff
        FlipSprite(inputHor);
        ChangeSpeed(inputHor);

        //To save the movement Direction after removing our Axis input
        if (inputHor != 0)
            currentDirection = inputHor;

        if (CanMove)
        {
            transform.Translate(Vector3.right * currentDirection * currentSpeed * Time.deltaTime);

            //Start Spawning Ghosts
            ghostSpriteSpawner.StartSpawningGhost();

            animator.SetBool("Run", true);
        }
        else
            animator.SetBool("Run", false);
    }
    #endregion

    //Flip the Player Sprite depend on the player direction
    void FlipSprite(float inputDirection)
    {
        if (inputDirection > 0)
            spriteRenderer.flipX = false;
        else if (inputDirection < 0)
            spriteRenderer.flipX = true;
    }

    //Ramp Speed
    void ChangeSpeed(float inputDirection)
    {
        //if the movemont started
        if (inputDirection != 0)
        {
            CanMove = true;

            //Start Ramping Speed until reach the limit
            currentSpeed += 0.75f;
            if (currentSpeed >= Speed)
                currentSpeed = Speed;
        }
        else
        {
            currentSpeed -= 0.5f;

            //Stop moving when the speed go to 0
            if (currentSpeed <= 0)
            {
                currentSpeed = 0;
                CanMove = false;
            }
        }
    }
}
