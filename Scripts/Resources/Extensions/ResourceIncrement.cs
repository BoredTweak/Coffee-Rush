using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public static class ResourceIncrement 
{
	public static void Increment(this List<Resource> resourceList)
	{
		foreach(Resource resource in resourceList)
		{
			resource.Quantity += resource.Growth;
			SaveData.SaveResource(resource);
            //Messenger.Broadcast(resource.Type);
			if(resource.Type == Resource.Cash.Type)
			{
				Experience.Points += resource.Growth;
				SaveData.SaveProgression ((int)Experience.Points);
				//Debug.Log (Experience.Points);
				//Debug.Log (SaveData.LoadProgression());
			}
        }
	}
}
