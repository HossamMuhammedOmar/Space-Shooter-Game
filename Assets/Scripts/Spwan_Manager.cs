using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwan_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy_prefab;
    [SerializeField]
    private GameObject _enemy_container;
    private bool _stopSpwaning = false;
    [SerializeField]
    private GameObject[] powerups;

    void Start()
    {
        StartCoroutine(SpwanEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    IEnumerator SpwanEnemyRoutine()
    {
        while(!_stopSpwaning)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-9f, 9f), 7f, 0);
            GameObject newEnemy = Instantiate(_enemy_prefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemy_container.transform;
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator SpawnPowerupRoutine()
    {
        while(!_stopSpwaning)
        {
            yield return new WaitForSeconds(7f);
            float randomX = Random.Range(9.15f, -9.15f);
            Vector3 posToSpawn = new Vector3(randomX, 7.76f, 0);
            Instantiate(powerups[Random.Range(0, powerups.Length)], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(7, 15));
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpwaning = true;
    }
}
