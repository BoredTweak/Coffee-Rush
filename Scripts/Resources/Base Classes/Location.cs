using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Location
{
	public string Name{ get; set; }
    public float CoffeeMakerMod { get; set; }
    public float CoffeeRoasterMod { get; set; }
    public float BaristaMod { get; set; }
    public float FarmMod { get; set; }

    public Location(string Name, float CoffeeMakerMod = 1, float CoffeeRoasterMod = 1, float BaristaMod = 1, float FarmMod = 1)
    {
		this.Name = Name;
        this.CoffeeMakerMod = CoffeeMakerMod;
        this.CoffeeRoasterMod = CoffeeRoasterMod;
        this.BaristaMod = BaristaMod;
        this.FarmMod = FarmMod;
    }

    public static Location Seattle = new Location("Seattle", 0.8f, 1f, 0.5f, 2.0f);
    public static Location Columbia = new Location("Columbia", 1.0f, 0.8f, 1.3f, 0.3f);

 
}

public enum LocationNames
{
    Seattle = 0,
    Columbia = 1
}