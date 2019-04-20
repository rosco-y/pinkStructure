using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cPool : MonoBehaviour
{

    #region PUBLIC MEMBERS

    public GameObject _preFab;

    #endregion

    #region PRIVATE MEMBERS

    public static cPool Instance { get; private set; }

    Queue<GameObject> poolObjects = new Queue<GameObject>();

    #endregion
    private void Awake()
    {
        Instance = this;
    }

    public GameObject Get()
    {
        if (poolObjects.Count == 0)
        {
            AddShots(1);
        }
        return poolObjects.Dequeue();
    }

    void AddShots(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(_preFab);
            poolObjects.Enqueue(obj);
        }
    }    
    
    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        poolObjects.Enqueue(obj);
    }
}
