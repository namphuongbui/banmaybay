using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class PlayerTouchControl : HealthManager2
{
    public Text txtScore;
    int score = 0;
    public ExplosionEffectType explosionType;
    private Transform m_transform;

    private Camera m_camera;
    
    private float speedMove = 0.5f;

    private Vector2 delta_position = Vector2.up * 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        m_transform = transform;
        m_camera = Camera.main;
        txtScore = GameObject.Find("txtScore").GetComponent<Text>();
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            m_transform.position = Vector3.MoveTowards(m_transform.position,
                (Vector2)m_camera.ScreenToWorldPoint(Input.mousePosition) + delta_position, speedMove);
        }
    }


    public override void DecreaHealth(int bulletDamage)
    {
        currentHealth -= bulletDamage;
        if (currentHealth <= 0)
        { 
            
            DeActivate();
          
            Transform explosion = null;
            switch (explosionType)
            {
                case ExplosionEffectType.SmallExplosion:
                    explosion = ObjectPutter.Instance.PutObject(SpawnerType.SmallExplosion);
                    break;
                case ExplosionEffectType.MediumExplosion:
                    explosion = ObjectPutter.Instance.PutObject(SpawnerType.MediumExplosion);
                    break;
            }
            explosion.position = transform.position;
            //SpawnCoin();
            //Reset();
            UImanager.ins.Showgameoverpanel(true);
        }
    }

    protected void Reset()
    {
        currentHealth = health;
        transform.DOKill();
    }
    protected virtual void DeActivate()
    {
        gameObject.GetComponent<ShipWeapon>().StopFire();
        gameObject.GetComponent<ShipWeapon>().StopAllCoroutines();
        gameObject.SetActive(false);
       
    }
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.CompareTag("coin"))

        {
            score += 1;
            txtScore.text = "Score :  " + score.ToString();
           
        }
    }
    public void Replay()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
