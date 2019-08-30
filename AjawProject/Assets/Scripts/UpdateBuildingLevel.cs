using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateBuildingLevel : MonoBehaviour
{
    public EdificationScript.BUILDING_TYPE buiildingType;
    public Text UIlevel;

    void Update()
    {
        switch (buiildingType)
        {
            case EdificationScript.BUILDING_TYPE.HOUSE:
                UIlevel.text = ("+" + (PlayerScript.housesLevel + 1));
                break;
            case EdificationScript.BUILDING_TYPE.REPRODUCTION:
                UIlevel.text = ("+" + (PlayerScript.reproductionHouseLevel + 1));
                break;
            case EdificationScript.BUILDING_TYPE.FOOD:
                UIlevel.text = ("+" + (PlayerScript.foodBuildingLevel + 1));
                break;
            case EdificationScript.BUILDING_TYPE.L_DOOR:
                UIlevel.text = ("+" + (PlayerScript.leftDoorLevel + 1));
                break;
            case EdificationScript.BUILDING_TYPE.R_DOOR:
                UIlevel.text = ("+" + (PlayerScript.rightDoorLevel + 1));
                break;
            case EdificationScript.BUILDING_TYPE.CHAMAN:
                UIlevel.text = ("+" + (PlayerScript.chamanLevel + 1));
                break;
            case EdificationScript.BUILDING_TYPE.SACERDOTE:
                UIlevel.text = ("+" + (PlayerScript.sacerdoteLevel + 1));
                break;
            case EdificationScript.BUILDING_TYPE.MERCADER:
                UIlevel.text = ("+" + (PlayerScript.mercaderLevel + 1));
                break;
        }
        return;
    }
}
