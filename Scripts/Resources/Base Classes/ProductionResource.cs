using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProductionResource
{
	public string Type{get;set;}
	public float Quantity{get;set;}
	public float Cost{ get; set; }
	public string CostResource{ get; set; }
    public float Growth { get; set; }
	
	public float MaxTimer { get; set; }
	public float CurrentTimer{get;set;}

    public ResourceModifier Modifier { get; set; }
    
    public ProductionResource(string Type, string CostResource, float MaxTimer, int Quantity = 0, float Cost = 0, float Growth = 0)
    {
        this.Type = Type;
        this.CostResource = CostResource;
        this.Quantity = Quantity;
        this.Cost = Cost;
        this.Growth = Growth;
		this.MaxTimer = MaxTimer;
		this.CurrentTimer = MaxTimer;
    }

    public float CostScaling(int quantityMod)
    {
        float scaledCost;

        /* this is the issue */
        scaledCost = Cost * (Quantity + quantityMod);
            //Cost * (( ((Quantity + quantityMod) * ((Quantity + quantityMod) + 1)) / 2 ) - (((Quantity) * ((Quantity) + 1)) / 2));

        return scaledCost;
    }

    public float MultipliedCost
    {
        get
        {
            float modifier = 1;
            if(this.Type == "Coffee Maker")
            {
                modifier = LocationKeeper.location.CoffeeMakerMod;
            }
            else if(this.Type == "Coffee Roaster")
            {
                modifier = LocationKeeper.location.CoffeeRoasterMod;
            }
            else if (this.Type == "Farm")
            {
                modifier = LocationKeeper.location.FarmMod;
            }
            else if(this.Type == "Barista")
            {
                modifier = LocationKeeper.location.BaristaMod;
            }

            float currentCost = 0;

            for (int i = 1; i < QuantityModifier.QuantityMod + 1; i++)
            {
                currentCost += CostScaling(i) * modifier;
            }

            return currentCost;
        }
    }

    public static ProductionResource CoffeeMaker = new ProductionResource(ProducerName.Coffee_Maker.ToString().Replace("_", " "), ResourceName.Cash.ToString(), 5, 0, 5, 0);
    public static ProductionResource Barista = new ProductionResource(ProducerName.Barista.ToString().Replace("_", " "), ResourceName.Cash.ToString(), 20, 0, 100, 0);
    public static ProductionResource Farm = new ProductionResource(ProducerName.Farm.ToString().Replace("_", " "), ResourceName.Cash.ToString(), 100, 0, 1000, 0);
    public static ProductionResource CoffeeRoaster = new ProductionResource(ProducerName.Coffee_Roaster.ToString().Replace("_", " "), ResourceName.Cash.ToString(), 25, 0, 150, 0);
}

public enum ProducerName
{
    Coffee_Maker = 0,
    Barista = 1,
    Farm = 2,
    Coffee_Roaster = 3
}