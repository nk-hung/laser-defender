using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  [SerializeField] List<WaveConfigSO> waveConfigs;
  [SerializeField] float timeBetweenWave = 0.2f;
  WaveConfigSO currentWave;
  // store our enemy list => so need get reference in WaveConfigSO
  [SerializeField] bool isLooping;

  public WaveConfigSO GetCurrentWave()
  {
    return currentWave;
  }
  void Start()
  {
    StartCoroutine(SpawnEnemyWave());
  }

  // look through all of the enemies => spawn them into world 
  IEnumerator SpawnEnemyWave()
  {
    do
    {
      foreach (WaveConfigSO wave in waveConfigs)
      {
        currentWave = wave;
        for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
          Instantiate(currentWave.GetEnemyPrefab(i),
                      currentWave.GetStartingWaypoint().position,
                      Quaternion.Euler(0, 0, 180),
                      transform);
          yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
        }
        yield return new WaitForSeconds(timeBetweenWave);
      }
    }
    while (isLooping);
  }

}
