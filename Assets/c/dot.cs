using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class dot : MonoBehaviour
{

    public Transform hedef;
    public float zaman;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(hedef.position, zaman);
    }

}
