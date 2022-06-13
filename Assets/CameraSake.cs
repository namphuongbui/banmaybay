using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSake : MonoBehaviour
{
    public static CameraSake ins;
    public Vector3 pos;
    private void Start()
    {
        ins = this;
        pos = transform.position;
        
    }
    public IEnumerator ShakeOnce( float time , float magnitube)
    {
        float totalTime = 0f;
        while(totalTime<time)
        {
            totalTime += Time.deltaTime;
            float x = Random.Range(-1, 1) * magnitube;
            float y = Random.Range(-1, 1) * magnitube;
            float z = Random.Range(-1, 1) * magnitube;
            transform.position = pos + new Vector3(x, y, 0);
            yield return null;
        }
        transform.position = pos;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("shake");
            StartCoroutine( ShakeOnce(1f,0.1f));
           
        }
    }
    public void shake2()
    {
        StartCoroutine(ShakeOnce(1, 0.1f));
    }
}
