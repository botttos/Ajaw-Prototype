﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObjectToList : MonoBehaviour
{
    int i = 0;
    public GameObject itemTemplate;
    public GameObject content;

    public void AddButtonClick()
    {
        var copy = Instantiate(itemTemplate);
        copy.transform.parent = content.transform;

    }
}
