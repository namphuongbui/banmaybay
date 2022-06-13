using DG.Tweening;
using System;
using UnityEngine;

public class BaseEnemy : HealthManager
{


    private DOTweenPath mainPath;
    //public event Action OnEnemyDestroy;
    private DOTweenPath additionPath;
    public ExplosionEffectType explosionType;
    private bool isRotateToPath;
    public bool drop;
    public GameObject theDrop,theDrop1, theDrop2, theDrop3;
    public event Action OnEnemyDestroy;
    public void Init(DOTweenPath _mainPath, DOTweenPath _additionPath, bool _isRotateToPath)
    {
        mainPath = _mainPath;
        additionPath = _additionPath;
        transform.position = mainPath.wps[0];
        isRotateToPath = _isRotateToPath;
        StartMove();
    }

    public virtual void StartMove()
    {
        if (isRotateToPath)
        {
            transform.DOPath(mainPath.wps.ToArray(), mainPath.duration, mainPath.pathType, PathMode.TopDown2D, mainPath.pathResolution)
                .SetOptions(mainPath.isClosedPath)
                .SetDelay(mainPath.delay)
                .SetLoops(mainPath.loops, mainPath.loopType)
                .SetSpeedBased(mainPath.isSpeedBased)
                .SetLookAt(0f, Vector3.forward, Vector3.left)
                .SetEase(mainPath.easeCurve)
                .onComplete += delegate
                {
                    if (!additionPath)
                    {
                        DeActivate();
                    }
                    else
                    {
                        ContinueAdditionPath();
                    }
                };
        }
        else
        {
            transform.DOPath(mainPath.wps.ToArray(), mainPath.duration, mainPath.pathType, PathMode.TopDown2D, mainPath.pathResolution)
                .SetOptions(mainPath.isClosedPath)
                .SetDelay(mainPath.delay)
                .SetLoops(mainPath.loops, mainPath.loopType)
                .SetSpeedBased(mainPath.isSpeedBased)
                .SetEase(mainPath.easeCurve)
                .onComplete += delegate
                {
                    if (!additionPath)
                    {
                        DeActivate();
                    }
                    else
                    {
                        ContinueAdditionPath();
                    }
                };
        }

    }

    protected void ContinueAdditionPath()
    {
        transform.DOPath(additionPath.wps.ToArray(), additionPath.duration, additionPath.pathType, PathMode.TopDown2D,
                additionPath.pathResolution)
            .SetOptions(additionPath.isClosedPath)
            .SetDelay(additionPath.delay)
            .SetLoops(additionPath.loops, additionPath.loopType)
            .SetSpeedBased(additionPath.isSpeedBased)
            .SetEase(additionPath.easeCurve);
    }


    protected virtual void DeActivate()
    {
        gameObject.SetActive(false);
        OnDeActivate();
    }
    protected virtual void OnDeActivate()
    {
        if (OnEnemyDestroy != null)
        {
            OnEnemyDestroy();
            OnEnemyDestroy = null;
        }
    }
    public override void DecreaHealth(int bulletDamage)
    {
        currentHealth -= bulletDamage;
        if (currentHealth <= 0)
        {
            DeActivate();
            SpawnCoin();
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
            Reset();
        }
    }

    protected void Reset()
    {
        currentHealth = health;
        transform.DOKill();
    }
    public void SpawnCoin()
    {
        if (drop)
        {

            Instantiate(theDrop, transform.position, transform.rotation);
           
            Instantiate(theDrop2, transform.position, transform.rotation);
            Instantiate(theDrop1, transform.position, transform.rotation);
            Instantiate(theDrop3, transform.position, transform.rotation);
        }
    }
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.CompareTag("Player"))
        {
            enemy.GetComponent<PlayerTouchControl>().DecreaHealth(20);
            Transform vfx = ObjectPutter.Instance.PutObject(SpawnerType.VFXSpark);
            vfx.position = transform.position;
            gameObject.SetActive(false);

        }
    }
   



}
