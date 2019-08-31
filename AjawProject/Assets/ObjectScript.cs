using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    [Header("Lista de objetos")]
    public Object[] objects;

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

    public void GetNewItem()
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
                figuraJade = true;
                break;
            case OBJECT_TYPE.MASCARA_PAKAL_GRANDE:
                mascaraPakalGrande = true;
                break;
            case OBJECT_TYPE.PAPEL:
                papel = true;
                break;
            case OBJECT_TYPE.PLUMA:
                pluma = true;
                break;
            case OBJECT_TYPE.PLUMA_KUKULKAN:
                plumaKukulkan = true;
                break;
        }
    }
}
