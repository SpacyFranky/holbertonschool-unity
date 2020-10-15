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
        pivot.transform.parent = target.transform;

        // Hide cursor when ingame
        Cursor.lockState = CursorLockMode.Locked;
    }


    void LateUpdate()
    {
        // Stops rotation when on pause
        if (Time.deltaTime == 0)
            return;

        // Setting horizontal axis from mouse input
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0, horizontal, 0);

        // Setting vertical axis from mouse input
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        if (!isInverted)
            pivot.Rotate(-vertical, 0, 0);
        else
            pivot.Rotate(vertical, 0, 0);

        //Limit up/down camera rotation
        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minViewAngle)
            pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0, 0);

        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation * offset);

        if (transform.position.y < target.position.y)
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);

        transform.LookAt(target);
    }
}
