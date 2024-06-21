using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDietitian : MonoBehaviour
{
    [SerializeField] private Vector3 teleportPosition = new Vector3(-3.92f, 3.3f, -7.21f);
    [SerializeField] private GameObject player;

    public void TeleportPlayer()
    {
        StartCoroutine(Teleporter());
    }

    IEnumerator Teleporter()
    {
        yield return new WaitForSeconds(1);
        player.transform.position = teleportPosition;
        
    }
}
