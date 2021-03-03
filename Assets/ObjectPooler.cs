using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class GalaxyPool
    {
        public string name;
        public GameObject obj;
        public int size;
    }
    
    public Dictionary<string, Queue<GameObject>> galaxyPool;
    public List<GalaxyPool> galaxyPools;

    public static ObjectPooler instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        galaxyPool = new Dictionary<string, Queue<GameObject>>();

        foreach(GalaxyPool pool in galaxyPools)
        {
            Queue<GameObject> pooledobjs = new Queue<GameObject>();
            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.obj);
                obj.SetActive(false);
                pooledobjs.Enqueue(obj);
            }
            galaxyPool.Add(pool.name, pooledobjs);
        }
    }
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!galaxyPool.ContainsKey(tag))
        {
            Debug.LogError("Pool tag Not Found");
            return null;
        }
        GameObject objToSpawn = galaxyPool[tag].Dequeue();
        objToSpawn.SetActive(true);
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;
        galaxyPool[tag].Enqueue(objToSpawn);
        return objToSpawn;
    }
}


