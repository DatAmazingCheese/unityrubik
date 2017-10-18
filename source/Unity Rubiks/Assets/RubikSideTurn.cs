using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubikSideTurn : MonoBehaviour
{
    public string Side = "1";
    public Vector3 Direction = Vector3.up;

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
        }

        transform.RotateAround(transform.position, axis, angle - rotated);
    }

    void Update()
    {
        if (Input.GetKey(Side))
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
}
