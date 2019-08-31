using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventScript : MonoBehaviour
{
    [Header("Lista de eventos")]
    public Events[] events;
    [Header("UI")]
    public GameObject eventMenu;
    public GameObject upgradeUI;
    
    public TextMeshProUGUI UIdescription;
    public TextMeshProUGUI UIoption1;
    public TextMeshProUGUI UIoption2;

    public static bool event1;
    public static bool event2;
    public static bool event3;
    public static bool event4;
    public static bool event5;
    public static bool event6;
    public static bool event7;

    private OPTION option = OPTION.NONE;
    private int currentEvent = 0;

    public enum OPTION
    {
        NONE,
        UP,
        DOWN
    }
    public enum EVENT_TYPE
    {
        EVENT1 = 1,
        EVENT2,
        EVENT3,
        EVENT4,
        EVENT5,
        EVENT6,
        EVENT7,
        EVENT8,
        EVENT9,
        EVENT10,
        EVENT11,
        EVENT12,
        EVENT13,
        EVENT14,
        EVENT15,
        EVENT16,
        EVENT17,
        EVENT18,
    }
    [System.Serializable]
    public class Events
    {
        public EVENT_TYPE eventType;
        [TextArea(3, 10)]
        public string message;
        [TextArea(3, 10)]
        public string option1;
        [TextArea(3, 10)]
        public string option2;
        public bool alreadyTook = false;
    }
    public void Update()
    {
        if (DayCycleScript.newEvent)
        {
            DayCycleScript.newEvent = false;
            PopUpEventMenu(CreateNewEvent());
        }
        if(option != OPTION.NONE)
        {
            ExecuteEvent();
            option = OPTION.NONE;
        }
    }
    public void PopUpEventMenu(int item)
    {
        Time.timeScale = 0;
        upgradeUI.SetActive(false);
        eventMenu.SetActive(true);
        UIdescription.SetText(events[item].message);
        UIoption1.SetText(events[item].option1);
        UIoption2.SetText(events[item].option2);
    }
    public void BackToGame()
    {
        upgradeUI.SetActive(true);
        Time.timeScale = 1;
        eventMenu.SetActive(false);
    }
    public int CreateNewEvent()
    {
        int randomEvent = 0;
        do
        {
            randomEvent = Random.Range(0, events.Length);
        }
        while (events[randomEvent].alreadyTook);
        currentEvent = randomEvent;

        return randomEvent;
    }
    public void ExecuteEvent()
    {
        switch (currentEvent)
        {
            case 0:
                if (option == OPTION.UP)
                {

                }
                else if(option == OPTION.DOWN)
                {

                }
                    break;
            case 1:
                if (option == OPTION.UP)
                {

                }
                else if (option == OPTION.DOWN)
                {

                }
                break;
            case 2:
                if (option == OPTION.UP)
                {

                }
                else if (option == OPTION.DOWN)
                {

                }
                break;
            case 3:
                if (option == OPTION.UP)
                {

                }
                else if (option == OPTION.DOWN)
                {

                }
                break;
            case 4:
                if (option == OPTION.UP)
                {

                }
                else if (option == OPTION.DOWN)
                {

                }
                break;
            case 5:
                if (option == OPTION.UP)
                {

                }
                else if (option == OPTION.DOWN)
                {

                }
                break;
            case 6:
                if (option == OPTION.UP)
                {

                }
                else if (option == OPTION.DOWN)
                {

                }
                break;
            case 7:
                if (option == OPTION.UP)
                {

                }
                else if (option == OPTION.DOWN)
                {

                }
                break;
            case 8:
                if (option == OPTION.UP)
                {

                }
                else if (option == OPTION.DOWN)
                {

                }
                break;
            case 9:
                if (option == OPTION.UP)
                {

                }
                else if (option == OPTION.DOWN)
                {

                }
                break;
            case 10:
                if (option == OPTION.UP)
                {

                }
                else if (option == OPTION.DOWN)
                {

                }
                break;
            case 11:
                if (option == OPTION.UP)
                {

                }
                else if (option == OPTION.DOWN)
                {

                }
                break;
            case 12:
                if (option == OPTION.UP)
                {

                }
                else if (option == OPTION.DOWN)
                {

                }
                break;
            case 13:
                if (option == OPTION.UP)
                {

                }
                else if (option == OPTION.DOWN)
                {

                }
                break;
            case 14:
                if (option == OPTION.UP)
                {

                }
                else if (option == OPTION.DOWN)
                {

                }
                break;
            case 15:
                if (option == OPTION.UP)
                {

                }
                else if (option == OPTION.DOWN)
                {

                }
                break;
            case 16:
                if (option == OPTION.UP)
                {

                }
                else if (option == OPTION.DOWN)
                {

                }
                break;
            case 17:
                if (option == OPTION.UP)
                {

                }
                else if (option == OPTION.DOWN)
                {

                }
                break;
        }
    }
}
