using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    public float speed =2f;
    public Transform target;

    // Start is called before the first frame update

    // Update is called once per frame
    private void Start()
    {
        target = GameController.ins.player.transform;
    }
    void Update()
    {

        Vector3 mousePos = target.position;
        mousePos.z = 0;



        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        angle -= -90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    }
