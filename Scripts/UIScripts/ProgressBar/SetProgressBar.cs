using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetProgressBar : MonoBehaviour 
{
	void Start () 
	{
	
	}
	
	void Update () 
	{
		float currentTimer = ResourceKeeper.producerList.Find (x => x.Type == this.transform.parent.name).CurrentTimer;
		float maxTimer = ResourceKeeper.producerList.Find (x => x.Type == this.transform.parent.name).MaxTimer;

		this.GetComponent<Slider> ().value = currentTimer / maxTimer;
		//Debug.Log (this.transform.parent.name + ": " + ResourceKeeper.producerList.Find (x => x.Type == this.transform.parent.name).CurrentTimer);
		//((int)ResourceKeeper.producerList[(int)ProducerName.Farm].Quantity).ToString()
		
//		Text[] textobjects = gameObject.GetComponentsInChildren<Text>();
//		textobjects[1].text = ((int)ResourceKeeper.producerList[(int)ProducerName.Farm].Quantity).ToString();
//		textobjects[2].text = "$" + ResourceKeeper.producerList[(int)ProducerName.Farm].MultipliedCost.ToString();
	}
}
