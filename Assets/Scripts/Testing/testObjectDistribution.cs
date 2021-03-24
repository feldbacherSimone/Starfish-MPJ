﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testObjectDistribution: MonoBehaviour
{

    public float radius = 1;
    public Vector3 regionSize = Vector3.zero;
    public int rejectionSamples = 30;
    public float displayRadius = 0.5f;

    List<Vector3> points;

    void OnValidate()
    {
        points = PoissonDiscSampling.GeneratePoints(radius, regionSize, rejectionSamples);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(regionSize / 2, regionSize);
        if (points != null)
        {
            foreach (Vector2 point in points)
            {
                Gizmos.DrawSphere(point, displayRadius);
            }
        }
    }
}

