﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EdificationScript : MonoBehaviour
{
    public enum BUILDING_TYPE
    {
        HOUSE = 0,
        REPRODUCTION,
        FOOD,
        L_DOOR,
        R_DOOR,
        CHAMAN,
        SACERDOTE,
        MERCADER
    }
    [Header("Coste y accion por nivel")]
    public Building[] building;
    public int currentCapacity = 0;
    public BUILDING_TYPE buildType = 0;
    public CharacterScript characterEnergy;
    [Header("UI")]
    public GameObject purchaseWindow;
    public GameObject upgradeButtons;
    public TextMeshProUGUI UIbefore;
    public TextMeshProUGUI UIafter;
    public TextMeshProUGUI UIcost;
    [Header("Sound")]
    public GameObject soundManager;

    [System.Serializable]
    public class Building
    {
        public float cost;
        public int capacity;
    }
    public void Start()
    {
        if (buildType == BUILDING_TYPE.REPRODUCTION)
            PlayerScript.reproductionBuildingArrayTarget = building;
    }
    public void PurchaseWindow()
    {
        PlayerScript.buildingTarget = buildType;
        PlayerScript.buildingArrayTarget = building;
        UpdatePurchaseUI();
        purchaseWindow.SetActive(true);
        upgradeButtons.SetActive(false);
        Time.timeScale = 0;
    }
    public void BackToGame()
    {
        purchaseWindow.SetActive(false);
        upgradeButtons.SetActive(true);
        Time.timeScale = 1;
    }
    public void UpgradeBuilding()
    {
        bool purchaseSuccess = false;
        switch (PlayerScript.buildingTarget)
        {
            case BUILDING_TYPE.HOUSE:
                if (PlayerScript.housesLevel < 5)
                {
                    if (PlayerScript.currentDivinity >= PlayerScript.buildingArrayTarget[PlayerScript.housesLevel + 1].cost)
                    {
                        PlayerScript.currentDivinity -= PlayerScript.buildingArrayTarget[PlayerScript.housesLevel + 1].cost;
                        PlayerScript.housesCapacity = PlayerScript.buildingArrayTarget[PlayerScript.housesLevel + 1].capacity;
                        if (ObjectScript.plumaKukulkan)
                            PlayerScript.housesCapacity += 5;
                        PlayerScript.housesLevel++;
                        purchaseSuccess = true;
                    }
                }
                break;
            case BUILDING_TYPE.REPRODUCTION:
                if (PlayerScript.reproductionHouseLevel < 5)
                {
                    if (PlayerScript.currentDivinity >= PlayerScript.buildingArrayTarget[PlayerScript.reproductionHouseLevel + 1].cost)
                    {
                        PlayerScript.currentDivinity -= PlayerScript.buildingArrayTarget[PlayerScript.reproductionHouseLevel + 1].cost;
                        PlayerScript.reproductionHouseCapacity = PlayerScript.buildingArrayTarget[PlayerScript.reproductionHouseLevel + 1].capacity;
                        PlayerScript.reproductionHouseLevel++;
                        purchaseSuccess = true;
                    }
                }
                break;
            case BUILDING_TYPE.FOOD:
                if (PlayerScript.foodBuildingLevel < 5)
                {
                    if (PlayerScript.currentDivinity >= PlayerScript.buildingArrayTarget[PlayerScript.foodBuildingLevel + 1].cost)
                    {
                        PlayerScript.currentDivinity -= PlayerScript.buildingArrayTarget[PlayerScript.foodBuildingLevel + 1].cost;
                        PlayerScript.foodMax = PlayerScript.buildingArrayTarget[PlayerScript.foodBuildingLevel + 1].capacity;
                        PlayerScript.foodBuildingLevel++;
                        PlayerScript.foodBuildingCapacity = PlayerScript.reproductionBuildingArrayTarget[PlayerScript.foodBuildingLevel].capacity;
                        purchaseSuccess = true;
                    }
                }
                break;
            case BUILDING_TYPE.L_DOOR:
                if (PlayerScript.leftDoorLevel < 5)
                {
                    if (PlayerScript.currentDivinity >= PlayerScript.buildingArrayTarget[PlayerScript.leftDoorLevel + 1].cost)
                    {
                        PlayerScript.currentDivinity -= PlayerScript.buildingArrayTarget[PlayerScript.leftDoorLevel + 1].cost;
                        PlayerScript.leftDoorLevel++;
                        purchaseSuccess = true;
                    }
                }
                break;
            case BUILDING_TYPE.R_DOOR:
                if (PlayerScript.rightDoorLevel < 5)
                {
                    if (PlayerScript.currentDivinity >= PlayerScript.buildingArrayTarget[PlayerScript.rightDoorLevel + 1].cost)
                    {
                        PlayerScript.currentDivinity -= PlayerScript.buildingArrayTarget[PlayerScript.rightDoorLevel + 1].cost;
                        PlayerScript.rightDoorLevel++;
                        purchaseSuccess = true;
                    }
                }
                break;
            case BUILDING_TYPE.CHAMAN: // TODO QUE CUESTE SACRIFICIO HUMANO
                if (PlayerScript.chamanLevel < 5)
                {
                    if (PlayerScript.currentDivinity >= PlayerScript.buildingArrayTarget[PlayerScript.chamanLevel + 1].cost)
                    {
                        PlayerScript.currentDivinity -= PlayerScript.buildingArrayTarget[PlayerScript.chamanLevel + 1].cost;
                        PlayerScript.armyPower = PlayerScript.buildingArrayTarget[PlayerScript.chamanLevel + 1].capacity;
                        characterEnergy.maxEnergy += 1.0f;
                        PlayerScript.chamanLevel++;
                        purchaseSuccess = true;
                    }
                }
                break;
            case BUILDING_TYPE.SACERDOTE:
                if (PlayerScript.sacerdoteLevel < 5)
                {
                    if (PlayerScript.currentDivinity >= PlayerScript.buildingArrayTarget[PlayerScript.sacerdoteLevel + 1].cost)
                    {
                        PlayerScript.currentDivinity -= PlayerScript.buildingArrayTarget[PlayerScript.sacerdoteLevel + 1].cost;
                        PlayerScript.passiveDivinity = PlayerScript.buildingArrayTarget[PlayerScript.sacerdoteLevel + 1].capacity;
                        PlayerScript.sacerdoteLevel++;
                        purchaseSuccess = true;
                    }
                }
                break;
            case BUILDING_TYPE.MERCADER: // TODO QUE CUESTE SACRIFICIO HUMANO
                if (PlayerScript.mercaderLevel < 5)
                {
                    if (PlayerScript.currentFood >= PlayerScript.buildingArrayTarget[PlayerScript.mercaderLevel + 1].cost)
                    {
                        PlayerScript.currentFood -= PlayerScript.buildingArrayTarget[PlayerScript.mercaderLevel + 1].cost;
                        PlayerScript.chanceObject = PlayerScript.buildingArrayTarget[PlayerScript.mercaderLevel + 1].capacity;
                        PlayerScript.mercaderLevel++;
                        purchaseSuccess = true;
                    }
                }
                break;
        }
        UpdateCapacity(buildType);

        if (purchaseSuccess)
        {
            soundManager.GetComponent<SoundManager>().PlayUpgradeFX();
            BackToGame();
        }
        return;
    }
    private void UpdateCapacity(BUILDING_TYPE build)
    {
        switch (build)
        {
            case BUILDING_TYPE.HOUSE:
                currentCapacity = building[PlayerScript.housesLevel].capacity;
                break;
            case BUILDING_TYPE.REPRODUCTION:
                currentCapacity = building[PlayerScript.reproductionHouseLevel].capacity;
                break;
            case BUILDING_TYPE.FOOD:
                currentCapacity = building[PlayerScript.foodBuildingLevel].capacity;
                break;
            case BUILDING_TYPE.L_DOOR:
                currentCapacity = building[PlayerScript.leftDoorLevel].capacity;
                break;
            case BUILDING_TYPE.R_DOOR:
                currentCapacity = building[PlayerScript.rightDoorLevel].capacity;
                break;
            case BUILDING_TYPE.CHAMAN: // TODO QUE CUESTE SACRIFICIO HUMANO
                currentCapacity = building[PlayerScript.chamanLevel].capacity;
                break;
            case BUILDING_TYPE.SACERDOTE:
                currentCapacity = building[PlayerScript.sacerdoteLevel].capacity;
                break;
            case BUILDING_TYPE.MERCADER:
                currentCapacity = building[PlayerScript.mercaderLevel].capacity;
                break;
        }
        return;
    }
    private void UpdatePurchaseUI()
    {
        switch (buildType)
        {
            case BUILDING_TYPE.HOUSE:
                if (PlayerScript.housesLevel < 5)
                {
                    if (ObjectScript.plumaKukulkan)
                    {
                        UIbefore.SetText("Capacidad: " + (currentCapacity + 5));
                        UIafter.SetText("Capacidad: " + (building[PlayerScript.housesLevel + 1].capacity + 5));
                    }
                    else
                    {
                        UIbefore.SetText("Capacidad: " + currentCapacity);
                        UIafter.SetText("Capacidad: " + building[PlayerScript.housesLevel + 1].capacity);
                    }
                    UIcost.SetText("Divinidad:\n" + building[PlayerScript.housesLevel + 1].cost);
                }
                else
                {
                    UIbefore.SetText("MEJORAS COMPLETAS");
                    UIafter.SetText("MEJORAS COMPLETAS");
                    UIcost.SetText("0");
                }
                break;
            case BUILDING_TYPE.REPRODUCTION:
                if (PlayerScript.reproductionHouseLevel < 5)
                {
                    UIbefore.SetText("Capacidad: " + currentCapacity);
                    UIafter.SetText("Capacidad: " + building[PlayerScript.reproductionHouseLevel + 1].capacity);
                    UIcost.SetText("Divinidad:\n" + building[PlayerScript.reproductionHouseLevel + 1].cost);
                }
                else
                {
                    UIbefore.SetText("MEJORAS COMPLETAS");
                    UIafter.SetText("MEJORAS COMPLETAS");
                    UIcost.SetText("0");
                }
                break;
            case BUILDING_TYPE.FOOD:
                if (PlayerScript.foodBuildingLevel < 5)
                {
                    UIbefore.SetText("Comida max: " + currentCapacity);
                    UIafter.SetText("Comida max: " + building[PlayerScript.foodBuildingLevel + 1].capacity + " + Aumento de capacidad");
                    UIcost.SetText("Divinidad:\n" + building[PlayerScript.foodBuildingLevel + 1].cost);
                }
                else
                {
                    UIbefore.SetText("MEJORAS COMPLETAS");
                    UIafter.SetText("MEJORAS COMPLETAS");
                    UIcost.SetText("0");
                }
                break;
            case BUILDING_TYPE.L_DOOR:
                if (PlayerScript.leftDoorLevel < 5)
                {
                    UIbefore.SetText("Resistencia: " + currentCapacity);
                    UIafter.SetText("Resistencia: " + building[PlayerScript.leftDoorLevel + 1].capacity);
                    UIcost.SetText("Divinidad:\n" + building[PlayerScript.leftDoorLevel + 1].cost);
                }
                else
                {
                    UIbefore.SetText("MEJORAS COMPLETAS");
                    UIafter.SetText("MEJORAS COMPLETAS");
                    UIcost.SetText("0");
                }
                break;
            case BUILDING_TYPE.R_DOOR:
                if (PlayerScript.rightDoorLevel < 5)
                {
                    UIbefore.SetText("Resistencia: " + currentCapacity);
                    UIafter.SetText("Resistencia: " + building[PlayerScript.rightDoorLevel + 1].capacity);
                    UIcost.SetText("Divinidad:\n" + building[PlayerScript.rightDoorLevel + 1].cost);
                }
                else
                {
                    UIbefore.SetText("MEJORAS COMPLETAS");
                    UIafter.SetText("MEJORAS COMPLETAS");
                    UIcost.SetText("0");
                }
                break;
            case BUILDING_TYPE.CHAMAN: // TODO QUE CUESTE SACRIFICIO HUMANO
                if (PlayerScript.chamanLevel < 5)
                {
                    UIbefore.SetText("Fuerza del ejército: " + currentCapacity);
                    UIafter.SetText("Fuerza del ejército: " + building[PlayerScript.chamanLevel + 1].capacity + " + Aumento de resistencia");
                    UIcost.SetText("Humanos:\n" + building[PlayerScript.chamanLevel + 1].cost);
                }
                else
                {
                    UIbefore.SetText("MEJORAS COMPLETAS");
                    UIafter.SetText("MEJORAS COMPLETAS");
                    UIcost.SetText("0");
                }
                break;
            case BUILDING_TYPE.SACERDOTE:
                if (PlayerScript.sacerdoteLevel < 5)
                {
                    UIbefore.SetText("Divinidad pasiva: " + currentCapacity);
                    UIafter.SetText("Divinidad pasiva: " + building[PlayerScript.sacerdoteLevel + 1].capacity);
                    UIcost.SetText("Divinidad:\n" + building[PlayerScript.sacerdoteLevel + 1].cost);
                }
                else
                {
                    UIbefore.SetText("MEJORAS COMPLETAS");
                    UIafter.SetText("MEJORAS COMPLETAS");
                    UIcost.SetText("0");
                }
                break;
            case BUILDING_TYPE.MERCADER:
                if (PlayerScript.mercaderLevel < 5)
                {
                    UIbefore.SetText("Frecuencia de objetos");
                    UIafter.SetText("Aumentar frecuencia");
                    UIcost.SetText("Alimentos:\n" + building[PlayerScript.mercaderLevel + 1].cost);
                }
                else
                {
                    UIbefore.SetText("MEJORAS COMPLETAS");
                    UIafter.SetText("MEJORAS COMPLETAS");
                    UIcost.SetText("0");
                }
                break;
        }
        return;
    }
    public int GetBuildingCapacity()
    {
        return currentCapacity;
    }
}
