﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGameButton()
    {
        Application.LoadLevel("SampleScene");
    }
    public void QuitGameButton()
    {
        Application.Quit();
    }    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
