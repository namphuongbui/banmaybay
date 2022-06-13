using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumPlayer : PlayerTouchControl
{
    [SerializeField]
    private Transform healthBar;

    [SerializeField]
    private Transform currentHealthBar;
    private Transform m_transform;

    private Camera m_camera;

    private float speedMove = 0.5f;
   

    private Vector2 delta_position = Vector2.up * 0.5f;
    private void Start()
    {
        m_transform = transform;
        m_camera = Camera.main;
        
    }
    public override void DecreaHealth(int bulletDamage)
    {
        if (!healthBar.gameObject.activeSelf)
        {
            healthBar.gameObject.SetActive(true);
            currentHealthBar.localScale = Vector3.one;
        }
        if (currentHealth <= 0)
        {
          
            StopAllCoroutines();
        }
        base.DecreaHealth(bulletDamage);
        if (currentHealth > 0)
        {
            currentHealthBar.localScale = new Vector3((float)currentHealth / health, 1f, 1f);
        }
        
    }

    private void FixRotation()
    {
        healthBar.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    private void Update()
    {
        //FixRotation();
        if (Input.GetMouseButton(0))
        {
            m_transform.position = Vector3.MoveTowards(m_transform.position,
                (Vector2)m_camera.ScreenToWorldPoint(Input.mousePosition) + delta_position, speedMove);
        }
    }
}