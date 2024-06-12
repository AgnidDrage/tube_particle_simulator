using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public GameObject circleOptions;
    public GameObject rectangleOptions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dropdown.value == 0)
        {
            circleOptions.SetActive(true);
            rectangleOptions.SetActive(false);
        }
        else
        {
            circleOptions.SetActive(false);
            rectangleOptions.SetActive(true);
        }
    }
}
