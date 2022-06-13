
using UnityEngine;

public class Bossenemy : BaseEnemy
{
    [SerializeField]
    private Transform healthBarboss;

    [SerializeField]
    private Transform currentHealthBarboss;

    public override void DecreaHealth(int bulletDamage)
    {
        if (!healthBarboss.gameObject.activeSelf)
        {
            healthBarboss.gameObject.SetActive(true);
            currentHealthBarboss.localScale = Vector3.one;
        }
        base.DecreaHealth(bulletDamage);
        if (currentHealth > 0)
        {
            currentHealthBarboss.localScale = new Vector3((float)currentHealth / health, 1f, 1f);
        }
    }

    private void FixRotation()
    {
        healthBarboss.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    private void Update()
    {
        //FixRotation();
    }
}

