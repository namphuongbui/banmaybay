using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletenmyboss2 : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private float speed = 3f;

    private Collider2D _collider2D;
    public Vector2 force;
    public Vector2 forceStart;
    public Vector2 forceFolowing;
    public Vector2 forceEnd;
    public bool isFollowing;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        gameObject.SetActive(false);
    }



    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.CompareTag("Player"))
        {
            enemy.GetComponent<PlayerTouchControl>().DecreaHealth(20);
            Transform vfx = ObjectPutter.Instance.PutObject(SpawnerType.VFXSpark);
            vfx.position = transform.position;
            StopCoroutine(OnStart());
            CameraSake.ins.shake2();
          
            gameObject.SetActive(false);
           
        }
    }
    public IEnumerator OnStart()
    {
        isFollowing = false;
        force = forceStart;
        yield return new WaitForSeconds(0.3f);
        //force = forceFolowing;
        isFollowing = true;
        yield return new WaitForSeconds(3);
        forceStart = forceFolowing;
        isFollowing = false;
        yield return new WaitForSeconds(1.7f);
        Destroy(gameObject);
    }
    private void Update()
    {
        if (!isFollowing)
        {
            _rigidbody2D.velocity = forceStart * speed;
        }
        else
        {
            forceFolowing = GameController.ins.player.transform.position - transform.position;
            _rigidbody2D.velocity = forceFolowing.normalized * speed;
            
        }

    }

}