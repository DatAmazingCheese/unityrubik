using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAME_RubikSideTurn : MonoBehaviour
{
    public int Side = 1; // what side is the center
    public Vector3 Direction = Vector3.up; // direction for rotation
    public GameObject RubikOrigin; // rubik cube origin object

    public Vector3 FindBoxScale = new Vector3(1.5f, 1.5f, 0.5f); // half-ent scale for box cast
    public Collider[] AdjacentCubies; // list of adjacent cubies found in box cast

    List<int> OtherSides = new List<int>() { 1, 2, 3, 4, 5, 6 }; // list of the other sides of a cube

    bool Completed = true; // rotation completion
    bool ParentDone = false; // parent completion 

    IEnumerator RotateAround(Vector3 axis, float angle, float duration)
    {
        float elasped = 0f;
        float rotated = 0f;

        while (elasped < duration)
        {
            float step = angle / duration * Time.deltaTime;
            transform.RotateAround(transform.position, axis, step);
            elasped += Time.deltaTime;
            rotated += step;
            yield return null;

            Completed = false;
        }
        if (elasped == duration)
        {
            Completed = true;
        }
        transform.RotateAround(transform.position, axis, angle - rotated);
    }

    void SetParent()
    {
        Collider[] AdjacentCubies = Physics.OverlapBox(transform.position, FindBoxScale, Quaternion.identity, 1 << 8); // find adjacent cubies next to center

        int Count = 0; // reset count

        if (AdjacentCubies != null)
        {
            foreach (Collider Cubie in AdjacentCubies) // for each cubie in the list, parent to the center
            {
                Cubie.gameObject.transform.parent = transform;
                Count++;
            }
            if (Count >= 8)
            {
                ParentDone = true;
            }
        }
    }
   
    void RemoveParent()
    {
        if (AdjacentCubies != null)
        {
            foreach (Collider Cubie in AdjacentCubies) // for each cubie in the list, parent to the rubik origin
            {
                Cubie.gameObject.transform.parent = RubikOrigin.transform;
            }
        }
    }

    void Update()
    {
        switch (Side)
        {
            case 1:
                break;
            case 2:
                break;
        }
        if (Input.GetKeyDown(Side.ToString()) & !Input.GetKeyDown(Side.ToString()) & !Input.GetKeyDown(Side.ToString()) & !Input.GetKeyDown(Side.ToString()) & !Input.GetKeyDown(Side.ToString()) & !Input.GetKeyDown(Side.ToString()))
        {
            AdjacentCubies = null; // reset list for new box cast
            SetParent();
        }
        if (Input.GetKey(Side.ToString()))
        {
            if (ParentDone) // rotation for the center
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    StartCoroutine(RotateAround(Direction, -90, 0.7f));
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    StartCoroutine(RotateAround(Direction, 90, 0.7f));
                }
            }
        }
        if (Completed)
        {
            RemoveParent();
        }
    }
}
