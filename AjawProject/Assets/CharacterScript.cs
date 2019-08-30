using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public enum HUMAN_TYPE
    {
        DEFAULT,
        REPRODUCT,
        FOOD
    }

    private HUMAN_TYPE type;
    public float currentEnergy = 10;
    public float maxEnergy = 10;
    public float energyConsumption = 0.5f;
    public bool working = false;
    public GameObject UIdivinity;

    void Start()
    {
        type = HUMAN_TYPE.DEFAULT;
        currentEnergy = maxEnergy;
        working = true;
    }

    public void SendTo(string workIn)
    {
        if(workIn == "food")
        {
            type = HUMAN_TYPE.FOOD;
        }
        else if(workIn == "reproduction")
        {
            type = HUMAN_TYPE.REPRODUCT;
        }
    }

    public void Update()
    {
        if (working)
            currentEnergy -= Time.deltaTime * energyConsumption;
        else if (working == true && currentEnergy < maxEnergy)
            currentEnergy += Time.deltaTime * energyConsumption;
        else if (currentEnergy > maxEnergy)
            currentEnergy = maxEnergy;

        if (currentEnergy >= 0)
            UIdivinity.transform.localScale = new Vector3(currentEnergy/maxEnergy, 1.0f, 1.0f);
        else
            UIdivinity.transform.localScale = new Vector3(0.0f, 1.0f, 1.0f);
        // TODO: kill human
    }
}
