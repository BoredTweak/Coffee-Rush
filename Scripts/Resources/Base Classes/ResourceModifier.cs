using UnityEngine;
using System.Collections;

public class ResourceModifier 
{
    public Resource IncreasingResource { get; set; }
    public float IncreaseRate { get; set; }
    public Resource DecreasingResource { get; set; }
    public float DecreaseRate { get; set; }

    public float LowQuantityPercentage { get; set; }

    //public Resource AffectedResource { get; set; }
    //public float GrowthRate { get; set; }
    
    
	public ProductionResource SourceResource{ get; set; }
    /*
	public Resource IncreasingResource{get;set;}
	public float IncreaseRate{ get; set;}
	public Resource DecreasingResource{ get; set; }
	public float DecreaseRate { get; set; }
    */
    public ResourceModifier(Resource IncreasingResource, float IncreaseRate, Resource DecreasingResource, float DecreaseRate = 0)//(ProductionResource SourceResource, Resource AffectedResource, float GrowthRate)   
	{
        /*this.SourceResource = SourceResource;
        this.AffectedResource = AffectedResource;
        this.GrowthRate = GrowthRate;
        */
		//this.SourceResource = SourceResource;
		this.IncreasingResource = IncreasingResource;
		this.IncreaseRate = IncreaseRate;
		this.DecreasingResource = DecreasingResource;
		this.DecreaseRate = DecreaseRate;
	}
}
