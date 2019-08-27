using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycleScript : MonoBehaviour
{
    [Header("Variables de semana")]
    public float dayTime = 0.0f;
    [Header("Estadísticas")]
    
    public float foodConsumed = 0.0f;
    [Header("Datos por día")]
    public Day[] days;

    // private
    private float currentTime = 0.0f;

    [System.Serializable]
    public class Day
    {
        public int maxDivinity;
        public int divinityConsumption;
    }
    void Start()
    {
        //days = new Day[18];
        currentTime = 0.0f;
        // Day cycle
        StartCoroutine(StartDayCicle());
        // Food cycle
        StartCoroutine(StartFoodCycle());
        // Reproduction cycle
        StartCoroutine(StartReproductionCycle());
    }

    IEnumerator StartDayCicle()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= dayTime)
        {
            PlayerScript.food -= foodConsumed;
            PlayerScript.divinity -= days[PlayerScript.currentMonth].divinityConsumption;

            if (PlayerScript.food <= 0)
            {
                // kill all the people
            }
            else if (PlayerScript.divinity <= 0)
            {
                // lose game
            }

            if (PlayerScript.currentWeek % 5 == 0)
            {
                PlayerScript.currentMonth++;
                PlayerScript.divinity = 150;
            }
            currentTime = 0.0f;
            Debug.Log("WEEK END");
            PlayerScript.currentWeek++;
            StartCoroutine(StartDayCicle());
            yield return null;
        }
    }

    IEnumerator StartFoodCycle()
    {
        yield return new WaitForSeconds(PlayerScript.foodPerCycle);
        PlayerScript.food += PlayerScript.foodPerCycle;
        Debug.Log("MORE FOOD");
        StartCoroutine(StartFoodCycle());
    }
    IEnumerator StartReproductionCycle()
    {
        yield return new WaitForSeconds(PlayerScript.reproductionPerCycle);
        // TODO: añadir más población
        Debug.Log("MORE POPULATION");
        StartCoroutine(StartReproductionCycle());
    }
    void Update()
    {

    }
}
