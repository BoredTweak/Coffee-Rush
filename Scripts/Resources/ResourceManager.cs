using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ResourceManager {

	public List<Resource> resourceList;
	//public List<ResourceModifier> modifierList;
    public List<ProductionResource> productionList;

	// Use this for initialization
	public void Start () 
	{
		//modifierList = new List<ResourceModifier> ();
		resourceList = new List<Resource> ();
        productionList = new List<ProductionResource>();
        productionList = ListInstantiater.ProductionList();
		resourceList = ListInstantiater.ResourceList ();
        productionList.InstantiateModifiers(resourceList);
        //modifierList = productionList.InstantiateModifiers(resourceList);
    }
	
	// Update is called once per frame
	public void Update () 
	{
		foreach(Resource resource in resourceList)
		{
			resource.ClearModifiers();
		}

        List<ResourceModifier> applyingModifiers = new List<ResourceModifier>();
        foreach(ProductionResource productionResource in productionList)
        {
            if (productionResource.Modifier != null)
            {
                if (productionResource.Modifier.DecreasingResource != Resource.Empty)
                {
                    if ((productionResource.Quantity * productionResource.Modifier.DecreaseRate) <= resourceList.Find(x => x.Type == productionResource.Modifier.DecreasingResource.Type).Quantity)
                    {
                        productionResource.Modifier.LowQuantityPercentage = 1;
                        applyingModifiers.Add(productionResource.Modifier);
                    }
                    else
                    {
                        productionResource.Modifier.LowQuantityPercentage = (resourceList.Find(x => x.Type == productionResource.Modifier.DecreasingResource.Type).Quantity) / (productionResource.Quantity * productionResource.Modifier.DecreaseRate);
                        applyingModifiers.Add(productionResource.Modifier);
                    }
                }
                else
                {
                    productionResource.Modifier.LowQuantityPercentage = 1;
                    applyingModifiers.Add(productionResource.Modifier);
                }
            }
        }

        foreach(ResourceModifier modifier in applyingModifiers)
        {
            resourceList.Find(x => x.Type == modifier.IncreasingResource.Type).AddModifier(modifier);
            if (modifier.DecreasingResource != Resource.Empty)
            {
                resourceList.Find(x => x.Type == modifier.DecreasingResource.Type).AddModifier(modifier);
            }
        }

        /*foreach (ResourceModifier modifier in modifierList)
		{
            if (modifier.GrowthRate < 0)
            {
                if ((modifier.SourceResource.Quantity * modifier.GrowthRate) <= resourceList.Find(x => x.Type == modifier.AffectedResource.Type).Quantity)
                {
                    applyingModifiers.Add(modifier);
                }
                else
                {
                    if (applyingModifiers.FindAll(x => x.SourceResource == modifier.SourceResource).Count > 0)
                    {

                    }
                }
            }
            else
            {

            }
        }*/
                //applyingModifiers.FindAll(x => x.SourceResource == modifier.SourceResource).Count > 0 
                
            
			//resourceList.Find (x => x.Type == modifier.AffectedResource.Type).AddModifier(modifier);
		//}


		foreach(Resource resource in resourceList)
		{
			resource.CalculateGrowthValue();
		}

		resourceList.Increment();
	}


}
