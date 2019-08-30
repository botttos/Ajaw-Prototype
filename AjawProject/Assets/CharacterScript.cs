using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CharacterScript : MonoBehaviour
{
    public enum HUMAN_TYPE
    {
        DEFAULT,
        REPRODUCT,
        FOOD
    }

    public HUMAN_TYPE type = HUMAN_TYPE.DEFAULT;
    public float currentEnergy = 10;
    public float maxEnergy = 10;
    public float energyConsumption = 0.5f;
    public bool working = false;
    public GameObject UIdivinity;

    public GameObject defaultList;
    public GameObject foodList;
    public GameObject reproductionList;

    public void SendTo(string workIn)
    {
        if (defaultList.transform.childCount > 0)
        {
            int moreEnergy = 0;
            for (int j = 0; j < defaultList.transform.childCount; j++)
            {
                if (defaultList.transform.GetChild(j).GetComponent<CharacterScript>().currentEnergy > defaultList.transform.GetChild(moreEnergy).GetComponent<CharacterScript>().currentEnergy)
                    moreEnergy = j;
            }
            if (workIn == "food")
            {
                defaultList.transform.GetChild(moreEnergy).GetComponent<CharacterScript>().type = HUMAN_TYPE.FOOD;
                defaultList.transform.GetChild(moreEnergy).GetComponent<CharacterScript>().working = true;
                //defaultList.transform.GetChild(moreEnergy).transform.Find("barra energia/fill").GetComponent<Image>().color = Color.blue;
                defaultList.transform.GetChild(moreEnergy).transform.parent = foodList.transform;
            }
            else if (workIn == "reproduction")
            {
                defaultList.transform.GetChild(moreEnergy).GetComponent<CharacterScript>().type = HUMAN_TYPE.REPRODUCT;
                defaultList.transform.GetChild(moreEnergy).GetComponent<CharacterScript>().working = true;
                //defaultList.transform.GetChild(moreEnergy).transform.Find("barra energia/fill").GetComponent<Image>().color = Color.yellow;
                defaultList.transform.GetChild(moreEnergy).transform.parent = reproductionList.transform;
            }
        }
    }

    public void ReturnToHousesFood()
    {
        if (foodList.transform.childCount > 0)
        {
            int lessEnergy = 0;
            for (int j = 0; j < foodList.transform.childCount; j++)
            {
                if (foodList.transform.GetChild(j).GetComponent<CharacterScript>().currentEnergy < foodList.transform.GetChild(lessEnergy).GetComponent<CharacterScript>().currentEnergy)
                    lessEnergy = j;
            }
            foodList.transform.GetChild(lessEnergy).GetComponent<CharacterScript>().working = false;
            foodList.transform.GetChild(lessEnergy).transform.parent = defaultList.transform;
        }
    }
    public void ReturnToHousesReproduction()
    {
        if (reproductionList.transform.childCount > 0)
        {
            int lessEnergy = 0;
            for (int j = 0; j < reproductionList.transform.childCount; j++)
            {
                if (reproductionList.transform.GetChild(j).GetComponent<CharacterScript>().currentEnergy < reproductionList.transform.GetChild(lessEnergy).GetComponent<CharacterScript>().currentEnergy)
                    lessEnergy = j;
            }
            reproductionList.transform.GetChild(lessEnergy).GetComponent<CharacterScript>().working = false;
            reproductionList.transform.GetChild(lessEnergy).transform.parent = defaultList.transform;
        }
    }
    public void Update()
    {
        if (working)
            currentEnergy -= Time.deltaTime * energyConsumption;
        else if (working == false && currentEnergy < maxEnergy)
            currentEnergy += Time.deltaTime * energyConsumption;
        else if (currentEnergy > maxEnergy)
            currentEnergy = maxEnergy;

        if (currentEnergy > 0)
            UIdivinity.transform.localScale = new Vector3(currentEnergy / maxEnergy, 1.0f, 1.0f);
        else
            Destroy(gameObject);
        // TODO: kill human
    }
}
