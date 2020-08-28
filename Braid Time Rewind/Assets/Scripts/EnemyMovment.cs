using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    //To check out which direction we're walking
    bool movingDirection = false;
    bool isMoving = true;

    Animator animator;
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite fallingSprite;

    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        falling();
    }

    //Enemy Speed
    [SerializeField] float speed = 5;
    void Update()
    {
        if (isMoving)
            transform.Translate(((movingDirection ? -1 : 1) * Vector3.left * Time.deltaTime * speed));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Edge" || other.gameObject.tag == "Enemy")
        {
            //Reverse Direction and sprite
            movingDirection = !movingDirection;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        if (other.gameObject.tag == "Ground")
            Moving();

    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
            falling();
    }

    #region Animation 

    void falling()
    {
        animator.enabled = false;
        spriteRenderer.sprite = fallingSprite;
    }
    void Moving()
    {
        animator.enabled = true;
    }
    #endregion

    #region MoveControllingFunction
    public void Move()
    {
        isMoving = true;
    }
    public void StopMoving()
    {
        isMoving = false;
    }
    #endregion
}
