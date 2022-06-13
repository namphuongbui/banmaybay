using System.ComponentModel;
using UnityEngine;

public class HealthManagerBoss : MonoBehaviour
{
    [SerializeField]
    [ReadOnly(true)]
    protected int healthboss = 200;


    [SerializeField] protected int currentHealthboss;

    [SerializeField]
    protected Transform healthbar;

    private void Awake()
    {
        currentHealthboss = healthboss;
    }


    public virtual void DecreaHealth(int bulletDamage)
    {
    }

}
