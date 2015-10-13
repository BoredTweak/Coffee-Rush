using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class PanhandleButtonVisibility : MonoBehaviour 
{

	private UnityAction action;
	
	// Use this for initialization
	void Start()
	{
		action = new UnityAction(GetMoney);
		this.gameObject.GetComponent<Button>().onClick.AddListener(action);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Resource brewed = ResourceKeeper.resourceList[(int)ResourceName.Brewed_Coffee];
		Resource roasted = ResourceKeeper.resourceList[(int)ResourceName.Roasted_Coffee];
		Resource cash = ResourceKeeper.resourceList[(int)ResourceName.Cash];
		if(brewed.Quantity < 1 && roasted.Quantity < 1 && cash.Quantity < 1)
		{
			this.gameObject.GetComponent<Button>().enabled = true;
			this.gameObject.GetComponent<Image>().enabled = true;
			this.gameObject.GetComponentInChildren<Text>().enabled = true;
		}
		else
		{
			if(this.gameObject.GetComponent<Button>().enabled == true)
			{
				this.gameObject.GetComponent<Button>().enabled = false;
				this.gameObject.GetComponent<Image>().enabled = false;
				this.gameObject.GetComponentInChildren<Text>().enabled = false;
			}
		}
	}

	void GetMoney()
	{
		ResourceKeeper.resourceList [(int)ResourceName.Cash].Quantity += 1;
	}

}
