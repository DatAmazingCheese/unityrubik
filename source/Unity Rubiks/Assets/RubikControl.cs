using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubikControl : MonoBehaviour
{
    public string Side = "1";

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

        }
    }
}
