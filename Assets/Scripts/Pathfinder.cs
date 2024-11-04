using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FollowPath();
        //Debug.Log(waypointIndex);


    }

    void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            //Debug.Log(waypointIndex);
            //Debug.Log(waypoints.Count);
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        
        }
        else
            {
                Destroy(gameObject);
                //Debug.Log(waypointIndex);

            }
    }
}
