using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAME_RubikSideTurn : MonoBehaviour
{
    public GameObject Center;
    public GameObject Origin;

    Collider[] AdjacentCubies; // list of adjacent cubies found in box cast

    bool RotationCompleted = true; // rotation completion
    bool ParentCompleted = false; // parent completion 

    IEnumerator RotateAround(GameObject center, Vector3 axis, float angle, float duration)
    {
        float elasped = 0f;
        float rotated = 0f;

        var centertransform = center.transform;

        while (elasped < duration)
        {
            float step = angle / duration * Time.deltaTime;
            centertransform.RotateAround(centertransform.position, axis, step);
            elasped += Time.deltaTime;
            rotated += step;
            yield return null;

            RotationCompleted = false;
        }
        if (elasped == duration)
        {
            RotationCompleted = true;
        }
        centertransform.RotateAround(centertransform.position, axis, angle - rotated);
    }

    public void SetParent(Vector3 findboxscale)
    {
        Collider[] AdjacentCubies = Physics.OverlapBox(Center.transform.position, findboxscale, Quaternion.identity, 1 << 8); // find adjacent cubies next to center

        int Count = 0; // reset count

        if (AdjacentCubies != null)
        {
            foreach (Collider Cubie in AdjacentCubies) // for each cubie in the list, parent to the center
            {
                Cubie.gameObject.transform.parent = Center.transform;
                Count++;
            }
            if (Count >= 8)
            {
                ParentCompleted = true;
            }
        }
    }

    public void RemoveParent()
    {
        if (AdjacentCubies != null)
        {
            foreach (Collider Cubie in AdjacentCubies) // for each cubie in the list, parent to the rubik origin
            {
                Cubie.gameObject.transform.parent = Origin.transform;
            }
        }
    }

    public void RotateCenter(GameObject center, Vector3 axis, float angle)
    {
        StartCoroutine(RotateAround(center, axis, angle, 1f));
    }
}
