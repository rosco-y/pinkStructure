﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets._SCRIPTS;
public class cItem : MonoBehaviour
{

    cPrice _price;
    private void Start()
    {
        print($"This item is initially priced at: {_price:C}");
    }
}
