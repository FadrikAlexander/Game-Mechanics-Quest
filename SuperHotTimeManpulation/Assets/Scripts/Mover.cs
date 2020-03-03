using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform Point1;
    [SerializeField] Transform Point2;

    [SerializeField] float movementTime = 1f;

    void Awake()
    {
        //StartMoving
        StartCoroutine(MoveFromTo(Point1.position, Point2.position, movementTime));
    }

    void FlipPoints()
    {
        Transform Point = Point1;
        Point1 = Point2;
        Point2 = Point;
    }

    IEnumerator MoveFromTo(Vector2 a, Vector2 b, float speed)
    {
        float step;
        float t = 0;
        transform.position = a;
        while (t <= 1.0f)
        {
            step = (speed / (a - b).magnitude) * Time.fixedDeltaTime;
            t += step; // Goes from 0 to 1, incrementing by step each time
            transform.position = Vector3.Lerp(a, b, t); // Move objectToMove closer to b
            yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
        }
        transform.position = b;

        FlipPoints();
        StartCoroutine(MoveFromTo(Point1.position, Point2.position, movementTime));
    }
}
