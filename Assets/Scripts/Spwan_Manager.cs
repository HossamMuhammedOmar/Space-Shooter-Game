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

    void Start()
    {
        StartCoroutine(SpwanRoutine());
    }

    void Update()
    {

    }

    IEnumerator SpwanRoutine()
    {
        while(!_stopSpwaning)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-9f, 9f), 7f, 0);
            GameObject newEnemy = Instantiate(_enemy_prefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemy_container.transform;
            yield return new WaitForSeconds(2f);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpwaning = true;
    }

}
