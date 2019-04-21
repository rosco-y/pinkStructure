using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cGame : MonoBehaviour
{
    // Start is called before the first frame update

    public cPool _pool;
    public GameObject _prefab;

    public void NewGame()
    {
        print("cGame.NewGame()");
        cPool.Instance.AddToPool(_prefab, 10);
    }

    private void Update()
    {

    }
}
