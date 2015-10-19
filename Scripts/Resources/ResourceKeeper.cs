using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class ResourceKeeper
{
    public static List<Resource> resourceList = new List<Resource>();
    public static List<ProductionResource> producerList = new List<ProductionResource>();

	public static void SaveProduction(int producerIndex)
	{
		SaveData.SaveProducer (producerList[producerIndex]);
	}

	public static void LoadResources()
	{
		foreach(Resource resource in resourceList)
		{
			resource.Quantity = SaveData.LoadResource (resource.Type);
		}

		foreach(ProductionResource producer in producerList)
		{
			producer.Quantity = SaveData.LoadProducer(producer.Type);
		}
	}

    public static void SetupLists()
    {
        resourceList = ListInstantiater.ResourceList();
        producerList = ListInstantiater.ProductionList();
        producerList.InstantiateModifiers(resourceList);
    }

    public static void Update()
    {
		SaveData.SaveResources ();
		foreach(ProductionResource producer in producerList)
		{
			if(producer.Quantity > 0)
			{
				if(producer.CurrentTimer > 0)
				{
					producer.CurrentTimer -= Time.deltaTime;
				}
				else if(producer.CurrentTimer <= 0)
				{
					if(producer.Modifier.DecreasingResource != Resource.Empty)
					{
						float producerNeeds = (producer.Modifier.DecreaseRate * producer.Quantity);

						
						/*if(producer.Type == producerList[(int)ProducerName.Coffee_Maker].Type)
						{
							Debug.Log (">" + (producerNeeds));
							Debug.Log ((resourceList.Find(x => x.Type == producer.Modifier.DecreasingResource.Type).Quantity));
						}*/

						//Debug.Log(producer.Modifier.DecreaseRate * producer.MaxTimer * producer.Quantity);
						//Debug.Log ((resourceList.Find(x => x.Type == producer.Modifier.DecreasingResource.Type).Quantity * producer.Quantity));
						if((producerNeeds <= (resourceList.Find(x => x.Type == producer.Modifier.DecreasingResource.Type).Quantity)) && resourceList.Find(x => x.Type == producer.Modifier.DecreasingResource.Type).Quantity - producerNeeds >= 0 )
						{
							
							if(producer.Modifier.IncreasingResource.Type == Resource.Cash.Type)
							{
								Experience.Points += producer.Modifier.IncreaseRate * producer.Quantity;
								SaveData.SaveProgression ((int)Experience.Points);
							}
							resourceList.Find(x => x.Type == producer.Modifier.DecreasingResource.Type).Quantity -= producerNeeds;
							resourceList.Find (x => x.Type == producer.Modifier.IncreasingResource.Type).Quantity += producer.Modifier.IncreaseRate * producer.Quantity;
							producer.CurrentTimer = producer.MaxTimer;
						}
                        else
                        {
                            float partialQuantityPercent = resourceList.Find(x => x.Type == producer.Modifier.DecreasingResource.Type).Quantity / producerNeeds;

                            if (producer.Modifier.IncreasingResource.Type == Resource.Cash.Type)
                            {
                                Experience.Points += producer.Modifier.IncreaseRate * producer.Quantity * partialQuantityPercent;
                                SaveData.SaveProgression((int)Experience.Points);
                            }
                            resourceList.Find(x => x.Type == producer.Modifier.DecreasingResource.Type).Quantity -= producerNeeds * partialQuantityPercent;
                            resourceList.Find(x => x.Type == producer.Modifier.IncreasingResource.Type).Quantity += producer.Modifier.IncreaseRate * producer.Quantity * partialQuantityPercent;
                            producer.CurrentTimer = producer.MaxTimer;
                        }
					}
					else
					{
						resourceList.Find (x => x.Type == producer.Modifier.IncreasingResource.Type).Quantity += producer.Modifier.IncreaseRate * producer.Quantity;
						producer.CurrentTimer = producer.MaxTimer;
					}
				}
			}
		}
		//TODO: Change this for progress bar methodology instead - timer decrease and lump sum payout
        /*foreach (Resource resource in resourceList)
        {
            resource.ClearModifiers();
        }

        List<ResourceModifier> applyingModifiers = new List<ResourceModifier>();
        foreach (ProductionResource productionResource in producerList)
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

        foreach (ResourceModifier modifier in applyingModifiers)
        {
            resourceList.Find(x => x.Type == modifier.IncreasingResource.Type).AddModifier(modifier);
            if (modifier.DecreasingResource != Resource.Empty)
            {
                resourceList.Find(x => x.Type == modifier.DecreasingResource.Type).AddModifier(modifier);
            }
        }

        foreach (Resource resource in resourceList)
        {
            resource.CalculateGrowthValue();
        }

        resourceList.Increment();*/
    }

	public static void Clear()
	{
		foreach(Resource resource in resourceList)
		{
			resource.Quantity = 0;
		}
		foreach(ProductionResource producer in producerList)
		{
			producer.Quantity = 0;
		}
		resourceList = new List<Resource>();
		producerList = new List<ProductionResource>();
		SetupLists ();
	}
}

