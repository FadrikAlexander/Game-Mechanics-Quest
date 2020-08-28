using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Rewind Controller to be added to all objects that needed to be any GameObject that needed to be 
public class RewindController : MonoBehaviour
{
    bool isRewinding = false; //if the Rewinding started or not
    List<TimePoint> TimePoints = new List<TimePoint>(); //TimePoints List that will contain all saved points
    int TimePointsCount = 500; //Max number of frames to be saved


    Rigidbody2D rigidbody2D;
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Start Rewinding
            RewindTime();

        if (Input.GetKeyUp(KeyCode.Space)) //Stop Rewinding
            StopRewinding();
    }

    void FixedUpdate() //you need to record point as frames progress in FixedUpdate
    {
        if (isRewinding)
            RewindTimePoints();
        else
            RecordTimePoints();
    }

    //Start Recording Points
    void RecordTimePoints()
    {
        if (TimePoints.Count >= TimePointsCount) //if the points saved is bigger than the max TimePointsCount
            TimePoints.RemoveAt(0);

        TimePoint timePoint = new TimePoint(transform.position, rigidbody2D.velocity); //Create Point
        TimePoints.Add(timePoint); //Add it to he list
    }

    //Rewinding Time
    void RewindTimePoints()
    {
        if (TimePoints.Count > 0) //to make sure there are points left
        {
            SetTimePoint(TimePoints[TimePoints.Count - 1]); //set the point to the gameobject
            TimePoints.RemoveAt(TimePoints.Count - 1);
        }
        else
            StopRewinding(); //when TimePoints is empty stop Rewinding
    }

    //This function can be OverLoaded and have multiple use for more objects 
    void SetTimePoint(TimePoint timePoint)
    {
        this.transform.position = timePoint.Position;
        rigidbody2D.velocity = timePoint.Velocity;
    }

    #region StartandStopFunctions
    void RewindTime()
    {
        isRewinding = true;

        //This need to be changed to an event system so it can be more functional and work with many scripts
        //This is here just to simplfy this test
        GetComponent<EnemyMovment>().StopMoving();
    }

    void StopRewinding()
    {
        isRewinding = false;

        //This need to be changed to an event system so it can be more functional and work with many scripts
        //This is here just to simplfy this test
        GetComponent<EnemyMovment>().Move();
    }
    #endregion 
}
