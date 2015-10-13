using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class PreplayCanvasManager : MonoBehaviour
{

	void Start ()
    {
        //FindStartButton();
        SetupButtons();
	}
	
	void Update ()
    {
        SetStartVisibility();
	}

    void SetButtonVisibility(string clickedButton)
    {
        if (clickedButton == "Columbia")
        {
            LocationKeeper.location = Location.Columbia;
            LocationKeeper.SelectedIndex = (int)LocationNames.Columbia;
        }
        else if (clickedButton == "Seattle")
        {
            LocationKeeper.location = Location.Seattle;
            LocationKeeper.SelectedIndex = (int)LocationNames.Seattle;
        }
        Button[] buttons = this.gameObject.GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            if (button.GetComponentInChildren<Text>().text != "Start")
            {
                if (button.GetComponentInChildren<Text>().text == clickedButton)
                {
                    button.enabled = false;
                    button.GetComponentInParent<Image>().color = Color.grey;
                }
                else
                {
                    button.enabled = true;
                    button.GetComponentInParent<Image>().color = Color.white;
                }
            }
        }
    }

    void LoadGame()
    {
        CompanyManager.CompanyName = this.gameObject.GetComponentInChildren<InputField>().text;
		SaveData.SaveName (CompanyManager.CompanyName);
		SaveData.SaveLocation (LocationKeeper.location);
        Application.LoadLevel("MainScene");
    }
            
    void SetupButtons()
    {
        Button[] buttons = this.gameObject.GetComponentsInChildren<Button>();
        foreach(Button button in buttons)
        {
            if(button.GetComponentInChildren<Text>().text == "Start")
            {
                button.onClick.AddListener(new UnityAction(() => LoadGame()));
            }
            else if(button.GetComponentInChildren<Text>().text == "Columbia")
            {
                button.onClick.AddListener(new UnityAction(() => SetButtonVisibility("Columbia")));
            }
            else if(button.GetComponentInChildren<Text>().text == "Seattle")
            {
                button.onClick.AddListener(new UnityAction(() => SetButtonVisibility("Seattle")));
            }
        }
    }

    void SetStartVisibility()
    {
        if(LocationKeeper.location == null | string.IsNullOrEmpty(this.gameObject.GetComponentInChildren<InputField>().text))
        {
            Button[] buttons = this.gameObject.GetComponentsInChildren<Button>();
            foreach (Button button in buttons)
            {
                if (button.GetComponentInChildren<Text>().text == "Start")
                {
                    button.enabled = false; //.SetActive(false);
                }
            }
        }
        else
        {
            Button[] buttons = this.gameObject.GetComponentsInChildren<Button>();
            foreach (Button button in buttons)
            {
                if (button.GetComponentInChildren<Text>().text == "Start")
                {
                    button.enabled = true; //.gameObject.SetActive(true);
                }
            }
        }
    }
}
