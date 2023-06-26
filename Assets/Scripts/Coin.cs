using UnityEngine;

public class coin : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      // Si el Player colisiona con moneda, CoinsManager actualiza el contador y la moneda desaparece
      if (other.gameObject.CompareTag("Player"))
      {
         CoinsManager.sharedInstance.UpdateCoins(); 
         Destroy(gameObject);
      }
   }
}
