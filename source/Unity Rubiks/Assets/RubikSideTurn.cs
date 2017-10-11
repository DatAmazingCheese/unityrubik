using System.Collections;
using UnityEngine;

public class RubikSideTurn : MonoBehaviour
{
    public float RotateAngle = 90f;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(RotateAround(Vector3.up, RotateAngle, 1.0f));
        }
    }
}
