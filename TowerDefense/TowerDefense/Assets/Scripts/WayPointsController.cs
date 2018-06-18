using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsController : MonoBehaviour
{
    public static readonly List<Transform> Points = new List<Transform>();

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Points.Add(transform.GetChild(i));
        }
    }
}
