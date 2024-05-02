using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Users;

public class SearchBarHandler : MonoBehaviour
{
    private string inputString;

    [SerializeField]
    private SetNavigationTarget target;

    public void OnChange(string inputStr)
    {
        inputString = inputStr;
    }

    public void OnClick()
    {
        if (target != null)
        {
            target.UpdateTarget(inputString);
            FloorManager.Instance.targetClassroom = inputString;

        }
    }
}
