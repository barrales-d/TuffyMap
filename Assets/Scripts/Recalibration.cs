using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class RecalibrationHandler : MonoBehaviour
{
    [SerializeField]
    private XROrigin xrOrigin;

    [SerializeField]
    private ARSession session;

    [SerializeField]
    private Camera arSessionCamera;

    public Vector3 testPosition = Vector3.zero;
    public Quaternion testRotation = Quaternion.identity;

    public void Recalibrate()
    {
        // Set the desired position for recalibration, e.g., the center of the room
        // Vector3 desiredPosition = new Vector3(0, 0, 0);
        // Quaternion desiredRotation = Quaternion.identity;

        Vector3 desiredPosition = arSessionCamera.transform.position;
        Quaternion desiredRotation = Quaternion.identity;
        desiredRotation.y = arSessionCamera.transform.rotation.y;
        desiredRotation.w = arSessionCamera.transform.rotation.w;

        // Move the XROrigin to the desired position and rotation
        xrOrigin.transform.SetPositionAndRotation(desiredPosition, desiredRotation);

        // Optionally, reset the tracking to apply the recalibration
        session.Reset();
    }

}