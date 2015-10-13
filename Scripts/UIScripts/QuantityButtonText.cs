using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class QuantityButtonText : MonoBehaviour {

    private UnityAction action;

    // Use this for initialization
    void Awake()
    {
        action = new UnityAction(QuantityModifier.NextMod);
        this.gameObject.GetComponent<Button>().onClick.AddListener(action);
    }

    // Update is called once per frame
    void Update ()
    {
        gameObject.GetComponentInChildren<Text>().text = QuantityModifier.QuantityMod.ToString("0x");
    }
}
