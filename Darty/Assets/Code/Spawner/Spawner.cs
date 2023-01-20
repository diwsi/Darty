using Assets.Code.Level;
using Assets.Code.Spawner;
using Assets.Code.Target;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public GameObject[] SpawnPoints;
    public GameObject[] SpawnObjects;
    public UnityEvent SpawnedDestroyed;

    System.Random random;
    
        
    void Start()
    {
        random = new System.Random();
     
    }
  
    public void SetSpawns(Level level)
    {
        foreach (var item in level.Spawns)
        {
            StartCoroutine(Spawn(item));
        }
    }

    IEnumerator Spawn(SpawnSet set)
    {

        yield return new WaitForSeconds(set.SpawnTime);
        var spawnPointInd = random.Next(0, SpawnPoints.Length);
        var obj = Instantiate(SpawnObjects[set.SpawnType], SpawnPoints[spawnPointInd].transform.position, Quaternion.identity);
        obj.GetComponent<ITarget>().TargetDestroyedInternal.AddListener(TargetDestroyed);

    }
   
    public void TargetDestroyed()
    {
        SpawnedDestroyed.Invoke();
    }

}
