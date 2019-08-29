using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FoodUI : MonoBehaviour
{
    public TextMeshProUGUI UIcapacity;
    public Text UIlevel;

    void Update()
    {
        UIcapacity.SetText(PlayerScript.currentFood + "/" + gameObject.GetComponent<EdificationScript>().currentCapacity);
        UIlevel.text = ("+" + (PlayerScript.foodLevel+1));
    }
}
