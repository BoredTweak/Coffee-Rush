using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FarmEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Text[] textobjects = gameObject.GetComponentsInChildren<Text>();
        textobjects[1].text = ((int)ResourceKeeper.producerList[(int)ProducerName.Farm].Quantity).ToString();
        textobjects[2].text = "$" + ResourceKeeper.producerList[(int)ProducerName.Farm].MultipliedCost.ToString("0.00");
    }
}
