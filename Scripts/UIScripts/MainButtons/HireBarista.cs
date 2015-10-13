using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

public class HireBarista : MonoBehaviour
{

    private UnityAction action;

    // Use this for initialization
    void Start()
    {
        action = new UnityAction(BuyBarista);
        this.gameObject.GetComponent<Button>().onClick.AddListener(action);
    }

    // Update is called once per frame
    void Update()
    {
        if (ResourceKeeper.resourceList[(int)ResourceName.Cash].Quantity >= ResourceKeeper.producerList[(int)ProducerName.Barista].MultipliedCost)
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

    public void BuyBarista()
    {
        ResourceKeeper.resourceList[(int)ResourceName.Cash].Quantity -= ResourceKeeper.producerList[(int)ProducerName.Barista].MultipliedCost;
        ResourceKeeper.producerList[(int)ProducerName.Barista].Quantity += QuantityModifier.QuantityMod;
		GetComponent<ParticleSystem>().Play();
		ResourceKeeper.SaveProduction ((int)ProducerName.Barista);
    }
}
