using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Rigidbody2D rb;
    private bool isGrounded;
    private float screenLeftLimit;
    private float screenRightLimit;

    void Start()
    {
        // Calcula os limites da tela em coordenadas do mundo
        float halfPlayerWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        screenLeftLimit = Camera.main.ScreenToWorldPoint(Vector3.zero).x + halfPlayerWidth;
        screenRightLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - halfPlayerWidth;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1f;
        }

        Vector2 velocity = rb.velocity;
        velocity.x = moveInput * moveSpeed;
        rb.velocity = velocity;

        // Garante que o jogador não saia da tela
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, screenLeftLimit, screenRightLimit);
        transform.position = newPosition;

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}
