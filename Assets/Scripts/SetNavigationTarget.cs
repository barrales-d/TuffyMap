//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class SetNavigationTarget : MonoBehaviour
//{
//    [SerializeField]
//    private Camera topDownCamera;
//    [SerializeField]
//    private GameObject navTargetObject;
//    int test = 0;

//    private NavMeshPath path; // current calculated path
//    private LineRenderer line; // linerenderer to display path

//    private bool lineToggle = false;

//    // Start is called before the first frame update
//    void Start() // start function
//    {
//        path = new NavMeshPath();
//        line = transform.GetComponent<LineRenderer>();
//    }

//    // Update is called once per frame 
//    void Update() // update function
//    {

//        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
//        {
//            lineToggle = !lineToggle;
//        }
//        if (lineToggle)
//        {
//            NavMesh.CalculatePath(transform.position, navTargetObject.transform.position, NavMesh.AllAreas, path);
//            line.positionCount = path.corners.Length;
//            line.SetPositions(path.corners);
//            line.enabled = true;
//        }
//    }
//}
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class SetNavigationTarget : MonoBehaviour
{
    [SerializeField]
    private Camera topDownCamera;

    [SerializeField]
    private GameObject searchableTargets;

    [SerializeField]
    private List<GameObject> elevators;

    public string targetName = string.Empty;
    public Vector3 targetPos = Vector3.zero;

    // hardcode in Unity?  for each scene
    public int floorLevel = 0;

    //    private bool changeFloors = false;

    public NavMeshPath path; // current calculated path
    private LineRenderer line; // linerenderer to display path

    // Start is called before the first frame update
    void Start() // start function
    {
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
    }

    // Update is called once per frame 
    void Update() // update function
    {
        if (targetName == string.Empty) { return; }

        //Vector3 targetPos = Vector3.zero;

        bool targetFound = false;
        foreach (Transform target in searchableTargets.transform)
        {
            if (targetName.Equals(target.name))
            { 
                targetPos = target.position;
                targetFound = true;
                break;
            }
        }
        if (!targetFound)
        {
            // TODO: load scene of targetFloorLevel and pass targetName information
            int targetFloorLevel = targetName[0] - '0';
            targetPos = elevators[0].transform.position;
            SetFloorLevel(targetFloorLevel);
            targetFound = true;
            // TODO: figure out which elevator the user is using?
        }

        NavMesh.CalculatePath(transform.position, targetPos, NavMesh.AllAreas, path);
        line.positionCount = path.corners.Length;
        line.SetPositions(path.corners);
        line.enabled = targetFound;
    }

    void SetFloorLevel(int level)
    {
        floorLevel = level - 1;
        FloorManager.Instance.floorLevel = floorLevel;

    }

    public void UpdateTarget(string name) { targetName = name; }
}