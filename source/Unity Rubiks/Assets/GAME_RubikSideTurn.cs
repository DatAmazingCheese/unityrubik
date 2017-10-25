using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAME_RubikSideTurn : MonoBehaviour
{
    public string Side = "1";
    public Vector3 Direction = Vector3.up;
    public Vector3 FindBoxScale = new Vector3(1.5f, 1.5f, 0.5f);
    public Collider[] AdjacentCubies;
    public GameObject RubikOrigin;

    bool Completed = true;
    bool ParentDone = false;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(3, 3, 1));
    }

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
        Collider[] AdjacentCubies = Physics.OverlapBox(transform.position, FindBoxScale, Quaternion.identity, 1 << 8);

        int Count = 0;

        if (AdjacentCubies != null)
        {
            foreach (Collider Cubie in AdjacentCubies)
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
            foreach (Collider Cubie in AdjacentCubies)
            {
                Cubie.gameObject.transform.parent = RubikOrigin.transform;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(Side))
        {
            AdjacentCubies = null;
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
