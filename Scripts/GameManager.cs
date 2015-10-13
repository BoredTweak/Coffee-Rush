using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	void Start()
	{
        QuantityModifier.Instantiate();
    }

	void Update()
	{
        ResourceKeeper.Update();
	}
}
