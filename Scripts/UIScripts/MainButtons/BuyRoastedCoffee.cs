using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class BuyRoastedCoffee : MonoBehaviour {
    private UnityAction action;

    // Use this for initialization
    void Start()
    {
        action = new UnityAction(BuyRoasted);
        this.gameObject.GetComponent<Button>().onClick.AddListener(action);
    }

    // Update is called once per frame
    void Update()
    {
        if (ResourceKeeper.resourceList[(int)ResourceName.Cash].Quantity >= ResourceKeeper.resourceList[(int)ResourceName.Roasted_Coffee].Cost * QuantityModifier.QuantityMod)
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

    public void BuyRoasted()
    {
        ResourceKeeper.resourceList[(int)ResourceName.Cash].Quantity -= ResourceKeeper.resourceList[(int)ResourceName.Roasted_Coffee].Cost * QuantityModifier.QuantityMod;
        ResourceKeeper.resourceList[(int)ResourceName.Roasted_Coffee].Quantity += QuantityModifier.QuantityMod;
        GetComponent<ParticleSystem>().Play();
        SaveData.SaveResources();
    }
}
