using TMPro;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    private int tubeShape;
    public GameObject circleOptions;
    public TMP_InputField inputDiameter;
    private int diameterValue = 100;
    public GameObject rectangleOptions;
    public TMP_InputField InputXshape;
    public TMP_InputField InputYshape;
    private int xShapeValue = 100;
    private int yShapeValue = 100;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tubeShape = dropdown.value;
        if (tubeShape == 0)
        {
            circleOptions.SetActive(true);
            rectangleOptions.SetActive(false);
            diameterValue = int.Parse(inputDiameter.text);
        }
        else
        {
            circleOptions.SetActive(false);
            rectangleOptions.SetActive(true);
            xShapeValue = int.Parse(InputXshape.text);
            yShapeValue = int.Parse(InputYshape.text);
        }
    }

    public void StartSimulation()
    {
        PlayerPrefs.SetInt("tubeShape", tubeShape);
        PlayerPrefs.SetInt("diameterValue", diameterValue);
        PlayerPrefs.SetInt("xShapeValue", xShapeValue);
        PlayerPrefs.SetInt("yShapeValue", yShapeValue);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Simulation");
    }

    public void exit()
    {
        Application.Quit();
    }

}
