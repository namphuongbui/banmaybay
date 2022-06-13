using System.ComponentModel;
using UnityEngine;

public class HealthManager2 : MonoBehaviour
{
    [SerializeField]
    [ReadOnly(true)]
    protected int health = 100;

    [SerializeField] protected int currentHealth;

    [SerializeField]
    protected Transform healthbar;

    private void Awake()
    {
        currentHealth = health;
    }


    public virtual void DecreaHealth(int bulletDamage)
    {
    }

}
