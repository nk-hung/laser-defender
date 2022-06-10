using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfigSO", menuName = "Create/New Wave Config SO")]
public class WaveConfigSO : ScriptableObject
{
  [SerializeField] List<GameObject> enemyPrefabs; // store all of the enemies => loop through all of enemies or instantiating each enemy
  [SerializeField] Transform pathPrefab; // Transform => ways to works with Gameobject's position, rotation, scale 
                                         // or hierarchical(thứ bậc) relationship to parent and children
                                         // contain all waypoint 
  [SerializeField] float moveSpeed = 5f;
  [SerializeField] float timeBetweenEnemySpawn = 1f;
  [SerializeField] float spawnTimeVariance = 0.2f;
  [SerializeField] float minimumSpawnTime = 0.3f;

  public Transform GetStartingWaypoint()
  {
    return pathPrefab.GetChild(0);
  }

  // need to public getters data of enemies to allow access the information we need in outside
  public int GetEnemyCount()
  {
    return enemyPrefabs.Count;
  }

  public GameObject GetEnemyPrefab(int index)
  {
    return enemyPrefabs[index];
  }
  // => need create script enemySpawner ?? why need ??

  // Why need GetWaypoints ?? => we need waypoints themselve, not container that those waypoints are in.
  public List<Transform> GetWaypoints()
  {
    List<Transform> wayPoints = new List<Transform>();
    foreach (Transform child in pathPrefab)
    {
      wayPoints.Add(child);
    }
    return wayPoints;

  }

  public float GetMoveSpeed()
  {
    return moveSpeed;
  }

  public float GetRandomSpawnTime()
  {
    float spawnTime = Random.Range(timeBetweenEnemySpawn - spawnTimeVariance,
                                  timeBetweenEnemySpawn + spawnTimeVariance);
    return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
  }

}
