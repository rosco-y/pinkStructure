using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cConductor : MonoBehaviour
{
  
    public cGame _game;
    private void Start()
    {
        NewGame();
    }

    public void NewGame()
    {
        print("cConductor.NewGame()");
        _game.NewGame();
    }
}
