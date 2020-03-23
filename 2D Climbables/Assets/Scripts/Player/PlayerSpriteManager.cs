using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteManager : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite BusySprite, IdleSprite, MoveSprite;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //Flip the Player Sprite depend on the player direction
    public void FlipSprite(float inputDirection)
    {
        if (inputDirection > 0)
            spriteRenderer.flipX = false;
        else if (inputDirection < 0)
            spriteRenderer.flipX = true;
    }

    #region SpriteFunctions
    public void SetIdle()
    {
        if (spriteRenderer.sprite != IdleSprite)
            spriteRenderer.sprite = IdleSprite;
    }
    public void SetMoving()
    {
        if (spriteRenderer.sprite != MoveSprite)
            spriteRenderer.sprite = MoveSprite;
    }
    public void SetBusy()
    {
        if (spriteRenderer.sprite != BusySprite)
            spriteRenderer.sprite = BusySprite;
    }
    #endregion
}
