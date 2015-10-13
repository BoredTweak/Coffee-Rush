using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class SetupResourceModifiers 
{
	public static void InstantiateModifiers(this List<ProductionResource> productionList, List<Resource> resourceList)
	{

        productionList[(int)ProducerName.Coffee_Maker].Modifier = new ResourceModifier(resourceList[(int)ResourceName.Brewed_Coffee], 2f, resourceList[(int)ResourceName.Roasted_Coffee], 1f);
        productionList[(int)ProducerName.Coffee_Maker].Modifier.SourceResource = productionList[(int)ProducerName.Coffee_Maker];
        productionList[(int)ProducerName.Barista].Modifier = new ResourceModifier(resourceList[(int)ResourceName.Cash], 10f, resourceList[(int)ResourceName.Brewed_Coffee], 8f);
        productionList[(int)ProducerName.Barista].Modifier.SourceResource = productionList[(int)ProducerName.Barista];

        productionList[(int)ProducerName.Coffee_Roaster].Modifier = new ResourceModifier(resourceList[(int)ResourceName.Roasted_Coffee], 22f, resourceList[(int)ResourceName.Green_Coffee], 25f);
        productionList[(int)ProducerName.Coffee_Roaster].Modifier.SourceResource = productionList[(int)ProducerName.Coffee_Roaster];
        productionList[(int)ProducerName.Farm].Modifier = new ResourceModifier(resourceList[(int)ResourceName.Green_Coffee], 500f, Resource.Empty);
        productionList[(int)ProducerName.Farm].Modifier.SourceResource = productionList[(int)ProducerName.Farm];

        /*
		List<ResourceModifier> resourceModifiers = new List<ResourceModifier> ();
        resourceModifiers.Add(new ResourceModifier(productionList[(int)ProducerName.CoffeeMaker], resourceList[(int)ResourceName.BrewedCoffee], 0.02f));
        resourceModifiers.Add(new ResourceModifier(productionList[(int)ProducerName.CoffeeMaker], resourceList[(int)ResourceName.RoastedCoffee], -0.01f));
        resourceModifiers.Add(new ResourceModifier(productionList[(int)ProducerName.Barista], resourceList[(int)ResourceName.Cash], 0.015f));
        resourceModifiers.Add(new ResourceModifier(productionList[(int)ProducerName.Barista], resourceList[(int)ResourceName.BrewedCoffee], -0.01f));
        resourceModifiers.Add(new ResourceModifier(productionList[(int)ProducerName.CoffeeRoaster], resourceList[(int)ResourceName.RoastedCoffee], 0.01f));
        resourceModifiers.Add(new ResourceModifier(productionList[(int)ProducerName.CoffeeRoaster], resourceList[(int)ResourceName.GreenCoffee], -0.01f));
		resourceModifiers.Add(new ResourceModifier(productionList[(int)ProducerName.Farm], resourceList[(int)ResourceName.GreenCoffee], 0.10f));
        return resourceModifiers;*/

        /*
		foreach (Resource resource in resourceList) 
		{
			if(resource.Type == ResourceName.BrewedCoffee.ToString ())
			{
				index = resourceList.FindIndex(x => x.Type == ResourceName.BrewedCoffee.ToString ());
				resource.Growth = resourceList[index].Quantity;
			}
		}*/
    }
}
