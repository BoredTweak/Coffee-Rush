using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class BuyFarm : MonoBehaviour
{

    private UnityAction action;

    // Use this for initialization
    void Start()
    {
        action = new UnityAction(BuyFarms);
        this.gameObject.GetComponent<Button>().onClick.AddListener(action);
    }

    // Update is called once per frame
    void Update()
    {
        if (ResourceKeeper.resourceList[(int)ResourceName.Cash].Quantity >= ResourceKeeper.producerList[(int)ProducerName.Farm].MultipliedCost)
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

    public void BuyFarms()
    {
        ResourceKeeper.resourceList[(int)ResourceName.Cash].Quantity -= ResourceKeeper.producerList[(int)ProducerName.Farm].MultipliedCost;
        ResourceKeeper.producerList[(int)ProducerName.Farm].Quantity += QuantityModifier.QuantityMod;
		GetComponent<ParticleSystem>().Play();
		ResourceKeeper.SaveProduction ((int)ProducerName.Farm);
    }
}
