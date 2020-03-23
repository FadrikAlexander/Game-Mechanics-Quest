using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    LineRenderer lineRenderer;
    [SerializeField] Transform elevatorTopPoint;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lineRenderer.SetPosition(1, elevatorTopPoint.position);
    }
}
