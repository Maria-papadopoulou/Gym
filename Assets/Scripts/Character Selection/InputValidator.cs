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
            //LoadGameScene();
        }
        else
        {
            Debug.Log("Invalid input or empty fields. Please check your entries.");
        }
    }

    private bool AreFieldsFilled()
    {
        if (string.IsNullOrEmpty(heightField.text) ||
            string.IsNullOrEmpty(weightField.text) ||
            string.IsNullOrEmpty(muscleField.text) ||
            genderDropdown.value == 0)
        {
            Debug.Log("One or more fields are empty");
            return false;
        }
        return true;
    }

    private bool ValidateInputs()
    {
        if (!IsValidNumber(heightField.text, out float height) || height < 1f || height > 2.3f)
        {
            Debug.Log("Invalid height");
            return false;
        }

        if (!IsValidNumber(weightField.text, out float weight) || weight < 40f || weight > 200f)
        {
            Debug.Log("Invalid weight");
            return false;
        }

        if (!IsValidNumber(muscleField.text, out float muscle) || muscle < 10f || muscle > 90f)
        {
            Debug.Log("Invalid muscle percentage");
            return false;
        }

        if (string.IsNullOrEmpty(fatField.text))
        {
            // Calculate fat if the field is empty
            float fat = 100f - muscle;
            if (fat < 10f || fat > 90f)
            {
                Debug.Log("Calculated fat percentage out of valid range");
                return false;
            }
            fatField.text = fat.ToString("F2", CultureInfo.InvariantCulture); // Update the UI with calculated fat
        }
        else
        {
            // Validate user-entered fat value
            if (!IsValidNumber(fatField.text, out float fat) || fat < 0f || fat > 90f || Mathf.Abs(muscle + fat - 100f) > 0.01f)
            {
                Debug.Log("Invalid fat percentage or sum of muscle and fat does not equal 100%");
                return false;
            }
        }

        if (genderDropdown.value == 0)
        {
            Debug.Log("Invalid gender selection");
            return false;
        }

        return true;
    }

    private bool IsValidNumber(string input, out float result)
    {
        input = input.Replace(',', '.'); // Replace comma with dot
        return float.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out result);
    }

    private void SaveData()
    {
        PlayerPrefs.SetFloat("Height", float.Parse(heightField.text.Replace(',', '.')));
        PlayerPrefs.SetFloat("Weight", float.Parse(weightField.text.Replace(',', '.')));
        PlayerPrefs.SetFloat("Muscle", float.Parse(muscleField.text.Replace(',', '.')));
        PlayerPrefs.SetFloat("Fat", float.Parse(fatField.text.Replace(',', '.')));
        PlayerPrefs.SetInt("Gender", genderDropdown.value);
    }

    private void SaveDataToFile()
    {
        string dataPath = Application.persistentDataPath + "/UserData.txt";
        string dateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        string data = $"Date and Time: {dateTime}\n" +
                      $"Height: {heightField.text}\n" +
                      $"Weight: {weightField.text}\n" +
                      $"Muscle: {muscleField.text}\n" +
                      $"Fat: {fatField.text}\n" +
                      $"Gender: {genderDropdown.options[genderDropdown.value].text}\n\n";

        File.AppendAllText(dataPath, data);
        Debug.Log($"Data saved to {dataPath}");
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
}
