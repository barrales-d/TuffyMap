using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhanceTouch = UnityEngine.InputSystem.EnhancedTouch;

[RequireComponent(typeof(ARRaycastManager), typeof(ARPlaneManager))]
public class PlaceFloor : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabFloor;

    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;
    private List<ARRaycastHit> hitList = new List<ARRaycastHit>();

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
    }

    private void OnEnable()
    {
        EnhanceTouch.TouchSimulation.Enable();
        EnhanceTouch.EnhancedTouchSupport.Enable();
        EnhanceTouch.Touch.onFingerDown += FingerDown;
    }

    private void OnDisable()
    {
        EnhanceTouch.TouchSimulation.Disable();
        EnhanceTouch.EnhancedTouchSupport.Disable();
        EnhanceTouch.Touch.onFingerDown -= FingerDown;
    }

    private void FingerDown(EnhanceTouch.Finger finger)
    {
        if (finger.index != 0) return;

        if (raycastManager.Raycast(finger.currentTouch.screenPosition, hitList, TrackableType.PlaneWithinPolygon))
        {
            foreach (ARRaycastHit hit in hitList)
            {
                if (planeManager.GetPlane(hit.trackableId).alignment == PlaneAlignment.HorizontalUp)
                {
                    Pose pose = hit.pose;
                    Vector3 floorPosition = pose.position;
                    Quaternion floorRotation = Quaternion.identity; // No rotation

                    // Create the floor model and align it with the detected horizontal plane
                    GameObject floorObject = Instantiate(prefabFloor, floorPosition, floorRotation);

                    // Optionally, you can set the floorObject as a child of a parent object for organization
                    floorObject.transform.parent = transform;
                }
            }
        }
    }
}
