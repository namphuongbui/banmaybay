using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UImanager : MonoBehaviour
{
 
    public GameObject gameoverpanel;
    public static UImanager ins;
    public GameObject fadein;

    private void Start()
    {
        ins = this;
    }
    public void Showgameoverpanel(bool isShow)
    {
        if (gameoverpanel)
        {
            gameoverpanel.SetActive(isShow);
        }
    }
     public void Showfade()
    {
        if (fadein)
        {
            fadein.SetActive(true);
            Invoke(nameof(OutFade), 2f);
        }
    }
    public void OutFade()
    {
        if (fadein)
        {
            fadein.SetActive(false);
        }
    }
}
