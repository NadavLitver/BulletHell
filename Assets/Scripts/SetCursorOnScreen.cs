﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursorOnScreen : MonoBehaviour
{
   
    private void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }
}
