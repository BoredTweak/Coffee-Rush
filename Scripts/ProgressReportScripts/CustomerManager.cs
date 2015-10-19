using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CustomerManager : MonoBehaviour
{

    public List<Customer> CustomerList = new List<Customer>();
    public float BaseNewCustomerTimer = 15f;
    public float NewCustomerTimer;

    void Start()
    {
        NewCustomerTimer = BaseNewCustomerTimer;
        SetPanelContents();
    }

    void Update()
    {
        if(NewCustomerTimer <= 0)
        {
            Customer newguy = new Customer();
            newguy.Name = NameGenerator.GrabRandomName();
            CustomerList.Add(newguy);
        }
    }

    void SetPanelContents()
    {
        int i = 0;


        foreach (Customer customer in CustomerList)
        {
            Text text = gameObject.AddComponent<Text>();
            
            text.text = customer.Name;

            
        }
    }
}
