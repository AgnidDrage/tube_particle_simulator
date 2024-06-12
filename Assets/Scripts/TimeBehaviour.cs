using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeBehaviour : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    private int timeScale;

    // Update is called once per frame
    void FixedUpdate() 
    {
        if (dropdown.value == 0)
        {
            Time.timeScale = 1;
        }
        else if (dropdown.value == 1)
        {
            Time.timeScale = 10;
        }
        else
        {
            Time.timeScale = 20;
        }
    }
}
