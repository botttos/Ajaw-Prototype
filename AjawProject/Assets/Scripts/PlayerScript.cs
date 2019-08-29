using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    // Current player stats
    public static float currentDivinity = 0.0f;
    public static float currentFood = 0.0f;
    public static int currentMonth = 0;
    public static int currentWeek = 0;
    // Buildings level
    public static int housesLevel = 0;
    public static int housesMax = 0;
    public static int reproductionLevel = 0;
    public static int reproductionMax = 0;
    public static int foodLevel = 0;
    public static int foodMax = 0;
    public static int leftDoorLevel = 0;
    public static int rightDoorLevel = 0;
    public static int chamanLevel = 0;
    public static int sacerdoteLevel = 0;
    public static int mercaderLevel = 0;
    public static EdificationScript.BUILDING_TYPE buildingTarget;

    // 
    public static int foodTimeCycle = 0;
    public static int reproductionTimeCycle = 0;

    [Header("UI Time")]
   // public TextMeshProUGUI UIfood;
    public TextMeshProUGUI UImonth;
    public TextMeshProUGUI UIweek;

    void Start()
    {
        currentDivinity = 150;
        currentFood = 50;
        currentWeek = 0;
        currentMonth = 0;
        foodTimeCycle = 12;
        reproductionTimeCycle = 15;
    }

    void Update()
    {
        //UIfood.SetText("" + currentFood);
        UImonth.SetText("" + (1 + currentMonth));
        UIweek.SetText("" + (1 + currentWeek));
    }
}
