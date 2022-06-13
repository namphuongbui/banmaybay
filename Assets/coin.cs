using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class coin : MonoBehaviour
{

    private Rigidbody2D rgb2d;
    private Vector2 force;
   
    // Start is called before the first frame update
    void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();
        InvokeRepeating("AddRandomForce", 1f, 0.5f);
    }
   
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.CompareTag("Player"))

        {
            
            Destroy(gameObject);
        }
    }

    void AddRandomForce()
    {
        force = new Vector2(Random.Range(-100, 100), Random.Range(100, 500));
        rgb2d.AddForce(force);
    }
}
