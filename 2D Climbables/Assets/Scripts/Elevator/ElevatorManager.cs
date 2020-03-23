using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour
{
    //Add here all the Elevator stops in the incpecter 
    [SerializeField] List<Vector2> ElevatorPositions;
    int CurrentLevel = 1; //Eelevator current Level put to 1 because in our scene it's on the second floor
    int numberOfFloors;

    bool startMoving = false;
    float time = 0;

    PlayerMovement playerMovement;

    void Awake()
    {
        numberOfFloors = ElevatorPositions.Count - 1; // -1 because we start the count from 0
    }

    void Update()
    {
        if (startMoving)
        {
            GetToPoint();
        }
    }

    //Give the Elevator the Order to move to the new Level
    void GetToPoint()
    {
        if (Vector2.Distance(this.gameObject.transform.position, ElevatorPositions[CurrentLevel]) > 0.01f)
        {
            //Move the Elevator to the Goal Point
            time += Time.deltaTime * 0.5f;
            this.gameObject.transform.position = Vector2.Lerp(this.gameObject.transform.position, ElevatorPositions[CurrentLevel], time);
        }
        else
        {
            time = 0;
            playerMovement.ElevatorOff();
            startMoving = false;
        }
    }

    //Activate the Elevator and it's called by the Player
    public void ActivateElevator(int direction)
    {
        if (direction > 0)//Up
        {
            //check if there is another level
            if (CurrentLevel + 1 <= numberOfFloors)
            {
                CurrentLevel++;
                startMoving = true;
                playerMovement.ElevatorOn();
            }
        }
        else//Down
        {
            //check if there is another level
            if (CurrentLevel - 1 >= 0)
            {
                CurrentLevel--;
                startMoving = true;
                playerMovement.ElevatorOn();
            }
        }
    }
    public void ActivateElevatorByNumber(int floorNum)
    {
        if (floorNum >= 0 && floorNum <= numberOfFloors)
        {
            CurrentLevel = floorNum;
            startMoving = true;
            playerMovement.ElevatorOn();
        }
    }

    #region Triggers
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerMovement = other.GetComponent<PlayerMovement>();
            playerMovement.SetElevator(true, this);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerMovement = other.GetComponent<PlayerMovement>();
            playerMovement.SetElevator(false, this);
        }
    }
    #endregion

}
