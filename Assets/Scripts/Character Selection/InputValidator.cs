using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;
using System.IO;

public class InputValidator : MonoBehaviour
{
    public TMP_InputField heightField;
    public TMP_InputField weightField;
    public TMP_InputField muscleField;
    public TMP_InputField fatField;
    public TMP_Dropdown genderDropdown;
    public Button doneButton;

    private void Start()
    {
        doneButton.onClick.AddListener(OnDoneButtonClick);
    }

    private void OnDoneButtonClick()
    {
        if (AreFieldsFilled() && ValidateInputs())
        {
            SaveData();
            SaveDataToFile();
            // Uncomment if you want to load another scene after saving data
            LoadGameScene();
        }
        else
        {
            Debug.Log("Invalid input or empty fields. Please check your entries.");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private bool AreFieldsFilled()
    {
        if (string.IsNullOrEmpty(heightField.text) ||
            string.IsNullOrEmpty(weightField.text) ||
            string.IsNullOrEmpty(muscleField.text))
        {
            Debug.Log("One or more fields are empty");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            return false;
        }
        return true;
    }

    private bool ValidateInputs()
    {
        if (!IsValidNumber(heightField.text, out float height) || height < 1f || height > 2.3f)
        {
            Debug.Log("Invalid height. Please enter a number between 1.0 and 2.3 meters.");
            return false;
        }

        if (!IsValidNumber(weightField.text, out float weight) || weight < 40f || weight > 200f)
        {
            Debug.Log("Invalid weight. Please enter a number between 40 and 200 kilograms.");
            return false;
        }

        if (!IsValidNumber(muscleField.text, out float muscle) || muscle < 10f || muscle > 90f)
        {
            Debug.Log("Invalid muscle percentage. Please enter a number between 10 and 90.");
            return false;
        }

        if (string.IsNullOrEmpty(fatField.text))
        {
            // Calculate fat if not provided by the user
            float fat = 100f - muscle;
            if (fat < 10f || fat > 90f)
            {
                Debug.Log("Calculated fat percentage is out of valid range (10 - 90%).");
                return false;
            }
            fatField.text = fat.ToString("F2", CultureInfo.InvariantCulture); // Update UI with calculated fat
        }
        else
        {
            // Validate user-entered fat value
            if (!IsValidNumber(fatField.text, out float fat) || fat < 0f || fat > 90f || Mathf.Abs(muscle + fat - 100f) > 0.01f)
            {
                Debug.Log("Invalid fat percentage. Please enter a number between 0 and 90, ensuring that muscle + fat equals 100%.");
                return false;
            }
        }

        if (genderDropdown.value == 0)
        {
            Debug.Log("Invalid gender selection. Please choose a gender.");
            return false;
        }

        return true;
    }

    private bool IsValidNumber(string input, out float result)
    {
        // Try parsing the input as float using invariant culture
        return float.TryParse(input.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out result);
    }

    private void SaveData()
    {
        // Save data to PlayerPrefs
        PlayerPrefs.SetFloat("Height", float.Parse(heightField.text.Replace(',', '.'), CultureInfo.InvariantCulture));
        PlayerPrefs.SetFloat("Weight", float.Parse(weightField.text.Replace(',', '.'), CultureInfo.InvariantCulture));
        PlayerPrefs.SetFloat("Muscle", float.Parse(muscleField.text.Replace(',', '.'), CultureInfo.InvariantCulture));

        // If fatField is empty, calculate fat
        float fat;
        if (string.IsNullOrEmpty(fatField.text))
        {
            fat = 100f - float.Parse(muscleField.text.Replace(',', '.'), CultureInfo.InvariantCulture);
        }
        else
        {
            fat = float.Parse(fatField.text.Replace(',', '.'), CultureInfo.InvariantCulture);
        }

        PlayerPrefs.SetFloat("Fat", fat);
        PlayerPrefs.SetInt("Gender", genderDropdown.value);
        PlayerPrefs.SetFloat("Energy", 100);
        PlayerPrefs.SetFloat("PlayerCoins", 50);
        PlayerPrefs.Save();
    }

    private void SaveDataToFile()
    {
        // Prepare data to save in a text file
        string dataPath = Application.persistentDataPath + "/UserData.txt";
        string dateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        string data = $"Date and Time: {dateTime}\n" +
                      $"Height: {heightField.text}\n" +
                      $"Weight: {weightField.text}\n" +
                      $"Muscle: {muscleField.text}\n" +
                      $"Fat: {fatField.text}\n" +
                      $"Gender: {genderDropdown.options[genderDropdown.value].text}\n\n";

        // Append data to file
        File.AppendAllText(dataPath, data);
        Debug.Log($"Data saved to {dataPath}");
    }

    private void LoadGameScene()
    {
        // Load another scene if needed
        SceneManager.LoadScene("Game");
    }
}
