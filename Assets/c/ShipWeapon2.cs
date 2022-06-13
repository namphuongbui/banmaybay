using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapon2 : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _listFirePoint;

    [SerializeField]
    private List<ParticleSystem> _listFirePointEffect;

    private float fire_rate_weapon = 2f;


    private IEnumerator SpawnBullet()
    {
        var a = GameController.ins.player.transform.position - transform.position;
        Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet2);
        bullet1.position = _listFirePoint[0].position;

        bullet1.rotation = transform.rotation;

        
        

        Transform bullet2 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet2);
        bullet2.position = _listFirePoint[1].position;
        bullet2.rotation = transform.rotation;
        Transform bullet3 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet2);
        bullet3.position = _listFirePoint[2].position;
        bullet3.rotation = transform.rotation;
        Transform bullet4 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet2);
        bullet4.position = _listFirePoint[3].position;
        bullet4.rotation = transform.rotation;
        bullet1.GetComponent<Bullet2>().force = a.normalized - Vector3.right;
        bullet2.GetComponent<Bullet2>().force = a.normalized;
        bullet3.GetComponent<Bullet2>().force = a.normalized;
        bullet4.GetComponent<Bullet2>().force = a.normalized+Vector3.right;

        bullet1.GetComponent<Bullet2>().Activate();
        bullet2.GetComponent<Bullet2>().Activate();
        bullet3.GetComponent<Bullet2>().Activate();
        bullet4.GetComponent<Bullet2>().Activate();
        

        yield return null;
    }

    private IEnumerator StartFire()
    {
        yield return new WaitForSeconds(2.0f);
        while (true)
        {
            StartCoroutine(SpawnBullet());
            yield return new WaitForSeconds(fire_rate_weapon);

        }
    }

    private void OnEnable()
    {
        StartCoroutine(StartFire());
    }

}