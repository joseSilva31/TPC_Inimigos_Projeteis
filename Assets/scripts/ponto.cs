using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ponto : MonoBehaviour
{

    public int pontos;
    public int vidas;
    TextMeshProUGUI textPontos;
    TextMeshProUGUI textVidas;
    // Start is called before the first frame update
    void Start()
    {
        pontos = 0;
        vidas = 3;
        textPontos = GameObject.Find("TextPontos").GetComponent<TextMeshProUGUI>();
        textPontos.text = "Pontos: " + pontos.ToString();
        textVidas = GameObject.Find("TextVidas").GetComponent<TextMeshProUGUI>();
        textVidas.text = "Vidas: " + vidas.ToString();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "moeda")
        {
            pontos = pontos + 1;
            textPontos.text = "Pontos: " + pontos.ToString();
            Debug.Log("Pontos: " + pontos);
            Destroy(coll.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "inimigo")
        {
            vidas = vidas - 1;
            textVidas.text = "Vidas: " + vidas.ToString();
            Debug.Log("Vidas: " + vidas);
            if (vidas == 0)
            {
                GameObject.Find("TextGameOver").GetComponent<TextMeshProUGUI>().enabled = true;
                Destroy(gameObject);
            }
            
        }
    }
    
}
