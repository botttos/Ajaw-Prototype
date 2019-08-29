using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public TextMeshProUGUI UIdivinityCurrentMax;
    public GameObject UIdivinity;
    public GameObject UIdivinityConsumption;
    public GameObject UIborder;

    // private
    private float currentTimeUI = 20.0f;

    [System.Serializable]
    public class Day
    {
        public float maxDivinity;
        public float divinityConsumption;
    }
    void Start()
    {
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

        PlayerScript.currentWeek++;
        // Si es multiplo de 5, sumamos un mes
        if (PlayerScript.currentWeek % 5 == 0)
        {
            PlayerScript.currentMonth++;
            PlayerScript.currentDivinity = days[PlayerScript.currentMonth].maxDivinity;
        }
        Debug.Log("WEEK END");
        StartCoroutine(StartDayCicle());
        yield return null;
    }

    IEnumerator StartFoodCycle()
    {
        yield return new WaitForSeconds(PlayerScript.foodTimeCycle);

        if ((PlayerScript.currentFood + PlayerScript.foodTimeCycle) <= PlayerScript.foodMax)
            PlayerScript.currentFood += PlayerScript.foodTimeCycle;
        else
            PlayerScript.currentFood += PlayerScript.foodMax;
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
    IEnumerator StartPassiveDivinity()
    {
        yield return new WaitForSeconds(PlayerScript.divinityTimeCycle);
        if ((PlayerScript.currentDivinity + PlayerScript.passiveDivinity) <= GetCurrentDay().maxDivinity)
            PlayerScript.currentDivinity += PlayerScript.passiveDivinity;
        else
            PlayerScript.currentDivinity = GetCurrentDay().maxDivinity;
        StartCoroutine(StartPassiveDivinity());
    }

    public Day GetCurrentDay()
    {
        return days[PlayerScript.currentMonth];
    }
    void Update()
    {
        // Time timer
        currentTimeUI -= Time.deltaTime;
        if (currentTimeUI <= 0)
            currentTimeUI = 20.0f;
        UItime.SetText("" + ((int)currentTimeUI+1));
        UIdivinityCurrentMax.SetText("" + PlayerScript.currentDivinity + "/" + GetCurrentDay().maxDivinity);
        // Divinity bar filler
        float UIDivinityData = (PlayerScript.currentDivinity / GetCurrentDay().maxDivinity) - (GetCurrentDay().divinityConsumption / GetCurrentDay().maxDivinity);
        if (UIDivinityData >= 0)
            UIdivinity.transform.localScale = new Vector3(UIDivinityData, 1.0f, 1.0f);
        else
            UIdivinity.transform.localScale = new Vector3(0.0f, 1.0f, 1.0f);
        // Empty filler
        if (PlayerScript.currentDivinity > 0)
            UIdivinityConsumption.transform.localScale = new Vector3(PlayerScript.currentDivinity / GetCurrentDay().maxDivinity - 1, 1.0f, 1.0f);
        else
            UIdivinityConsumption.transform.localScale = new Vector3(-1 + (GetCurrentDay().divinityConsumption / GetCurrentDay().maxDivinity), 1.0f, 1.0f);

        if (PlayerScript.currentDivinity >= GetCurrentDay().divinityConsumption)
        {
            UIborder.GetComponent<Image>().color = Color.black;
        }
        else
        {
            UIborder.GetComponent<Image>().color = Color.red;
        }

    }
}
