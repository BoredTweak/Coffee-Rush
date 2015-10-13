using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoastedCoffeeEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Text[] textobjects = gameObject.GetComponentsInChildren<Text>();
        textobjects[1].text = ((int)ResourceKeeper.resourceList[(int)ResourceName.Roasted_Coffee].Quantity).ToString();
        textobjects[2].text = "$" + ResourceKeeper.resourceList[(int)ResourceName.Roasted_Coffee].Cost.ToString();
    }
}
