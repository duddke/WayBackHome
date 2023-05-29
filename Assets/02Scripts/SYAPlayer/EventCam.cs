using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCam : MonoBehaviour
{
    
    public Transform target;

    public float smoothSpeed = 3;
    public float xDist;
    public Vector3 offset;
    public float limitMinZ, limitMaxZ, limitMinY, limitMaxY;
    float cameraHalfWidth, cameraHalfHeight;

    private void Start()
    {
        cameraHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        cameraHalfHeight = Camera.main.orthographicSize;
        

    }

    private void LateUpdate()
    {
        if (CamManager.Instaced.spCam)
        {
            if (target)
            {

            float z = transform.position.z;
            Vector3 desiredPosition = new Vector3(
            target.position.x+ xDist,              // X
            Mathf.Clamp(target.position.y + offset.y, limitMinY + cameraHalfHeight, limitMaxY - cameraHalfHeight), // Y
            Mathf.Clamp(target.position.z + offset.z, limitMinZ + cameraHalfWidth, limitMaxZ - cameraHalfWidth)); // Z
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
            }
        }
    }

}
