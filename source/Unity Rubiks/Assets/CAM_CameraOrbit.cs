using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAM_CameraOrbit : MonoBehaviour
{
    public float RotateAmount = 15f;
    public Transform TargetObject;

    void LateUpdate()
    {
        OrbitCamera();
    }

    public void OrbitCamera()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 target = TargetObject.position; //this is the center of the scene, you can use any point here
            float y_rotate = Input.GetAxis("Mouse X") * RotateAmount;
            float x_rotate = Input.GetAxis("Mouse Y") * RotateAmount;
            OrbitCamera(target, y_rotate, x_rotate);
        }
    }

    public void OrbitCamera(Vector3 target, float y_rotate, float x_rotate)
    {
        Vector3 angles = transform.eulerAngles;
        angles.z = 0;
        transform.eulerAngles = angles;
        transform.RotateAround(target, Vector3.down, y_rotate);
        transform.RotateAround(target, Vector3.right, x_rotate);

        transform.LookAt(target);
    }
}

