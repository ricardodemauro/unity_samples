using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed = 10f;

    private Transform target;

    private int wavePointIndex = 0;

    private const int FIRST_POINT_INDEX = 0;

    // Use this for initialization
    public void Start()
    {
        wavePointIndex = FIRST_POINT_INDEX;
        target = WayPointsController.Points[wavePointIndex];
    }

    // Update is called once per frame
    public void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNexWaypoint();
        }
    }

    private void GetNexWaypoint()
    {
        if (wavePointIndex >= WayPointsController.Points.Count - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavePointIndex++;
        target = WayPointsController.Points[wavePointIndex];
    }
}
