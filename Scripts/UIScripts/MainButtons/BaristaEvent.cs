using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BaristaEvent : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	}

    // Update is called once per frame
    void Update()
    {
        Text[] textobjects = gameObject.GetComponentsInChildren<Text>();
        textobjects[2].text = ((int)ResourceKeeper.producerList[(int)ProducerName.Barista].Quantity).ToString();
        textobjects[3].text = "$" + ResourceKeeper.producerList[(int)ProducerName.Barista].MultipliedCost.ToString("0.00");
        
		/*foreach(Text text in textobjects)
		{
			if(text.tag == "Quantity")
			{
				text.text = ((int)ResourceKeeper.producerList[(int)ProducerName.Barista].Quantity).ToString();
			}
			else if (text.text == "Cost")
			{
				text.text = "$" + ResourceKeeper.producerList[(int)ProducerName.Barista].MultipliedCost.ToString();
			}
		}
		/*
        if (ResourceKeeper.producerList[(int)ProducerName.Barista].MultipliedCost < 10000000)
        {
            textobjects[2].text = ResourceKeeper.producerList[(int)ProducerName.Barista].MultipliedCost.ToString("$0.00");
        }
        else
        {
            textobjects[2].text = ResourceKeeper.producerList[(int)ProducerName.Barista].MultipliedCost.ToString("$%e");
        }
        */
    }
}
