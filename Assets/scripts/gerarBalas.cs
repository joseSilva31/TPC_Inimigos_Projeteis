using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerarBalas : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bala;
    SpriteRenderer renderer;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            GameObject clone = Instantiate(bala, transform.position, Quaternion.identity);
            gameObject.GetComponent<AudioSource>().Play();
            if (!renderer.flipX)
                clone.GetComponent<Rigidbody2D>().velocity = Vector2.right*10;
            else
                clone.GetComponent<Rigidbody2D>().velocity = Vector2.left*10;
        }
    }

}
