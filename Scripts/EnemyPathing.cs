using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    List<Transform> waypoints;
    int waypointindex;
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointindex].transform.position;
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    void Update()
    {
        if (waypointindex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointindex].transform.position;
            var movementframe = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementframe);
            if(transform.position == targetPosition)
            {
                waypointindex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
