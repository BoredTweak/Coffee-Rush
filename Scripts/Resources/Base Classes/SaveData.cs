using UnityEngine;
using System.Collections;

public static class SaveData
{
	public static void ClearAllSaveData()
	{
		ResourceKeeper.Clear ();
		PlayerPrefs.DeleteAll ();
	}

	public static void RetireSaveData()
	{
		int progress = PlayerPrefs.GetInt ("Progress");
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.SetInt ("Progress", progress);
	}

    public static void SaveResources()
    {
        foreach(Resource resource in ResourceKeeper.resourceList)
		{
			PlayerPrefs.SetFloat(resource.Type, resource.Quantity);
		}
    }

    public static void LoadResources()
    {

    }

	public static void SaveProgression(int number)
	{
		PlayerPrefs.SetInt ("Progress", number);
	}

	public static int LoadProgression()
	{
		return PlayerPrefs.GetInt ("Progress");
	}

	public static void SaveResource(Resource resource)
	{
		PlayerPrefs.SetFloat (resource.Type, resource.Quantity);
	}

	public static float LoadResource(string resourceName)
	{
		return PlayerPrefs.GetFloat (resourceName);
	}

	public static void SaveProducer(ProductionResource productionResource)
	{
		PlayerPrefs.SetFloat (productionResource.Type, productionResource.Quantity);
	}

	public static float LoadProducer(string producterName)
	{
		return PlayerPrefs.GetFloat (producterName);
	}

	public static void SaveName(string Name)
	{
		PlayerPrefs.SetString ("Name", Name);
	}

	public static void LoadName()
	{
		CompanyManager.CompanyName = PlayerPrefs.GetString ("Name");
	}

	public static void SaveLocation(Location location)
	{
		PlayerPrefs.SetString ("Location", location.Name);
	}

	public static string LoadLocation()
	{
		return PlayerPrefs.GetString ("Location");
	}

	public static void DebugLog()
	{
		Debug.Log (LoadLocation ());
	}
}
