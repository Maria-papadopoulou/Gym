using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skymanager : MonoBehaviour
{
   public float skySpeed;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation",Time.time*skySpeed);
    }
}
