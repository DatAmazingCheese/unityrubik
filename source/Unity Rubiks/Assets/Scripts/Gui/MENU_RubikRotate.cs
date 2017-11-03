using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MENU_RubikRotate : MonoBehaviour
{
	void Update ()
    {
        transform.Rotate(Vector3.up * 10 * Time.deltaTime, Space.World);
    }
}
