using System.Collections;
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
    public BUILDING_TYPE build = 0;
    [Header("UI")]
    public GameObject purchaseWindow;
    public TextMeshProUGUI UIbefore;
    public TextMeshProUGUI UIafter;
    public TextMeshProUGUI UIcost;

    [System.Serializable]
    public class Building
    {
        public float cost;
        public int capacity;
    }

    public void PurchaseWindow()
    {
        UpdatePurchaseUI();
        purchaseWindow.SetActive(true);
        Time.timeScale = 0;
    }
    public void BackToGame()
    {
        purchaseWindow.SetActive(false);
        Time.timeScale = 1;
    }
    public void UpgradeBuilding()
    {
        bool purchaseSuccess = false;
        switch (build)
        {
            case BUILDING_TYPE.HOUSE:
                if (PlayerScript.housesLevel < 5)
                {
                    if (PlayerScript.currentDivinity >= building[PlayerScript.housesLevel + 1].cost)
                    {
                        PlayerScript.currentDivinity -= building[PlayerScript.housesLevel + 1].cost;
                        PlayerScript.housesLevel++;
                        purchaseSuccess = true;
                    }
                }
                break;
            case BUILDING_TYPE.REPRODUCTION:
                if (PlayerScript.reproductionLevel < 5)
                {
                    if (PlayerScript.currentDivinity >= building[PlayerScript.reproductionLevel + 1].cost)
                    {
                        PlayerScript.currentDivinity -= building[PlayerScript.reproductionLevel + 1].cost;
                        PlayerScript.reproductionLevel++;
                        purchaseSuccess = true;
                    }
                }
                break;
            case BUILDING_TYPE.FOOD:
                if (PlayerScript.foodLevel < 5)
                {
                    if (PlayerScript.currentDivinity >= building[PlayerScript.foodLevel + 1].cost)
                    {
                        PlayerScript.currentDivinity -= building[PlayerScript.foodLevel + 1].cost;
                        PlayerScript.foodLevel++;
                        purchaseSuccess = true;
                    }
                }
                break;
            case BUILDING_TYPE.L_DOOR:
                if (PlayerScript.leftDoorLevel < 5)
                {
                    if (PlayerScript.currentDivinity >= building[PlayerScript.leftDoorLevel + 1].cost)
                    {
                        PlayerScript.currentDivinity -= building[PlayerScript.leftDoorLevel + 1].cost;
                        PlayerScript.leftDoorLevel++;
                        purchaseSuccess = true;
                    }
                }
                break;
            case BUILDING_TYPE.R_DOOR:
                if (PlayerScript.rightDoorLevel < 5)
                {
                    if (PlayerScript.currentDivinity >= building[PlayerScript.rightDoorLevel + 1].cost)
                    {
                        PlayerScript.currentDivinity -= building[PlayerScript.rightDoorLevel + 1].cost;
                        PlayerScript.rightDoorLevel++;
                        purchaseSuccess = true;
                    }
                }
                break;
            case BUILDING_TYPE.CHAMAN: // TODO QUE CUESTE SACRIFICIO HUMANO
                if (PlayerScript.chamanLevel < 5)
                {
                    if (PlayerScript.currentDivinity >= building[PlayerScript.chamanLevel + 1].cost)
                    {
                        PlayerScript.currentDivinity -= building[PlayerScript.chamanLevel + 1].cost;
                        PlayerScript.chamanLevel++;
                        purchaseSuccess = true;
                    }
                }
                break;
            case BUILDING_TYPE.SACERDOTE:
                if (PlayerScript.sacerdoteLevel < 5)
                {
                    if (PlayerScript.currentDivinity >= building[PlayerScript.sacerdoteLevel + 1].cost)
                    {
                        PlayerScript.currentDivinity -= building[PlayerScript.sacerdoteLevel + 1].cost;
                        PlayerScript.sacerdoteLevel++;
                        purchaseSuccess = true;
                    }
                }
                break;
            case BUILDING_TYPE.MERCADER: // TODO QUE CUESTE SACRIFICIO HUMANO
                if (PlayerScript.mercaderLevel < 5)
                {
                    if (PlayerScript.currentFood >= building[PlayerScript.mercaderLevel + 1].cost)
                    {
                        PlayerScript.currentFood -= building[PlayerScript.mercaderLevel + 1].cost;
                        PlayerScript.mercaderLevel++;
                        purchaseSuccess = true;
                    }
                }
                break;
        }
        UpdateCapacity(build);

        if (purchaseSuccess)
            BackToGame();

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
                currentCapacity = building[PlayerScript.reproductionLevel].capacity;
                break;
            case BUILDING_TYPE.FOOD:
                currentCapacity = building[PlayerScript.foodLevel].capacity;
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
        switch (build)
        {
            case BUILDING_TYPE.HOUSE:
                if (PlayerScript.housesLevel < 5)
                {
                    UIbefore.SetText("Capacidad: " + currentCapacity);
                    UIafter.SetText("Capacidad: " + building[PlayerScript.housesLevel + 1].capacity);
                    UIcost.SetText("" + building[PlayerScript.housesLevel + 1].cost);
                }
                else
                {
                    UIbefore.SetText("MEJORAS COMPLETAS");
                    UIafter.SetText("MEJORAS COMPLETAS");
                    UIcost.SetText("0");
                }
                break;
            case BUILDING_TYPE.REPRODUCTION:
                if (PlayerScript.reproductionLevel < 5)
                {
                    UIbefore.SetText("Capacidad: " + currentCapacity);
                    UIafter.SetText("Capacidad: " + building[PlayerScript.reproductionLevel + 1].capacity);
                    UIcost.SetText("" + building[PlayerScript.reproductionLevel + 1].cost);
                }
                else
                {
                    UIbefore.SetText("MEJORAS COMPLETAS");
                    UIafter.SetText("MEJORAS COMPLETAS");
                    UIcost.SetText("0");
                }
                break;
            case BUILDING_TYPE.FOOD:
                if (PlayerScript.foodLevel < 5)
                {
                    UIbefore.SetText("Capacidad: " + currentCapacity);
                    UIafter.SetText("Capacidad: " + building[PlayerScript.foodLevel + 1].capacity);
                    UIcost.SetText("" + building[PlayerScript.foodLevel + 1].cost);
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
                    UIcost.SetText("" + building[PlayerScript.leftDoorLevel + 1].cost);
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
                    UIcost.SetText("" + building[PlayerScript.rightDoorLevel + 1].cost);
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
                    UIafter.SetText("Fuerza del ejército: " + building[PlayerScript.chamanLevel + 1].capacity);
                    UIcost.SetText("" + building[PlayerScript.chamanLevel + 1].cost);
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
                    UIcost.SetText("" + building[PlayerScript.sacerdoteLevel + 1].cost);
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
                    UIbefore.SetText("Frecuencia de objetos.");
                    UIafter.SetText("Objetos más frecuentes" + building[PlayerScript.mercaderLevel + 1].capacity);
                    UIcost.SetText("" + building[PlayerScript.mercaderLevel + 1].cost);
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
