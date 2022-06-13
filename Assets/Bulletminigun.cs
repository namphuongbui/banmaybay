using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletminigun : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private float speed = 7f;

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
            gameObject.SetActive(false);
            CameraSake.ins.ShakeOnce(1f,0.5f);
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
        yield return new WaitForSeconds(0.1f);
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