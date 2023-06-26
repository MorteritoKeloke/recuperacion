using UnityEngine;

public class WinPlatform : MonoBehaviour
{
   // Win Panel se mostrará al entrar en contacto con la Win Platform
   [SerializeField] private GameObject winPanel;

   private void OnCollisionEnter(Collider other)
   {
      // Si el player colisiona con la win platform
      if (other.gameObject.CompareTag("Player"))
      {
         // Deshabilitamos el PlayerController
         other.gameObject.GetComponentInParent<PlayerController>().enabled = false;
         
         // Mostramos el panel de win
         winPanel.SetActive(true);
      }
   }
}
