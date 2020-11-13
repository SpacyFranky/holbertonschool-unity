using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public bool useOffsetValues;
    public float rotateSpeed;
    public Transform pivot;
    public float maxViewAngle;
    public float minViewAngle;
    public bool isInverted;

    void Start()
    {
        // For camera positioning
        if (!useOffsetValues)
            offset = target.position - transform.position;

        // Setting pivot position with target position
        pivot.transform.position = target.transform.position;
        //pivot.transform.parent = target.transform;
        pivot.transform.parent = null;
        pivot.parent = null;

        // Hide cursor when ingame
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void LateUpdate()
    {
        // Stops rotation when on pause
        if (Time.deltaTime == 0)
            return;

        
        pivot.transform.position = target.transform.position;
        
        
        // Setting horizontal axis from mouse input
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        pivot.Rotate(0, horizontal, 0);

        // Setting vertical axis from mouse input
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        
        // Checks toggle isInverted
        int yAxis = PlayerPrefs.GetInt("IsInverted");
        if (yAxis == 0)
            pivot.Rotate(-vertical, 0, 0);
        else
            pivot.Rotate(vertical, 0, 0);
        
        PlayerPrefs.Save();
        //Limit up/down camera rotation
        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
            pivot.rotation = Quaternion.Euler(maxViewAngle, pivot.eulerAngles.y, 0.0f);
        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minViewAngle)
            pivot.rotation = Quaternion.Euler(360f + minViewAngle, pivot.eulerAngles.y, 0.0f);

        float desiredYAngle = pivot.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation * offset);

        if (transform.position.y < target.position.y)
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);

        transform.LookAt(target);
    }
}
