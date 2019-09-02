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
            if (workIn == "food" && PlayerScript.currentFoodWorkers < PlayerScript.foodBuildingCapacity)
            {
                defaultList.transform.GetChild(moreEnergy).GetComponent<CharacterScript>().type = HUMAN_TYPE.FOOD;
                defaultList.transform.GetChild(moreEnergy).GetComponent<CharacterScript>().working = true;
                //defaultList.transform.GetChild(moreEnergy).transform.Find("barra energia/fill").GetComponent<Image>().color = Color.blue;
                defaultList.transform.GetChild(moreEnergy).transform.parent = foodList.transform;
                PlayerScript.currentFoodWorkers++;
                PlayerScript.houseWorkers--;
            }
            else if (workIn == "reproduction" && defaultList.transform.childCount > 1 && PlayerScript.reproductionWorkers * 2 < PlayerScript.reproductionHouseCapacity)
            {
                int moreEnergy2;
                if (moreEnergy != 0)
                    moreEnergy2 = 0;
                else
                    moreEnergy2 = 1;
                for (int k = 0; k < defaultList.transform.childCount; k++)
                {
                    if (k != moreEnergy)
                    {
                        if (defaultList.transform.GetChild(k).GetComponent<CharacterScript>().currentEnergy > defaultList.transform.GetChild(moreEnergy2).GetComponent<CharacterScript>().currentEnergy)
                            moreEnergy2 = k;
                    }
                }
                defaultList.transform.GetChild(moreEnergy).GetComponent<CharacterScript>().type = HUMAN_TYPE.REPRODUCT;
                defaultList.transform.GetChild(moreEnergy).GetComponent<CharacterScript>().working = true;
                defaultList.transform.GetChild(moreEnergy2).GetComponent<CharacterScript>().type = HUMAN_TYPE.REPRODUCT;
                defaultList.transform.GetChild(moreEnergy2).GetComponent<CharacterScript>().working = true;
                //defaultList.transform.GetChild(moreEnergy).transform.Find("barra energia/fill").GetComponent<Image>().color = Color.yellow;
                defaultList.transform.GetChild(moreEnergy).transform.parent = reproductionList.transform;
                if (moreEnergy > moreEnergy2)
                    defaultList.transform.GetChild(moreEnergy - 1).transform.parent = reproductionList.transform;
                else
                    defaultList.transform.GetChild(moreEnergy).transform.parent = reproductionList.transform;
                PlayerScript.reproductionWorkers++;
                PlayerScript.houseWorkers -= 2;
            }
        }
    }

    public void SacrificeHuman()
    {
        if (defaultList.transform.childCount > 0)
        {
            Destroy(defaultList.transform.GetChild(0).gameObject);
            PlayerScript.houseWorkers--;
            if (PlayerScript.currentDivinity + 15 <= (PlayerScript.maxDivinity + EventScript.event2) && ObjectScript.espinaMantarraya)
                PlayerScript.currentDivinity += 15;
            else if (PlayerScript.currentDivinity + 16 <= (PlayerScript.maxDivinity + EventScript.event2))
                PlayerScript.currentDivinity += 16;
            else
                PlayerScript.currentDivinity = (PlayerScript.maxDivinity + EventScript.event2);
        }
    }
    public void ReturnToHousesFood()
    {
        if (foodList.transform.childCount > 0)
        {
            int lessEnergy = 0;
            foodList.transform.GetChild(lessEnergy).GetComponent<CharacterScript>().working = false;
            foodList.transform.GetChild(lessEnergy).transform.parent = defaultList.transform;
            PlayerScript.currentFoodWorkers--;
            PlayerScript.houseWorkers++;
        }
    }
    public void ReturnToHousesReproduction()
    {
        if (reproductionList.transform.childCount > 0)
        {
            int lessEnergy = 0;

            // First human
            reproductionList.transform.GetChild(lessEnergy).GetComponent<CharacterScript>().working = false;
            reproductionList.transform.GetChild(lessEnergy).transform.parent = defaultList.transform;
            PlayerScript.houseWorkers++;
            PlayerScript.reproductionWorkers -= 0.5f;

            // Second human
            if (reproductionList.transform.childCount > 0)
            {
                reproductionList.transform.GetChild(lessEnergy).GetComponent<CharacterScript>().working = false;
                reproductionList.transform.GetChild(lessEnergy).transform.parent = defaultList.transform;
                PlayerScript.reproductionWorkers -= 0.5f;
                PlayerScript.houseWorkers++;
            }
        }
    }
    public void Update()
    {
        if (working)
            currentEnergy -= Time.deltaTime * energyConsumption;
        else if (working == false && currentEnergy < maxEnergy)
            currentEnergy += Time.deltaTime * energyConsumption*2;
        else if (currentEnergy > maxEnergy)
            currentEnergy = maxEnergy;

        if (currentEnergy > 0)
            UIdivinity.transform.localScale = new Vector3(currentEnergy / maxEnergy, 1.0f, 1.0f);
        else
        {
            if (gameObject.GetComponent<CharacterScript>().type == HUMAN_TYPE.FOOD)
                PlayerScript.currentFoodWorkers--;
            else if (gameObject.GetComponent<CharacterScript>().type == HUMAN_TYPE.REPRODUCT)
                PlayerScript.reproductionWorkers -= 0.5f;
            Destroy(gameObject);
        }
    }
}

/*for (int j = 0; j < foodList.transform.childCount; j++)
{
    if (foodList.transform.GetChild(j).GetComponent<CharacterScript>().currentEnergy < foodList.transform.GetChild(lessEnergy).GetComponent<CharacterScript>().currentEnergy)
        lessEnergy = j;
}*/


/*for (int j = 0; j < reproductionList.transform.childCount; j++)
{
if (reproductionList.transform.GetChild(j).GetComponent<CharacterScript>().currentEnergy < reproductionList.transform.GetChild(lessEnergy).GetComponent<CharacterScript>().currentEnergy)
    lessEnergy = j;
}*/
