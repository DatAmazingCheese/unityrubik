﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAME_RubikInputHandler : MonoBehaviour
{
    public List<GameObject> Centers;
    public GAME_RubikSideTurn TurnHandler;

    List<bool> Inputs = new List<bool>() { false, false, false, false, false, false};

    string GetKey(params KeyCode[] Keys)
    {
        bool pressed = false;
        string KeyPressed = "";

        foreach (var key in Keys)
        {
            if (Input.GetKey(key) & !pressed)
            {
                pressed = true;
                KeyPressed = key.ToString();
            }
            else
            {
                pressed = false;
            }
        }

        print(pressed);

        if (pressed)
        {
            return KeyPressed;
        }
        else
        {
            return "";
        }
    }

    void Start ()
    {
       
	}
	
	void Update ()
    {
        print(GetKey(KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5));

        //psuedo code begins here, beware weary traveller

        //side = 1 of 6 inputs, only 1 of 6. Never 2
        //if side
        //parent the cubies to that sides center
        //when mouse 1 or mouse 2 is pressed
        //rotate center in direction of mouse press, 1 = 90 2 = -90
        //when rotation is completed do nothing
        //else
        //unparent cubies
        //wait for input

        // input testing
        //if (!Output)
        //{
        //    var InputIndex = 0;
        //    for (int i = 1; i < Inputs.Count; i++)
        //    {
        //        if ()
        //        {

        //        }
        //    }
        //}
    }
}
