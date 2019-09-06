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
    public float foodConsumedPerHuman = 2.0f;
    public float reproductionTimeCycle = 10;
    public float DEBUGworkers = 0;
    private float reproductionTimer = 0;
    [Header("Datos por día")]
    public Day[] days;
    [Header("UI")]
    public TextMeshProUGUI UItime;
    public TextMeshProUGUI UIdivinityCurrentMax;
    public GameObject UIdivinity;
    public GameObject UIdivinityConsumption;
    public GameObject UIborder;
    public GameObject UIgameOver;
    public GameObject UIupgrades;
    [Header("Population")]
    public GameObject defaultList;
    public GameObject foodList;
    public GameObject reproductionList;
    [Header("Sound")]
    public GameObject soundManager;

    // private
    private float currentTimeUI = 20.0f;
    public static bool addNewItem = false;
    public static bool newEvent = false;

    [System.Serializable]
    public class Day
    {
        public float maxDivinity;
        public float divinityConsumption;
    }

    void Start()
    {
        reproductionTimer = reproductionTimeCycle;
        // Day cycle
        StartCoroutine(StartDayCicle());
        // Food cycle
        StartCoroutine(StartFoodCycle());
        // Reproduction cycle
        //StartCoroutine(StartReproductionCycle());
        // Divinity cycle
        StartCoroutine(StartPassiveDivinity());
    }

    IEnumerator StartDayCicle()
    {
        yield return new WaitForSeconds(dayTime);
        if (PlayerScript.currentFood - foodConsumedPerHuman * (PlayerScript.currentFoodWorkers + PlayerScript.reproductionWorkers + PlayerScript.houseWorkers) > 0)
            PlayerScript.currentFood -= foodConsumedPerHuman * (PlayerScript.currentFoodWorkers + PlayerScript.reproductionWorkers + PlayerScript.houseWorkers);
        else
            PlayerScript.currentFood = 0;

        PlayerScript.currentDivinity -= days[PlayerScript.currentMonth].divinityConsumption;

        // Game Over
        if (PlayerScript.currentDivinity <= 0)
        {
            soundManager.GetComponent<SoundManager>().PlayGameOverFX();
            UIupgrades.SetActive(false);
            Time.timeScale = 0;
            UIgameOver.SetActive(true);
        }
        // Food punishment
        if (PlayerScript.currentFood <= 0)
        {
            if (PlayerScript.currentDivinity - (int)(PlayerScript.currentDivinity / 2) >= 0)
                PlayerScript.currentDivinity = (int)(PlayerScript.currentDivinity / 2);
            else
                PlayerScript.currentDivinity = 0;
        }
        // Add new item
        PlayerScript.currentWeek++;
        if (Random.Range(0, 10) <= PlayerScript.chanceObject && PlayerScript.currentWeek % 5 != 0)
        {
            soundManager.GetComponent<SoundManager>().PlayNewItemFX();
            addNewItem = true;
        }
            
        // Si es multiplo de 5, sumamos un mes
        if (PlayerScript.currentWeek % 5 == 0)
        {
            PlayerScript.currentWeek = 0;
            PlayerScript.currentMonth++;
            PlayerScript.currentDivinity = (days[PlayerScript.currentMonth].maxDivinity + EventScript.event2);
            newEvent = true;
        }
        Debug.Log("WEEK END");
        StartCoroutine(StartDayCicle());
        yield return null;
    }
    IEnumerator StartFoodCycle()
    {
        if (ObjectScript.mascaraPakalGrande)
            yield return new WaitForSeconds(PlayerScript.foodTimeCycle * (0.9f + EventScript.event1));
        else
            yield return new WaitForSeconds(PlayerScript.foodTimeCycle + EventScript.event1);
        if ((PlayerScript.currentFood + PlayerScript.currentFoodWorkers * 2) <= PlayerScript.foodMax)
            PlayerScript.currentFood += PlayerScript.currentFoodWorkers * 2;
        else
            PlayerScript.currentFood = PlayerScript.foodMax;
        Debug.Log("MORE FOOD");
        StartCoroutine(StartFoodCycle());
    }
    IEnumerator StartReproductionCycle()
    {

        /*yield return new WaitForSeconds(reproductionTimeCycle - PlayerScript.reproductionHouseLevel);
        for (int i = 0; i < PlayerScript.reproductionWorkers; i++)*/
        StartCoroutine(StartReproductionCycle());
        yield return null;
    }
    IEnumerator StartPassiveDivinity()
    {
        yield return new WaitForSeconds(PlayerScript.divinityTimeCycle);
        if ((PlayerScript.currentDivinity + PlayerScript.passiveDivinity + EventScript.event8) <= GetCurrentDay().maxDivinity + EventScript.event2)
            PlayerScript.currentDivinity += (PlayerScript.passiveDivinity + EventScript.event8);
        else
            PlayerScript.currentDivinity = (GetCurrentDay().maxDivinity + EventScript.event2);
        StartCoroutine(StartPassiveDivinity());
    }

    public Day GetCurrentDay()
    {
        return days[PlayerScript.currentMonth];
    }
    void Update()
    {
        // REPRODUCTION
        reproductionTimer -= Time.deltaTime;
        DEBUGworkers = PlayerScript.reproductionWorkers;
        if (reproductionTimer - PlayerScript.reproductionWorkers <= 0 && PlayerScript.reproductionWorkers > 0)
        {
            if(PlayerScript.currentFoodWorkers + (PlayerScript.reproductionWorkers*2) + PlayerScript.houseWorkers < PlayerScript.housesCapacity)
                AddObjectToList.AddPopulation();
            reproductionTimer = reproductionTimeCycle;
        }
        else if (reproductionTimer - PlayerScript.reproductionWorkers <= 0)
            reproductionTimer = reproductionTimeCycle;
        // Max divinity update
        PlayerScript.maxDivinity = (GetCurrentDay().maxDivinity + EventScript.event2);
        // Time timer
        currentTimeUI -= Time.deltaTime;
        if (currentTimeUI <= 0)
            currentTimeUI = 20.0f;
        UItime.SetText("" + ((int)currentTimeUI + 1));
        UIdivinityCurrentMax.SetText("" + (int)PlayerScript.currentDivinity + "/" + (GetCurrentDay().maxDivinity + EventScript.event2));
        // Divinity bar filler
        float UIDivinityData = (PlayerScript.currentDivinity / (GetCurrentDay().maxDivinity + EventScript.event2)) - (GetCurrentDay().divinityConsumption / (GetCurrentDay().maxDivinity + EventScript.event2));
        if (UIDivinityData >= 0)
            UIdivinity.transform.localScale = new Vector3(UIDivinityData, 1.0f, 1.0f);
        else
            UIdivinity.transform.localScale = new Vector3(0.0f, 1.0f, 1.0f);
        // Empty filler
        if (PlayerScript.currentDivinity > 0)
            UIdivinityConsumption.transform.localScale = new Vector3(PlayerScript.currentDivinity / (GetCurrentDay().maxDivinity + EventScript.event2) - 1, 1.0f, 1.0f);
        else
            UIdivinityConsumption.transform.localScale = new Vector3(-1 + (GetCurrentDay().divinityConsumption / (GetCurrentDay().maxDivinity + EventScript.event2)), 1.0f, 1.0f);

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
