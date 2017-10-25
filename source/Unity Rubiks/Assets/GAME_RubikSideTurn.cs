using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAME_RubikSideTurn : MonoBehaviour
{
    public string Side = "1";
    public Vector3 Direction = Vector3.up;
    public GameObject[] AdjacentCubies;
    public bool Completed = true;
    public bool ParentDone = false;

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
        int Count = 0;
        foreach (GameObject Cubie in AdjacentCubies)
        {
            Cubie.transform.parent = transform;
            Count++;
        }
        if (Count >= 8)
        {
            ParentDone = true;
        }
    }

    void RemoveParent()
    {
        foreach (GameObject Cubie in AdjacentCubies)
        {
            Cubie.transform.parent = null;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(Side))
        {
            SetParent();
        }
        if (Input.GetKey(Side))
        {
            if (ParentDone)
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
