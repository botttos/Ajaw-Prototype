using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey("escape"))
        {
            Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLScnRJwWchi0Bt-ZUjZQMZBI2i9jzXK8W63REaOmZMunLJhsJg/viewform?usp=sf_link");
            Debug.Log("QUIT GAME");
            Application.Quit();
        }
    }
}
