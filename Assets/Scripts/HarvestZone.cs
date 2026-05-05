using UnityEngine;

public class HarvestZone : MonoBehaviour
{
    public GardenManager gardenManager;

    // This runs even if the "Player" tag is wrong
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("!!! TRIGGER DETECTED !!! Interacted with: " + other.name);
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("Tag is correct. Sending command to GardenManager...");
            if (gardenManager != null)
            {
                gardenManager.HarvestAll();
            }
            else
            {
                Debug.LogError("GARDEN MANAGER IS MISSING FROM THE SLOT!");
            }
        }
        else
        {
            Debug.LogWarning("Object touched me, but its tag is: " + other.tag);
        }
    }
}