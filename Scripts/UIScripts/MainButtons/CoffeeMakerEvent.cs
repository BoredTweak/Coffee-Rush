using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoffeeMakerEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        Text[] textobjects = gameObject.GetComponentsInChildren<Text>();
        textobjects[1].text = ((int)ResourceKeeper.producerList[(int)ProducerName.Coffee_Maker].Quantity).ToString();
        textobjects[2].text = "$" + ResourceKeeper.producerList[(int)ProducerName.Coffee_Maker].MultipliedCost.ToString("0.00");
    }
}

//int index = ResourceKeeper.producerList.FindIndex(x => x.Type == (textobjects[0].text.ToString()));
//Debug.Log(textobjects[0].text.ToString());
//Debug.Log(index);