using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public static class ListInstantiater 
{
	public static List<Resource> ResourceList()
	{
		List<Resource> resourceList = new List<Resource>();

		resourceList.Add (Resource.Cash);
		resourceList.Add (Resource.BrewedCoffee);
		resourceList.Add (Resource.GreenCoffee);
		resourceList.Add (Resource.RoastedCoffee);

        

		return resourceList;
	}

    public static List<ProductionResource> ProductionList()
    {
        List<ProductionResource> productionList = new List<ProductionResource>();

        productionList.Add(ProductionResource.CoffeeMaker);
        productionList.Add(ProductionResource.Barista);
        productionList.Add(ProductionResource.Farm);
        productionList.Add(ProductionResource.CoffeeRoaster);

        return productionList;
    }
}

/*
 * 	Cash = 0,
	BrewedCoffee = 1,
	CoffeeMaker = 2,
	Barista = 3,
	Farm = 4,
	GreenCoffee = 5,
	RoastedCoffee = 6,
	CoffeeRoaster = 7
 */ 