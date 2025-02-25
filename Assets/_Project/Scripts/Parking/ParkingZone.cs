using UnityEngine;

public class ParkingZone : MonoBehaviour
{
    public Renderer parkingRenderer;  // Assign the parking zone's mesh renderer
    public Material glowMaterial;    // Assign the glowing material
    private Material originalMaterial;

    private void Start()
    {
        if (parkingRenderer != null)
        {
            originalMaterial = parkingRenderer.material;  // Store original material
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && parkingRenderer != null)
        {
            parkingRenderer.material = glowMaterial;  // Change to glowing material
            Debug.Log("Parking zone is glowing!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && parkingRenderer != null)
        {
            parkingRenderer.material = originalMaterial;  // Restore original material
            Debug.Log("Parking zone glow turned off.");
        }
    }
}
