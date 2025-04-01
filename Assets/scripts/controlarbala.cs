using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlarbala : MonoBehaviour
{
    // Start is called before the first frame update

    public int lifetime = 200;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifetime--;
        if(lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "inimigo")
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }
}
