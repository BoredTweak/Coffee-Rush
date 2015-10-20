using UnityEngine;
using System.Collections;

public class Customer 
{
	public string Name{get;set;}
	public string Food{get;set;}
	public string Drink{get;set;}
	public float Cash{get;set;}
    public float RemainingTime { get; set; }

    public Customer(string name, string food, string drink, float cash, float remainingTime)
    {
        Name = name;
        Food = food;
        Drink = drink;
        Cash = cash;
        RemainingTime = remainingTime;
    }
}
