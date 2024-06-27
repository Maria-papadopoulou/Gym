using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwap : MonoBehaviour
{
    public Canvas canvas1;
    public Canvas canvas2;

    public void ButtonClick() 
    {
        canvas1.enabled = false;
        canvas2.enabled = true;
    }

}
