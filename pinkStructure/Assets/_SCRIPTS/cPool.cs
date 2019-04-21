using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cPool : MonoBehaviour
{
    #region USING DICTIONARY OF POOLS

    Dictionary<int, Queue<GameObject>> _poolDictionary = new Dictionary<int, Queue<GameObject>>();

    // singleton pattern:

    public static cPool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    //public static cPool Instance
    //{
    //    get
    //    {
    //        return _instance;
    //    }
    //}


    /// <summary>
    /// Create a pool for our prefabs.
    /// </summary>
    /// <param name="prefab">
    /// The prefab that needs to be used and reused in our pool.
    /// </param>
    /// <param name="poolsize">
    /// The size of our initial pool.
    /// </param>
    public void AddToPool(GameObject prefab, int poolsize)
    {
        //test to see if particular dictionary already exists.
        int poolKey = prefab.GetInstanceID();
        if (!_poolDictionary.ContainsKey(poolKey))
        {
            // add dictionary if it doesn't.
            _poolDictionary.Add(poolKey, new Queue<GameObject>());
        }
        for (int i = 0; i < poolsize; i++)
        {
            GameObject newObject = Instantiate(prefab);
            newObject.SetActive(false);
            _poolDictionary[poolKey].Enqueue(newObject);
        }
    }

    /// <summary>
    /// Reuse an object in a pool.  Note that as it is immediately placed back in the pool,
    /// even though it is activated.
    /// </summary>
    /// <param name="prefab"></param>
    /// <param name="position"></param>
    /// <param name="rotation"></param>
    public void RecycleObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        int poolKey = prefab.GetInstanceID();
        if (_poolDictionary.ContainsKey(poolKey))
        {
            if (_poolDictionary[poolKey].Count == 0)
            {
                AddToPool(prefab, 1);
            }
            GameObject objectToReuse = _poolDictionary[poolKey].Dequeue();
            _poolDictionary[poolKey].Enqueue(objectToReuse);

            objectToReuse.transform.position = position;
            objectToReuse.transform.rotation = rotation;
            objectToReuse.SetActive(true);
        }
    }
    #endregion

    #region DEFUNCT
    //#region PUBLIC MEMBERS

    //public T _preFab;

    //#endregion

    //#region PRIVATE MEMBERS

    //public static cPool Instance { get; private set; }

    //Queue<T> poolObjects = new Queue<T>();

    //#endregion
    //private void Awake()
    //{
    //    Instance = this;
    //}

    //public T Get()
    //{
    //    if (poolObjects.Count == 0)
    //    {
    //        AddShots(1);
    //    }
    //    return poolObjects.Dequeue();
    //}

    //void AddShots(int count)
    //{
    //    for (int i = 0; i < count; i++)
    //    {
    //        GameObject T = Instantiate(_preFab);
    //        poolObjects.Enqueue(T);
    //    }
    //}    

    //public void ReturnToPool(T obj)
    //{
    //    obj.SetActive(false);
    //    poolObjects.Enqueue(obj);
    //}

    #endregion
}
