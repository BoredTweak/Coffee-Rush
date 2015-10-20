using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CustomerManager : MonoBehaviour
{

    public List<Customer> CustomerList = new List<Customer>();
    public float BaseNewCustomerTimer = 3;//15f;
    public float NewCustomerTimer;
    public Slider customerTimerSlider;
    public GameObject CustomerListPanel;
    public Font standardFont;

    void Start()
    {
        NewCustomerTimer = BaseNewCustomerTimer;
        customerTimerSlider = gameObject.GetComponentInChildren<Slider>();
        CustomerListPanel = GameObject.Find("CustomerListPanel");
        /*GameObject[] gameobjects = gameObject.GetComponentsInChildren<GameObject>();
        foreach (GameObject gameobject in gameobjects)
        {
            if (gameobject.name == "CustomerListPanel")
            {
                CustomerListPanel = gameobject;
            }
        }*/
    }

    void Update()
    {
        if(NewCustomerTimer <= 0)
        {
            Customer newguy = new Customer(NameGenerator.GrabRandomName(), "Food", "Drink", 1.05f, BaseNewCustomerTimer);
            CustomerList.Add(newguy);
            Debug.Log("Customer Name: " + newguy.Name);
            Debug.Log("Customer Count: " + CustomerList.Count);
            NewCustomerTimer = BaseNewCustomerTimer;
            SetSlider(1);

            SetPanelContents();
        }
        else
        {
            NewCustomerTimer -= Time.deltaTime;
            SetSlider(NewCustomerTimer / BaseNewCustomerTimer);
        }
    }

    void SetPanelContents()
    {
        foreach(Transform child in CustomerListPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Customer customer in CustomerList)
        {
            GameObject textobject = (GameObject)Instantiate(new GameObject());
            textobject.transform.SetParent(CustomerListPanel.transform, false);
            textobject.transform.localScale = Vector3.one;
            Text text = textobject.AddComponent<Text>();
            text.color = Color.white;
            text.text = customer.Name;
            text.font = standardFont;
        }
    }

    void SetSlider(float percent)
    {
        customerTimerSlider.value = percent;
    }
}
