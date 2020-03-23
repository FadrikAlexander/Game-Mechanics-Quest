using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Classes
    PlayerSpriteManager playerSpriteManager;

    void Awake()
    {
        //Get All Classes
        if (playerSpriteManager == null)
            playerSpriteManager = GetComponent<PlayerSpriteManager>();
    }

    void FixedUpdate()
    {
        if (isOnElevator) //Check if the Player is on an Elevator
            ActivateElevator();

        if (onClimbable || isClimbing) //Check if the Player is on a Climbable or Climbing one
            UseClimbable();

        if (canMove) //Move if the player is able of that
            Move();
        else
            playerSpriteManager.SetBusy();
    }

    #region Movement
    [SerializeField] float Speed = 5f; //Player Base Speed
    float BlockedInput = 0; //a way to know when the Player Hit a wall
    bool canMove = true;
    float inputHor;
    void Move()
    {
        inputHor = Input.GetAxisRaw("Horizontal"); //Get Input

        //Sprite Stuff
        playerSpriteManager.FlipSprite(inputHor);

        //if the Player hit a wall in the same direction of movement don't allow any other movement
        if (BlockedInput != inputHor)
        {
            //Player is away from the wall
            BlockedInput = 0;
            transform.Translate(Vector3.right * inputHor * Speed * Time.deltaTime);

            playerSpriteManager.SetMoving();
        }
        else
            playerSpriteManager.SetIdle();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
            BlockedInput = inputHor;
    }
    #endregion

    #region Elevator
    bool isOnElevator = false;
    ElevatorManager elevatorManager;
    void ActivateElevator() //Order the Elevator to Move
    {
        float inputVer = Input.GetAxisRaw("Vertical");

        if (inputVer != 0)
            elevatorManager.ActivateElevator((int)inputVer); //The inputVer to dectate the Direction of the Elevator
    }
    public void ElevatorOn() //Called when The Elevator is Moving
    {
        canMove = false;
        isOnElevator = false;

        //We need the Player to stick with the elevator when it's moving so we don't have to move the player indevedually
        transform.parent = elevatorManager.gameObject.transform;
    }
    public void ElevatorOff() //Called when The Elevator has reached its distenation
    {
        canMove = true;
        isOnElevator = true;

        //Release the Player from the Elevator
        transform.parent = null;
    }
    public void SetElevator(bool isOnElevator, ElevatorManager elevatorManager) //Called to set the Elevator Data
    {
        this.isOnElevator = isOnElevator;
        this.elevatorManager = elevatorManager;
    }
    #endregion

    #region Climbable

    bool onClimbable = false;
    bool isClimbing = false;
    float climbPercentage;
    float ClimbingSpeed = 0.5f;
    Vector2 vectorStart, vectorEnd; //Starting and Ending Point of the Climbable

    void UseClimbable()
    {
        float inputVer = Input.GetAxisRaw("Vertical");

        if (inputVer != 0)
        {
            //Climb base on the percentage so we could back and forward based on the inputVer
            climbPercentage += Time.deltaTime * ClimbingSpeed * inputVer;
            this.gameObject.transform.position = Vector2.Lerp(vectorStart, vectorEnd, climbPercentage);
        }

        climbPercentage = Mathf.Clamp01(climbPercentage);

        //if the Player reaches any end he can move again
        if (climbPercentage == 0 || climbPercentage == 1)
        {
            isClimbing = false;
            canMove = true;
        }
        else
        {
            isClimbing = true;
            canMove = false;
        }
    }

    //Called to set the Climbable Data
    public void SetClimbableData(bool onClimbable, Vector2 StartY, Vector2 EndY, bool isDown, float ClimbingSpeed)
    {
        this.onClimbable = onClimbable;

        this.vectorStart = StartY;
        this.vectorEnd = EndY;

        //to Check at what end the Player is
        if (isDown)
            climbPercentage = 0;
        else
            climbPercentage = 1;

        this.ClimbingSpeed = ClimbingSpeed;
    }
    public void OffClimbable()
    {
        onClimbable = false;
    }
    #endregion

}
