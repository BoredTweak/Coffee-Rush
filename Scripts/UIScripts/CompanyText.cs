using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CompanyText : MonoBehaviour
{
	void Start ()
    {
        GetComponent<Text>().text = CompanyManager.CompanyName + "'s Coffee Rush!";
	}
}
