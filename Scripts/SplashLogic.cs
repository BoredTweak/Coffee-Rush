using UnityEngine;
using System.Collections;

public class SplashLogic : MonoBehaviour 
{
	float timer = 5f;

	void Start () 
	{

	}

	void Update () 
	{
		timer -= Time.deltaTime;
		if (timer <= 0) 
		{
			ResourceKeeper.SetupLists();
			if(SaveData.LoadProgression() != 0)
			{
				
				LocationKeeper.LocationOptions.Add(Location.Columbia);
				LocationKeeper.LocationOptions.Add (Location.Seattle);
				foreach(Location location in LocationKeeper.LocationOptions)
				{
					if(SaveData.LoadLocation() == location.Name)
					{
						LocationKeeper.location = location;
					}
				}
				ResourceKeeper.LoadResources();

				SaveData.LoadName();
				//load all save data and throw it to loadlevel("MainScene");
				Application.LoadLevel ("MainScene");
			}
			else
			{
				Application.LoadLevel ("PrepScene");
			}
		}
	}
}
