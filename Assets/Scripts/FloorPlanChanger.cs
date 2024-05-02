using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

//public class FloorPlanChanger : MonoBehaviour
//{
//    //public string sceneName;
//    public GameObject indicator;

//    private void OnTriggerEnter(Collider other)
//    {
//        SetNavigationTarget navTarget = indicator.GetComponent<SetNavigationTarget>();

//        if (other.CompareTag("MainCamera"))
//        {
//            SceneManager.LoadScene(navTarget.floorLevel);
//        }
//    }

//}

//sceneName);//

public class FloorPlanChanger : MonoBehaviour
{
    public Button Floor1Button;
    public Button Floor2Button;
    public Button Floor3Button;
    public Button Floor4Button;
    public Button Floor5Button;

    private void Start()
    {
        Floor1Button.onClick.AddListener(() => { TaskOnClick(); });
        Floor2Button.onClick.AddListener(() => { TaskOnClick(); });
        Floor3Button.onClick.AddListener(() => { TaskOnClick(); });
        Floor4Button.onClick.AddListener(() => { TaskOnClick(); });
        Floor5Button.onClick.AddListener(() => { TaskOnClick(); });

    }
        private void Update()
    {
        if (FloorManager.Instance != null)
        {
            switch (FloorManager.Instance.floorLevel)
            {
                case 0:
                    Image btnImage = Floor1Button.GetComponent<Image>();
                    btnImage.color = Color.yellow;
                    break;
                case 1:
                    Image btnImage2 = Floor2Button.GetComponent<Image>();
                    btnImage2.color = Color.yellow;
                    break;
                case 2:
                    Image btnImage3 = Floor3Button.GetComponent<Image>();
                    btnImage3.color = Color.yellow;
                    break;
                case 3:
                    Image btnImage4 = Floor4Button.GetComponent<Image>();
                    btnImage4.color = Color.yellow;
                    break;
                case 4:
                    Image btnImage5 = Floor5Button.GetComponent<Image>();
                    btnImage5.color = Color.yellow;
                    break;
                default:
                    // UNREACHABLE
                    break;
            }
        }
    }

    public void TaskOnClick()
    {

        //if (other.CompareTag("MainCamera"))
        //{
        if (FloorManager.Instance != null)
        {
                SceneManager.LoadScene(FloorManager.Instance.floorLevel);
        }
        //}
    }
}
