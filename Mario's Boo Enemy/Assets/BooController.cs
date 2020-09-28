using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooController : MonoBehaviour
{
    bool isMoving = false;

    float speed = 2; //Boo Speed

    [SerializeField] GameObject playerObjects;

    void Update()
    {
        //Check which sprite should we activate based on the isMoving variable
        ChangeSprite(isMoving);


        //Activate either to fit your player movement

        //FlipUpdate();
        RotateUpdate();
    }

    //The Basic Movement function
    void Move(Vector2 target)
    {
        //Move toward the player
        this.transform.position = Vector2.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
    }

    //No need to have any colliders because Boo is just a Ghost and have to pass through everything
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //KillPlayer
        }
    }

    #region SpriteChanging
    [SerializeField] Sprite BooMoving;
    [SerializeField] Sprite BooStuck;
    SpriteRenderer spriteRenderer;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    //This function is to switch the sprite depending on the condition Moving or Hiding
    void ChangeSprite(bool isMoving)
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        if (isMoving)
        {
            spriteRenderer.sprite = BooMoving;
            spriteRenderer.color = Color.white;
        }
        else
        {
            spriteRenderer.sprite = BooStuck;
            Color c = spriteRenderer.color;
            c.a = 0.75f;
            spriteRenderer.color = c;
        }
    }
    #endregion

    #region SpriteRendererFlip Movement

    //Here is the section to move if the player is just Flipping the sprite

    //The function that'll be called from the Main Update
    void FlipUpdate()
    {
        //Check if the player sprite is fliped toward the player
        SpriteFlipping();

        //check if we have to move of stay hidden
        CheckToMoveSpriteFliping();

        //Move if is allowed by the previews function
        if (isMoving)
            Move(playerObjects.transform.position);
    }

    //Check if the player sprite flip in the same way of the Boo then move or not
    //Just a notice here this may change depend on the sprites in your assets but it's just a small change from == to !=
    void CheckToMoveSpriteFliping()
    {
        if (playerObjects.GetComponent<SpriteRenderer>().flipX == spriteRenderer.flipX)
            isMoving = false;
        else
            isMoving = true;
    }

    //Just Flip Sprite to always face the player and this depend on the X axis
    //Just a notice here this may change depend on the sprites in your assets but it's just a small change from > to <

    void SpriteFlipping()
    {
        if (this.transform.position.x > playerObjects.transform.position.x)
            spriteRenderer.flipX = false;
        else
            spriteRenderer.flipX = true;
    }
    #endregion

    #region Rotate Movement

    //Here is the section to move if the player is rotating on the y axis

    //The function that'll be called from the Main Update
    void RotateUpdate()
    {
        //Check if the Rotate is correct to face the player
        FlipRotating();

        //check if we have to move of stay hidden
        CheckToMoveRotating();

        if (isMoving)
            Move(playerObjects.transform.position);
    }

    //Check if the player Rotated in the same way of the Boo then move or not
    //Just a notice here this may change depend on the gameobjects setup but it's just a small change from == to !=
    void CheckToMoveRotating()
    {
        if (this.transform.rotation.y != playerObjects.transform.rotation.y)
            isMoving = false;
        else
            isMoving = true;
    }

    //Just Rotate to always face the player and this depend on the X axis
    //Just a notice here this may change depend on the gameobjects setup but it's just a small change from > to <
    void FlipRotating()
    {
        if (this.transform.position.x > playerObjects.transform.position.x)
            Turn(-1);
        else
            Turn(1);
    }

    //Rotate depending on the direction
    void Turn(float inputDirection)
    {
        if (inputDirection < 0)
            this.transform.localEulerAngles = new Vector3(0, 180, 0);
        else
            if (inputDirection > 0)
            this.transform.localEulerAngles = new Vector3(0, 0, 0);
        else
            return;
    }
    #endregion
}
