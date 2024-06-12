using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera mainCamera;
    public float thresholdDistance;
    public int tubeShape = 0; // Indicates with shape instantiate
    public GameObject circleTube;
    public float circleDiameter = 2f;
    public GameObject rectangleTube;
    public Vector2 rectangleShape = new Vector2(3f,3f);
    public Transform spawnPoint;
    public GameObject particle;
    public bool canInvoke = true;
    public int timeScale = 1;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        spawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();
        if (tubeShape == 0)
        {
            instantiateCircle(circleTube, circleDiameter, spawnPoint);
        }
        else if (tubeShape == 1)
        {
            instantiateRectangle(rectangleTube, rectangleShape, spawnPoint);
        }
    }

    private void FixedUpdate() 
    {
        Time.timeScale = timeScale;

        if (canInvoke)
        {
            invokeParticle(particle, spawnPoint);
        }
    }

    private void instantiateCircle(GameObject circleTube, float diameter, Transform spawnPoint)
    {
        Instantiate(circleTube, spawnPoint.position, Quaternion.identity);
        Transform circle = GameObject.FindGameObjectWithTag("Tube").GetComponent<Transform>();
        circle.localScale = new Vector3(diameter, diameter, 1); 
        mainCamera.orthographicSize = diameter;
        thresholdDistance = diameter * 0.25f;
    }

    private void instantiateRectangle(GameObject rectangleTube, Vector2 shape, Transform spawnPoint)
    {
        Instantiate(rectangleTube, spawnPoint.position, Quaternion.identity);
        Transform rectangle = GameObject.FindGameObjectWithTag("Tube").GetComponent<Transform>();
        rectangle.localScale = shape;
        if (shape.x > shape.y)
        {
            mainCamera.orthographicSize = shape.x;
            thresholdDistance = shape.y * 0.25f;
        }
        else
        {
            mainCamera.orthographicSize = shape.y;
            thresholdDistance = shape.x * 0.25f;
        }
    }

    private void invokeParticle(GameObject particle, Transform spawnPoint)
    {
        canInvoke = false;
        GameObject generatedParticle = Instantiate(particle, spawnPoint.position, Quaternion.identity);
        float side = Random.Range(1f, 10f);
        generatedParticle.transform.localScale = new Vector3(side, side, 1);
    }
}
