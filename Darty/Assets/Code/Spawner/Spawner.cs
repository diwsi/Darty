using Assets.Code.Spawner;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] SpawnPoints;
    public GameObject[] SpawnObjects;
    public SpawnSet[] SpawnSet;
    System.Random random;
    void Start()
    {
        random = new System.Random();
        SetSpawns();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }

    public void SetSpawns()
    {
        foreach (var item in SpawnSet)
        {
            StartCoroutine(Spawn(item));
        }
    }

    IEnumerator Spawn(SpawnSet set)
    {

        yield return new WaitForSeconds(set.SpawnTime);
        var spawnPointInd = random.Next(0, SpawnPoints.Length );
        Instantiate(SpawnObjects[set.SpawnType], SpawnPoints[spawnPointInd].transform.position, Quaternion.identity);

    }



}
