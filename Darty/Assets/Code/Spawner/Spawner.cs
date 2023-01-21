using Assets.Code.Level;
using Assets.Code.Spawner;
using Assets.Code.Target;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public GameObject[] SpawnPoints;
    public GameObject[] SpawnObjects;
    public UnityEvent SpawnedDestroyed;
    public bool Locked;
    System.Random random;
    List<GameObject> spawnedTargets=new List<GameObject>();
        
    void Start()
    {
        random = new System.Random();     
    }
  
    public void SetSpawns(Level level)
    {
        Locked = false;
        spawnedTargets = new();
        foreach (var item in level.Spawns)
        {
            StartCoroutine(Spawn(item));
        }
    }

    IEnumerator Spawn(SpawnSet set)
    {

        yield return new WaitForSeconds(set.SpawnTime);
        if (!Locked)
        {
            var spawnPointInd = random.Next(0, SpawnPoints.Length);
            var obj = Instantiate(SpawnObjects[set.SpawnType], SpawnPoints[spawnPointInd].transform.position, Quaternion.identity);
            
            obj.GetComponentInChildren<ITarget>().TargetDestroyedInternal.AddListener(TargetDestroyed);
            spawnedTargets.Add(obj);
        }        
    }
   
    public void TargetDestroyed()
    {
        SpawnedDestroyed.Invoke();
    }

    public void LockSpawn()
    {
        Locked = true;
        foreach (var item in spawnedTargets)
        {
            if (!item.IsDestroyed())
            {
                Destroy(item);
            }
        }        
    }

}
