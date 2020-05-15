using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Class Contain the Map Boundries at the up most  right point and the lowest left point
public class MapBounderies : MonoBehaviour
{
    public Vector2 MapMaxBounderies;
    public Vector2 MapMinBounderies;

    public Vector2 GetXVector()
    {
        return new Vector2(MapMaxBounderies.x, MapMinBounderies.x);
    }
    public Vector2 GetYVector()
    {
        return new Vector2(MapMaxBounderies.y, MapMinBounderies.y);
    }
}
