using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAME_RubikInputHandler : MonoBehaviour
{
    public List<GameObject> Centers;
    public GAME_RubikSideTurn TurnHandler;

    //bool One = Input.GetKey("space");

    List<bool> Inputs = new List<bool>() { false, false, false, false, false, false}; 

	void Start ()
    {
       
	}
	
	void Update ()
    {
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
