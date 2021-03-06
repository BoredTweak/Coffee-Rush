﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class BuyGreenCoffee : MonoBehaviour {

    private UnityAction action;

    // Use this for initialization
    void Start()
    {
        action = new UnityAction(BuyGreen);
        this.gameObject.GetComponent<Button>().onClick.AddListener(action);
    }

    // Update is called once per frame
    void Update()
    {
        if (ResourceKeeper.producerList[(int)ProducerName.Coffee_Roaster].Quantity > 0 && ResourceKeeper.resourceList[(int)ResourceName.Cash].Quantity >= ResourceKeeper.resourceList[(int)ResourceName.Green_Coffee].Cost * QuantityModifier.QuantityMod)
        {
            this.gameObject.GetComponent<Button>().enabled = true;
            this.gameObject.GetComponent<Image>().enabled = true;
            this.gameObject.GetComponentInChildren<Text>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<Button>().enabled = false;
            this.gameObject.GetComponent<Image>().enabled = false;
            this.gameObject.GetComponentInChildren<Text>().enabled = false;
        }
    }

    public void BuyGreen()
    {
        ResourceKeeper.resourceList[(int)ResourceName.Cash].Quantity -= ResourceKeeper.resourceList[(int)ResourceName.Green_Coffee].Cost * QuantityModifier.QuantityMod;
        ResourceKeeper.resourceList[(int)ResourceName.Green_Coffee].Quantity += QuantityModifier.QuantityMod;
        GetComponent<ParticleSystem>().Play();
        SaveData.SaveResources();
    }
}
