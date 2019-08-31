using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    // Current player stats
    public static float currentDivinity = 150.0f;
    public static float maxDivinity = 150.0f;
    public static float currentFood = 0.0f;
    public static int currentMonth = 0;
    public static int currentWeek = 0;
    // Buildings level
    public static int housesLevel = 0;
    public static int housesCapacity = 15;
    public static int houseWorkers = 0;
    public static int reproductionHouseLevel = 0;
    public static int reproductionHouseCapacity = 4;
    public static float reproductionWorkers = 0;
    public static int foodBuildingLevel = 0;
    public static int foodBuildingCapacity = 4;
    public static int currentFoodWorkers = 0;
    public static int foodMax = 50;
    public static int leftDoorLevel = 0;
    public static int rightDoorLevel = 0;
    public static int chamanLevel = 0;
    public static int armyPower = 0;
    public static int sacerdoteLevel = 0;
    public static int passiveDivinity = 10;
    public static int mercaderLevel = 0;
    public static float chanceObject = 0;

    public static EdificationScript.BUILDING_TYPE buildingTarget;
    public static EdificationScript.Building[] buildingArrayTarget;
    public static EdificationScript.Building[] reproductionBuildingArrayTarget;

    // Cycles
    public static int foodTimeCycle = 0;
    public static int divinityTimeCycle = 0;

    [Header("UI Time")]
    // public TextMeshProUGUI UIfood;
    public TextMeshProUGUI UImonth;
    public TextMeshProUGUI UIweek;
    public TextMeshProUGUI UImaxPopulation;
    public TextMeshProUGUI UImaxFoodWorkers;
    public TextMeshProUGUI UImaxReproductionWorkers;

    void Start()
    {
        currentDivinity = 150;
        currentFood = 0;
        currentWeek = 0;
        currentMonth = 0;
        foodTimeCycle = 12;
        divinityTimeCycle = 8;
        chanceObject = 1;
    }

    void Update()
    {
        //UIfood.SetText("" + currentFood);
        UImonth.SetText("" + (1 + currentMonth));
        UIweek.SetText("" + (1 + currentWeek));
        UImaxPopulation.SetText("" + (currentFoodWorkers + houseWorkers + (reproductionWorkers*2)) + "/" + housesCapacity);
        UImaxReproductionWorkers.SetText("" + (int)reproductionWorkers*2 + "/" + reproductionHouseCapacity);
        UImaxFoodWorkers.SetText("" + currentFoodWorkers + "/" + foodBuildingCapacity);
    }
}
