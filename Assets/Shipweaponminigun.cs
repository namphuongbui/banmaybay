using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shipweaponminigun : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _listFirePoint;

    [SerializeField]
    private List<ParticleSystem> _listFirePointEffect;

    private float fire_rate_weapon = 1f;


    private IEnumerator SpawnBullet()
    {
        if (!GameController.ins.player.activeSelf)
        {
            yield break;
        }
        var a = GameController.ins.player.transform.position - transform.position;
        Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.Bulletminigun);
        bullet1.position = _listFirePoint[0].position;
        bullet1.rotation = transform.rotation;




        Transform bullet2 = ObjectPutter.Instance.PutObject(SpawnerType.Bulletminigun);
        bullet2.position = _listFirePoint[1].position;
        bullet2.rotation = transform.rotation;
        Transform bullet3 = ObjectPutter.Instance.PutObject(SpawnerType.Bulletminigun);
        bullet3.position = _listFirePoint[2].position;
        bullet3.rotation = transform.rotation;
        Transform bullet4 = ObjectPutter.Instance.PutObject(SpawnerType.Bulletminigun);
        bullet4.position = _listFirePoint[3].position;
        bullet4.rotation = transform.rotation;

        bullet1.GetComponent<Bulletminigun>().force = a.normalized;
        bullet2.GetComponent<Bulletminigun>().force = a.normalized;
        bullet3.GetComponent<Bulletminigun>().force = a.normalized;
        bullet4.GetComponent<Bulletminigun>().force = a.normalized;

        //bullet4.rotation = Quaternion.Euler(0f, 0f, -1f);
        StartCoroutine(bullet1.GetComponent<Bulletenmyboss2>().OnStart());
        StartCoroutine(bullet2.GetComponent<Bulletenmyboss2>().OnStart());
        StartCoroutine(bullet3.GetComponent<Bulletenmyboss2>().OnStart());
        StartCoroutine(bullet4.GetComponent<Bulletenmyboss2>().OnStart());


        yield return null;
    }

   


    private IEnumerator StartFire()
    {
        if (!GameController.ins.player.activeSelf)
        {
            yield break;
        }
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