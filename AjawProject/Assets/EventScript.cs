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

    public GameObject secondTextMenu;
    public TextMeshProUGUI secondTextString;

    public static float event1 = 0;
    public static float event2 = 0;
    public static int event3 = 0;
    public static int event4 = 0;
    public static int event5 = 0;
    public static int event6 = 0;
    public static int event7 = 0;
    public static int event8 = 0;
    public static int event9 = 0;
    public static int event10 = 0;
    public static int event11 = 0;
    public static int event12 = 0;
    public static int event13 = 0;
    public static int event14 = 0;
    public static int event15 = 0;
    public static int event16 = 0;
    public static int event17 = 0;
    public static int event18 = 0;

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
        EVENT1 = 0,
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
        public bool secondText = false;
        [TextArea(3, 10)]
        public string secondTextStringUP;
        [TextArea(3, 10)]
        public string secondTextStringDOWN;
    }
    public void Update()
    {
        if (DayCycleScript.newEvent)
        {
            DayCycleScript.newEvent = false;
            // Get event id
            CreateNewEvent();
            PopUpEventMenu();
        }
        if (option != OPTION.NONE)
        {
            ExecuteEvent();
            option = OPTION.NONE;
        }
    }
    public void PopUpEventMenu()
    {
        Time.timeScale = 0;
        upgradeUI.SetActive(false);
        eventMenu.SetActive(true);
        UIdescription.SetText(events[currentEvent].message);
        UIoption1.SetText(events[currentEvent].option1);
        UIoption2.SetText(events[currentEvent].option2);
    }
    public void OptionButton(string upOrDown)
    {
        if (upOrDown == "up")
        {
            option = OPTION.UP;
        }
        else if (upOrDown == "down")
        {
            option = OPTION.DOWN;
        }
    }
    public void BackToGame()
    {
        upgradeUI.SetActive(true);
        Time.timeScale = 1;
        eventMenu.SetActive(false);
        secondTextMenu.SetActive(false);
    }
    public void ShowSecondMenu()
    {
        eventMenu.SetActive(false);
        secondTextMenu.SetActive(true);
        if (option == OPTION.UP)
            secondTextString.SetText(events[currentEvent].secondTextStringUP);
        else if (option == OPTION.DOWN)
            secondTextString.SetText(events[currentEvent].secondTextStringDOWN);
    }
    public void CreateNewEvent()
    {
        int randomEvent = 0;
        do
        {
            randomEvent = Random.Range(0, events.Length);
        }
        while (events[randomEvent].alreadyTook);
        // Don't show this event again
        events[randomEvent].alreadyTook = true;
        currentEvent = randomEvent;
    }
    public void ExecuteEvent()
    {
        switch (currentEvent)
        {
            case 0:
                if (option == OPTION.UP)
                { }
                else if (option == OPTION.DOWN)
                {
                    event1 = -0.1f;
                }
                break;
            case 1:
                if (option == OPTION.UP)
                {
                    PlayerScript.currentFood = PlayerScript.currentFood / 2;
                    event2 = PlayerScript.maxDivinity * 0.2f;
                }
                else if (option == OPTION.DOWN)
                {
                    PlayerScript.armyPower++;
                }
                break;
            case 2:
                if (option == OPTION.UP)
                {

                }
                else if (option == OPTION.DOWN)
                {
                    if (PlayerScript.currentDivinity >= 40)
                        PlayerScript.currentDivinity -= 40;
                    else
                        PlayerScript.currentDivinity = 0;
                }
                break;
            case 3:
                if (option == OPTION.UP)
                {
                    if (PlayerScript.currentDivinity >= 40)
                        PlayerScript.currentDivinity -= 40;
                    else
                        PlayerScript.currentDivinity = 0;

                    if (PlayerScript.currentFood >= 20)
                        PlayerScript.currentFood -= 20;
                    else
                        PlayerScript.currentFood = 0;
                }
                else if (option == OPTION.DOWN)
                {
                    PlayerScript.armyPower--;
                }
                break;
            case 4:
                if (option == OPTION.UP)
                {
                    if (PlayerScript.currentDivinity >= 40)
                        PlayerScript.currentDivinity -= 40;
                    else
                        PlayerScript.currentDivinity = 0;
                }
                else if (option == OPTION.DOWN)
                {
                    if (PlayerScript.currentDivinity >= 40)
                        PlayerScript.currentDivinity -= 40;
                    else
                        PlayerScript.currentDivinity = 0;
                }
                break;
            case 5:
                if (option == OPTION.UP)
                {
                    if (PlayerScript.currentDivinity + 80 <= PlayerScript.maxDivinity + event1)
                        PlayerScript.currentDivinity += 80;
                    else
                        PlayerScript.currentDivinity = PlayerScript.maxDivinity + event1;
                }
                else if (option == OPTION.DOWN)
                {
                    if (PlayerScript.currentDivinity + 20 <= PlayerScript.maxDivinity + event1)
                        PlayerScript.currentDivinity += 20;
                    else
                        PlayerScript.currentDivinity = PlayerScript.maxDivinity + event1;
                }
                break;
            case 6:
                if (option == OPTION.UP)
                {
                    
                }
                else if (option == OPTION.DOWN)
                {
                    if (PlayerScript.currentDivinity >= 40)
                        PlayerScript.currentDivinity -= 40;
                    else
                        PlayerScript.currentDivinity = 0;
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
                    event8 += 2;
                }
                else if (option == OPTION.DOWN)
                {
                    PlayerScript.currentDivinity = PlayerScript.maxDivinity / 2;
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
                    PlayerScript.currentDivinity -= 20;
                }
                else if (option == OPTION.DOWN)
                {
                    if (PlayerScript.currentFood >= 10)
                        PlayerScript.currentFood -= 10;
                    else
                        PlayerScript.currentFood = 0;
                }
                break;
            case 12:
                if (option == OPTION.UP)
                {
                    PlayerScript.currentFood /= 2;
                }
                else if (option == OPTION.DOWN)
                {

                }
                break;
            case 13:
                if (option == OPTION.UP)
                {
                    event8 += 2;
                }
                else if (option == OPTION.DOWN)
                {

                }
                break;
            case 14:
                if (option == OPTION.UP)
                {
                    if (PlayerScript.currentFood >= 20)
                        PlayerScript.currentFood -= 20;
                    else
                        PlayerScript.currentFood = 0;
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
                    event8 += 1;
                }
                break;
            case 17:
                if (option == OPTION.UP)
                {

                }
                else if (option == OPTION.DOWN)
                {
                    event8 += 1;
                }
                break;
        }
        if (events[currentEvent].secondText)
            ShowSecondMenu();
        else
            BackToGame();
    }
}
