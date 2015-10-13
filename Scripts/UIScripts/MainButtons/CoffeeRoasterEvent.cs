using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoffeeRoasterEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Text[] textobjects = gameObject.GetComponentsInChildren<Text>();
        textobjects[1].text = ((int)ResourceKeeper.producerList[(int)ProducerName.Coffee_Roaster].Quantity).ToString();
        textobjects[2].text = "$" + ResourceKeeper.producerList[(int)ProducerName.Coffee_Roaster].MultipliedCost.ToString("0.00");
    }
}
