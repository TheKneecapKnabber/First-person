using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFire : MonoBehaviour
{
    public GameObject Fire;
    private bool _isLit = false;


    public void FireLight()
    {
        if (!_isLit) 
        {
            Fire.SetActive(true);
            _isLit = true;
        }
        else
        {
            Fire.SetActive(false);
            _isLit = false;
        }
    }
}
