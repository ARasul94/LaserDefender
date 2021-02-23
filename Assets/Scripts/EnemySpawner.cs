using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScriptableObjects;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfig> waveConfigs;

    private int _waveIndex = 0;
    private void Start()
    {
        if (waveConfigs == null || waveConfigs.Count == 0)
            return;

        StartCoroutine(SpawnAllWaves());
    }

    private IEnumerator SpawnAllWaves()
    {
        for (_waveIndex = 0; _waveIndex < waveConfigs.Count; _waveIndex++)
        {
            yield return StartCoroutine(SpawnAllEnemiesInWave(waveConfigs[_waveIndex]));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig wave)
    {
        var path = Instantiate(wave.PathPrefab);
        if (!path.IsEmpty())
        {
            for (int i = 0; i < wave.NumberOfEnemies; i++)
            {
                var enemy = Instantiate(
                    wave.EnemyPrefab,
                    path.Waypoints.First().transform.position,
                    Quaternion.identity).GetComponent<EnemyPathing>();

                enemy.SetupEnemyParameters(path, wave.MoveSpeed, i == wave.NumberOfEnemies - 1);

                yield return new WaitForSeconds(wave.TimeBetweenSpawns);
            }    
        }
        
    }
}
