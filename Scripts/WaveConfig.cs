using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] GameObject PathPrefab;
    [SerializeField] float timebetweenspawns = 0.5f;
    [SerializeField] float spawnrandomfactor = 0.3f;
    [SerializeField] int numberofenemies = 5;
    [SerializeField] float movespeed = 2f;

    public GameObject GetEnemyPrefab() { return EnemyPrefab;}
    public List<Transform> GetWaypoints() 
    {
        var WaveWaypoints = new List<Transform>();
        foreach (Transform Child in PathPrefab.transform)
        {
            WaveWaypoints.Add(Child);
        } 
        return WaveWaypoints;
    }
    public float GetTimebetweenspawn() { return timebetweenspawns;}
    public float GetSpawnRandomFactor() { return spawnrandomfactor;}
    public float GetMoveSpeed() { return movespeed;}
    public int GetNumberOfEnemies() { return numberofenemies;}
}
