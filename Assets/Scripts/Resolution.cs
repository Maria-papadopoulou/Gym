using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         Screen.SetResolution(1920, 1080,FullScreenMode.Windowed);
         print("res4");
    }
    public void Resolution1(){
        Screen.SetResolution(1366, 768,FullScreenMode.Windowed);
        print("res1");
    }
    public void Resolution2(){
        Screen.SetResolution(1600, 900,FullScreenMode.Windowed);
        print("res2");
    }
    public void Resolution3(){
        Screen.SetResolution(1920, 720,FullScreenMode.Windowed);
        print("res3");
    }
    public void Resolution4(){
        Screen.SetResolution(1920, 1080,FullScreenMode.Windowed);
        print("res4");
    }
    public void Resolution5(){
        Screen.SetResolution(1920, 1200,FullScreenMode.Windowed);
        print("res5");
    }
    public void Resolution6(){
        Screen.SetResolution(2560, 1440,FullScreenMode.Windowed);
        print("res6");
    }
    public void Resolution7(){
        Screen.SetResolution(2560, 1600,FullScreenMode.Windowed);
        print("res7");
    }
}
