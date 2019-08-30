using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObjectToList : MonoBehaviour
{
    int i = 0;
    public GameObject itemTemplate;
    public static GameObject itemTemplateStatic;
    public GameObject content;
    public static GameObject contentStatic;
    public int humansStart = 0;
    public void Start()
    {
        itemTemplateStatic = itemTemplate;
        contentStatic = content;
        while (humansStart != 0)
        {
            AddButtonClick();
            humansStart--;
        }
    }
    public void AddButtonClick()
    {
        var copy = Instantiate(itemTemplate);
        copy.transform.parent = content.transform;
        PlayerScript.houseWorkers++;
    }
    public static void AddPopulation()
    {
        if (PlayerScript.housesCapacity > (PlayerScript.houseWorkers + PlayerScript.currentFoodWorkers + PlayerScript.reproductionWorkers))
        {
            var copy = Instantiate(itemTemplateStatic);
            copy.transform.parent = contentStatic.transform;
            PlayerScript.houseWorkers++;
        }
    }
}
