using System.ComponentModel;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    [ReadOnly(true)]
    protected int health = 200;
    

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
