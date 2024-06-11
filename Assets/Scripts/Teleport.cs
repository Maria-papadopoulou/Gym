using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform tp;
    [SerializeField] GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Teleporter());
    }
    IEnumerator Teleporter()
    {
        yield return new WaitForSeconds(1);
        Player.transform.position = new Vector3(
            tp.transform.position.x,
            tp.transform.position.y,
            tp.transform.position.z
        );
    }
}
