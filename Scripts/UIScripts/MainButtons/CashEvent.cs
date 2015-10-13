using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CashEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

        Text[] textobjects = gameObject.GetComponentsInChildren<Text>();
        if (ResourceKeeper.resourceList[(int)ResourceName.Cash].Quantity > 10000000)
        {
            textobjects[1].text = ResourceKeeper.resourceList[(int)ResourceName.Cash].Quantity.ToString("$#.00E0");
        }
        else
        {
            textobjects[1].text = "$" + ResourceKeeper.resourceList[(int)ResourceName.Cash].Quantity.ToString();
        }
    }
}
