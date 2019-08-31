using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ObjectScript : MonoBehaviour
{
    [Header("Lista de objetos")]
    public Object[] objects;
    public static Object[] objectsStatic;
    [Header("UI")]
    public GameObject newItemMenu;
    public GameObject upgradeUI;
    public TextMeshProUGUI UIname;
    public TextMeshProUGUI UIdescription;

    public static bool espinaMantarraya;
    public static bool figuraChaac;
    public static bool plumaKukulkan;
    public static bool mascaraPakalGrande;
    public static bool figuraJade;
    public static bool pluma;
    public static bool papel;

    public enum OBJECT_TYPE
    {
        ESPINA_MANTARRAYA,
        FIGURA_CHAAC,
        PLUMA_KUKULKAN,
        MASCARA_PAKAL_GRANDE,
        FIGURA_JADE,
        PLUMA,
        PAPEL
    }
    [System.Serializable]
    public class Object
    {
        public OBJECT_TYPE objectType;
        public string name;
        [TextArea(3, 10)]
        public string message;
        public bool alreadyTook = false;
    }

    public void Update()
    {
        if(DayCycleScript.addNewItem)
        {
            DayCycleScript.addNewItem = false;
            PopUpItemMenu(GetNewItem());
        }
    }
    public void PopUpItemMenu(int item)
    {
        Time.timeScale = 0;
        upgradeUI.SetActive(false);
        newItemMenu.SetActive(true);
        UIname.SetText(objects[item].name);
        UIdescription.SetText(objects[item].message);
    }
    public void BackToGame()
    {
        upgradeUI.SetActive(true);
        Time.timeScale = 1;
        newItemMenu.SetActive(false);
    }
    public int GetNewItem()
    {
        int randomItem = 0;
        do
        {
            randomItem = Random.Range(0, objects.Length);
        }
        while (objects[randomItem].alreadyTook);

        switch (objects[randomItem].objectType)
        {
            case OBJECT_TYPE.ESPINA_MANTARRAYA:
                espinaMantarraya = true;
                break;
            case OBJECT_TYPE.FIGURA_CHAAC:
                figuraChaac = true;
                break;
            case OBJECT_TYPE.FIGURA_JADE:
                PlayerScript.currentDivinity = PlayerScript.maxDivinity;
                figuraJade = true;
                break;
            case OBJECT_TYPE.MASCARA_PAKAL_GRANDE:
                mascaraPakalGrande = true;
                break;
            case OBJECT_TYPE.PAPEL:
                if (PlayerScript.currentDivinity * 1.2 <= PlayerScript.maxDivinity)
                    PlayerScript.currentDivinity *= 1.2f;
                else
                    PlayerScript.currentDivinity = PlayerScript.maxDivinity;
                papel = true;
                break;
            case OBJECT_TYPE.PLUMA:
                if (PlayerScript.currentDivinity * 1.4 <= PlayerScript.maxDivinity)
                    PlayerScript.currentDivinity *= 1.4f;
                else
                    PlayerScript.currentDivinity = PlayerScript.maxDivinity;
                pluma = true;
                break;
            case OBJECT_TYPE.PLUMA_KUKULKAN:
                PlayerScript.housesCapacity += 5;
                plumaKukulkan = true;
                break;
        }
        return randomItem;
    }
}
