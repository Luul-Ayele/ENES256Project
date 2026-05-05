using UnityEngine;
using TMPro;

public class MarketZone : MonoBehaviour
{
    public enum PlantType { Cabbage, Radish, Straw, Carrot }

    [Header("Market Settings")]
    public PlantType fruitToSell;      
    public int pricePerUnit = 2;       

    [Header("UI References (Number Only)")]
    public TextMeshProUGUI coinNumberText;   // Drag the Text that only holds the coin number
    public TextMeshProUGUI plantNumberText;  // Drag the Text that only holds the plant number


    void Start()
    {
        // Ensure the Coin Text shows the saved amount immediately on startup
        UpdateCoinDisplay();
        
        // Ensure the Fruit Text shows the saved amount immediately on startup
        UpdatePlantDisplay();
    }

    void UpdateCoinDisplay()
    {
        if (coinNumberText != null)
        {
            int currentCoins = PlayerPrefs.GetInt("TotalCoins", 0);
            coinNumberText.text = currentCoins.ToString();
        }
    }

    void UpdatePlantDisplay()
    {
        if (plantNumberText != null)
        {
            string plantKey = "Saved" + fruitToSell.ToString();
            int amountOwned = PlayerPrefs.GetInt(plantKey, 0);
            plantNumberText.text = amountOwned.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SellPlants();
        }
    }

    void SellPlants()
    {
        string plantKey = "Saved" + fruitToSell.ToString();
        int amountOwned = PlayerPrefs.GetInt(plantKey, 0);

        if (amountOwned > 0)
        {
            int profit = amountOwned * pricePerUnit;

            int currentCoins = PlayerPrefs.GetInt("TotalCoins", 0);
            currentCoins += profit;
            PlayerPrefs.SetInt("TotalCoins", currentCoins);

            // Reset this specific plant to zero
            PlayerPrefs.SetInt(plantKey, 0);
            PlayerPrefs.Save();

            UpdateUI(currentCoins);
        }
    }

    void UpdateUI(int coins)
    {
        // We set the text to just the number string
        if (coinNumberText != null) coinNumberText.text = coins.ToString();
        if (plantNumberText != null) plantNumberText.text = "0";
    }
}