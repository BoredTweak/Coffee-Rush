using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BrewedCoffeeEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Text[] textobjects = gameObject.GetComponentsInChildren<Text>();
        textobjects[2].text = ((int)ResourceKeeper.resourceList[(int)ResourceName.Brewed_Coffee].Quantity).ToString();
        //textobjects[2].text = "$" + ResourceKeeper.resourceList[(int)ResourceName.Brewed_Coffee].Cost.ToString();
    }
}
