using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
   
    private float speed = 12f;

    private Collider2D _collider2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        _rigidbody2D.velocity = transform.up * speed;
    }



    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.CompareTag("Enemy"))
        {
            enemy.GetComponent<BaseEnemy>().DecreaHealth(2);
            Transform vfx = ObjectPutter.Instance.PutObject(SpawnerType.VFXSpark);
            vfx.position = transform.position;
            gameObject.SetActive(false);
        }
    }
}