using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    void Start()
    {
        Res();
    }

    public void Res()
    {
        int width = 576;
        int height = 1024;
        
        Screen.SetResolution(width,height,false);
    }
}
