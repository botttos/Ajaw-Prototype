using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static float divinity = 0.0f;
    public static float food = 0.0f;
    public static int currentWeek = 0;
    public static int currentMonth = 0;

    public static int foodPerCycle = 0;
    public static int reproductionPerCycle = 0;

    void Start()
    {
        divinity = 150;
        food = 50;
        currentWeek = 0;
        currentMonth = 0;
        foodPerCycle = 12;
        reproductionPerCycle = 15;
    }

    void Update()
    {

    }
}
