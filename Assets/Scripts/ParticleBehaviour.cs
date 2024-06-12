using UnityEngine;

public class MovimientoParticula : MonoBehaviour
{
    public float maxSpeed = 50f; // Velocidad máxima de la partícula
    public bool hasCollide = false; // Booleano para rastrear si la partícula se congeló
    public GameManager gameManager;

    private Rigidbody2D rb;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!hasCollide)
        {
            // Mover la partícula de manera aleatoria en x e y
            Vector2 movement = new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
            rb.velocity = movement.normalized * maxSpeed * Time.timeScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tube") || collision.gameObject.CompareTag("Particle"))
        {
            // La partícula chocó con un objeto con el tag "Tube" o "particle"
            hasCollide = true;
            rb.velocity = Vector2.zero; // Detener la partícula
            rb.isKinematic = true;
            float distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(gameManager.spawnPoint.position.x, gameManager.transform.position.y));
            if (distance > gameManager.thresholdDistance)
            {
                gameManager.canInvoke = true;
            }
            else
            {
                gameManager.canInvoke = false;
            }
        }
    }
}
