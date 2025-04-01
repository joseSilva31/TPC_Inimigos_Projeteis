using UnityEngine;

public class MovementSpikey : MonoBehaviour
{
    public float speed = 3f; // Velocidade do obstáculo
    private float screenLeftLimit;
    private float screenRightLimit;

    void Start()
    {
        // Calcula os limites da tela em coordenadas do mundo
        float halfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        screenLeftLimit = Camera.main.ScreenToWorldPoint(Vector3.zero).x - halfWidth;
        screenRightLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x + halfWidth;
    }

    void Update()
    {
        MoveObstacle();
    }

    void MoveObstacle()
    {
        // Move o obstáculo para a esquerda
        transform.position += Vector3.left * speed * Time.deltaTime;
        
        // Se ultrapassar o limite esquerdo, reaparece do lado direito
        if (transform.position.x < screenLeftLimit)
        {
            transform.position = new Vector3(screenRightLimit, transform.position.y, transform.position.z);
        }
    }
}

