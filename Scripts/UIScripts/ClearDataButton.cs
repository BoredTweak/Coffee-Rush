using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class ClearDataButton : MonoBehaviour 
{
	private UnityAction action;

	void Start()
	{
		action = new UnityAction(OnClick);
		this.gameObject.GetComponent<Button>().onClick.AddListener(action);
	}

	void Update () 
	{
		
	}

	void OnClick()
	{
		if (this.gameObject.GetComponent<Button> ().GetComponentInChildren<Text> ().text == "Clear Data") 
		{
			this.gameObject.GetComponent<Button> ().GetComponentInChildren<Text> ().text = "Confirm?";
		}
		else
		{
			Time.timeScale = 0;
			ResourceKeeper.Clear();
			SaveData.ClearAllSaveData();
			Time.timeScale = 1;
			Application.LoadLevel ("PrepScene");
		}
	}
}
