using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Vector3 trackDistance;
    public Camera mainCamera;
    public Transform targetTransform;

    private void LateUpdate()
    {
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetTransform.position + trackDistance, Time.deltaTime * 6f);
    }
}

