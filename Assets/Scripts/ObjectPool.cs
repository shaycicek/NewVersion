using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public bool willGrow;
    public Queue<GameObject> pooledObjects;
    [SerializeField] private GameObject objectPrefab;
    public int poolsize;

    public static ObjectPool Instance;

    private void Awake()
    {
        Instance = this;
        pooledObjects = new Queue<GameObject>();
        for (int i = 0; i < poolsize; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.transform.parent = gameObject.transform;
            obj.SetActive(false);
            pooledObjects.Enqueue(obj);
        }
    }


    public GameObject GetPooledObject()
    {
        if (pooledObjects.Count > 0)
        {
            //Debug.Log("ObjectPool Count = " + pooledObjects.Count);
            return pooledObjects.Dequeue();
        }
        else
        {
            //Debug.Log("Objectpool Empty");
            GameObject objec = Instantiate(objectPrefab);
            objec.transform.parent = gameObject.transform;
            return objec;
        }
    }


    public void EnqueueMe(GameObject gobject)
    {
        SpawnManager.instance.totalNumberEnemiesInScene--;
        if (pooledObjects.Count > poolsize)
        {
            Destroy(gobject);
        }
        else
        {
            gobject.SetActive(false);
            pooledObjects.Enqueue(gobject);
        }
    }


}
