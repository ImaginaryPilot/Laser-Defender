using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    int startingwave;
    [SerializeField] bool looping = false;
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }
    
    private IEnumerator SpawnAllWaves()
    {
        for (int waveindex = startingwave; waveindex < waveConfigs.Count; waveindex++)
        {
            var currentwave = waveConfigs[waveindex];
            yield return StartCoroutine(SpawnAllEnemies(currentwave));
        }
    }

    private IEnumerator SpawnAllEnemies(WaveConfig waveConfig)
    {
        for (int enemycount = 0; enemycount < waveConfig.GetNumberOfEnemies(); enemycount++)
        {
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimebetweenspawn());
        }
    }

}
