using UnityEngine;
using System.Collections;

public class ResourceButton : MonoBehaviour 
{
	public Resource TargetResource{get;set;}
	public Resource RequiredResource{get;set;}
	public float Cost{get;set;}

	void OnMouseDown()
	{
		if(TargetResource != null && RequiredResource != null)
		{
			if(RequiredResource.Quantity >= Cost)
			{
				RequiredResource.Quantity -= Cost;
				TargetResource.Quantity += 1;
			}
		}
	}
}
