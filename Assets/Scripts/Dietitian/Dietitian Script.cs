using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class DietitianScript : MonoBehaviour
{
    [SerializeField] Transform tp;
    [SerializeField] GameObject Player;
    private float coins;

    private void Start()
    {
        // Load the saved coins from PlayerPrefs
        if (PlayerPrefs.HasKey("PlayerCoins"))
        {
            coins = PlayerPrefs.GetFloat("PlayerCoins");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (coins >= 10)
        {
            StartCoroutine(Teleporter());
        }
        else
        {
            Debug.Log("Not enough coins to teleport!");
        }
    }

    IEnumerator Teleporter()
    {
        yield return new WaitForSeconds(1);
        Player.transform.position = new Vector3(
            tp.transform.position.x,
            tp.transform.position.y,
            tp.transform.position.z
        );
        // Subtract 10 coins after teleporting
        coins -= 10;
        PlayerPrefs.SetFloat("PlayerCoins", coins);
        PlayerPrefs.Save();

        // Prepare data to save in a text file
            string dataPath = Application.persistentDataPath + "/UserData.txt";
            string dateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            string data = $"Date and Time: {dateTime}\n" +
                        $"Dieititian:\n"+
                        $"Coins: {PlayerPrefs.GetFloat("PlayerCoins")}\n";

        // Append data to file
        File.AppendAllText(dataPath, data);
    }
}
