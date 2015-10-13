using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;

public class Resource : INotifyPropertyChanged
{
	public string Type{get;set;}
    public float Quantity;
	public float Cost{ get; set; }
	public string CostResource{ get; set; }
	public float Growth{ get; set; }
	public string ResourceForUpgrade{ get; set; }
    //public int MaximumCap{get;set;}


	private List<ResourceModifier> modifiers = new List<ResourceModifier>();

	public event PropertyChangedEventHandler PropertyChanged;

	public void AddModifier(ResourceModifier modifier)
	{
		modifiers.Add (modifier);
	}

	public void ClearModifiers()
	{
		modifiers.Clear ();
	}

	public void CalculateGrowthValue()
	{
		Growth = 0;
		if(modifiers.Count > 0)
		{
			foreach(ResourceModifier modifier in modifiers)
			{
                /*if (modifier.DecreasingResource.Type == this.Type)
                {
                    Growth += (float)(modifier.SourceResource.Quantity * modifier.GrowthRate);
                }*/
                
				if(modifier.IncreasingResource.Type == this.Type)
				{
					Growth += (float)(modifier.SourceResource.Quantity * modifier.IncreaseRate * modifier.LowQuantityPercentage); 
				}
				else if(modifier.DecreasingResource.Type == this.Type)
				{
					Growth -= (float)(modifier.SourceResource.Quantity * modifier.DecreaseRate * modifier.LowQuantityPercentage);
				}
            }
		}
	}

	public Resource(string Type, string CostResource, int Quantity = 0, float Cost = 0, float Growth = 0)
	{
		this.Type = Type;
		this.CostResource = CostResource;
		this.Quantity = Quantity;
		this.Cost = Cost;
		this.Growth = Growth;
	}

	public static Resource Cash = new Resource(ResourceName.Cash.ToString().Replace("_", " "), String.Empty, 0, 0, 0);
	public static Resource BrewedCoffee = new Resource(ResourceName.Brewed_Coffee.ToString().Replace("_", " "), String.Empty, 1, 1, 0);
	public static Resource GreenCoffee = new Resource(ResourceName.Green_Coffee.ToString().Replace("_", " "), String.Empty, 0, 0.5f, 0);
	public static Resource RoastedCoffee = new Resource (ResourceName.Roasted_Coffee.ToString ().Replace("_", " "), ResourceName.Cash.ToString(), 1, 1, 0);
	public static Resource Empty = new Resource (String.Empty, String.Empty, 0, 0, 0);
	

	public void Increment()
	{
			Quantity += Growth;
			OnPropertyChanged (Type);
	}

	protected void OnPropertyChanged(string name)
	{
		PropertyChangedEventHandler handler = PropertyChanged;
		if(handler != null)
		{
			handler(this, new PropertyChangedEventArgs(name));
		}
	}
}

public enum ResourceName
{
	Cash = 0,
	Brewed_Coffee = 1,
	Green_Coffee = 2,
	Roasted_Coffee = 3,
}