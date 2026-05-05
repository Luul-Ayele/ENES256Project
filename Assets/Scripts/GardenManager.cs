using UnityEngine;
using System.Collections;
using TMPro; // 1. IMPORTANT: Add this to use TextMeshPro

public class GardenManager : MonoBehaviour
{
    public enum PlantType { Cabbage, Radish, Straw, Carrot }

    [Header("Patch Configuration")]
    public PlantType plantType;
    public int harvestValue = 24;
    public float respawnTime = 5.0f;

    [Header("UI Reference")]
    public TextMeshProUGUI countText; // 2. Drag your specific TMP text here

    [Header("Prefabs")]
    public GameObject plantPrefab;

    [Header("Locations")]
    public Transform[] plantLocations;

    private GameObject[] spawnedPlants;
    private bool isGrowing = false;

    void Start()
    {
        spawnedPlants = new GameObject[plantLocations.Length];
        SpawnInitialPlants();
        
        // Update the UI immediately on start so it doesn't show placeholder text
        UpdateUIText();
    }

    void SpawnInitialPlants()
    {
        for (int i = 0; i < plantLocations.Length; i++)
        {
            spawnedPlants[i] = Instantiate(plantPrefab, plantLocations[i].position, plantLocations[i].rotation, plantLocations[i]);
        }
    }

    public void HarvestAll()
    {
        if (!isGrowing && spawnedPlants[0].activeSelf)
        {
            foreach (GameObject plant in spawnedPlants)
            {
                plant.SetActive(false);
            }
            
            AddInventory();
            StartCoroutine(RespawnRoutine());
        }
    }

    void AddInventory()
    {
        string saveKey = "Saved" + plantType.ToString();
        int currentTotal = PlayerPrefs.GetInt(saveKey, 0);
        currentTotal += harvestValue;
        
        PlayerPrefs.SetInt(saveKey, currentTotal);
        PlayerPrefs.Save();

        // 3. Update the UI right after saving
        UpdateUIText();
    }

    // This helper function keeps the UI in sync with the save data
    void UpdateUIText()
    {
        if (countText != null)
            {
                string saveKey = "Saved" + plantType.ToString();
                int currentTotal = PlayerPrefs.GetInt(saveKey, 0);
                
                // This now ONLY shows the number
                countText.text = currentTotal.ToString();
            }
        
    }

    IEnumerator RespawnRoutine()
    {
        isGrowing = true;
        yield return new WaitForSeconds(respawnTime);
        
        foreach (GameObject plant in spawnedPlants)
        {
            plant.SetActive(true);
        }
        isGrowing = false;
    }
}