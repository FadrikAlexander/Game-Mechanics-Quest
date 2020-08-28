using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Class is for recording the points in Time
public class TimePoint : MonoBehaviour
{
    //You can add here all the variables that needed to be recorded.
    public Vector3 Position; //Game Object 3D Position
    public Vector3 Velocity; //Game Object RigidBody Velocity

    //The Time Point Constructer
    //you can add multiple Constructers to mimic more objects
    public TimePoint(Vector3 Position, Vector3 Velocity)
    {
        this.Position = Position;
        this.Velocity = Velocity;
    }
}
