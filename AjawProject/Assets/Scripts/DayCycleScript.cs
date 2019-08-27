using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayCycleScript : MonoBehaviour
{
    [Header("Variables de semana")]
    public float dayTime = 0.0f;
    [Header("Estadísticas")]
    public float foodConsumed = 0.0f;
    [Header("Datos por día")]
    public Day[] days;
    [Header("UI")]
    public TextMeshProUGUI UItime;
    public GameObject UIdivinity;

    // private
    private float currentTime = 0.0f;
    private float currentTimeUI = 0.0f;

    [System.Serializable]
    public class Day
    {
        public int maxDivinity;
        public int divinityConsumption;
    }
    void Start()
    {
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
        yield return new WaitForSeconds(dayTime);
        PlayerScript.currentWeek++;
        PlayerScript.currentFood -= foodConsumed;
        PlayerScript.currentDivinity -= days[PlayerScript.currentMonth].divinityConsumption;

        if (PlayerScript.currentFood <= 0)
        {
            // kill all the people
        }
        else if (PlayerScript.currentDivinity <= 0)
        {
            // lose game
        }

        // Si es multiplo de 5, sumamos un mes
        if (PlayerScript.currentWeek % 5 == 0)
        {
            PlayerScript.currentMonth++;
            PlayerScript.currentDivinity = days[PlayerScript.currentMonth].divinityConsumption;
        }
        currentTime = 0.0f;
        Debug.Log("WEEK END");
        StartCoroutine(StartDayCicle());
        yield return null;
    }

    IEnumerator StartFoodCycle()
    {
        yield return new WaitForSeconds(PlayerScript.foodTimeCycle);
        // TODO: setear limitacion de comida
        PlayerScript.currentFood += PlayerScript.foodTimeCycle;
        Debug.Log("MORE FOOD");
        StartCoroutine(StartFoodCycle());
    }
    IEnumerator StartReproductionCycle()
    {
        yield return new WaitForSeconds(PlayerScript.reproductionTimeCycle);
        // TODO: añadir más población
        Debug.Log("MORE POPULATION");
        StartCoroutine(StartReproductionCycle());
    }

    public Day GetCurrentDay()
    {
        return days[PlayerScript.currentMonth];
    }
    void Update()
    {
        currentTimeUI += Time.deltaTime;
        if (currentTimeUI >= dayTime)
            currentTimeUI = 0.0f;
        UItime.SetText("" + ((int)currentTimeUI + 1));

        UIdivinity.transform.localScale = new Vector3(PlayerScript.currentDivinity / GetCurrentDay().maxDivinity, 1.0f, 1.0f);
    }
}
