using UnityEngine;

public class FloorLimits : MonoBehaviour
{
   // =========================================================================================================
   // Este script se encarga de los límites de movimiento en función de la plataforma en la que nos encontramos
   // NO TIENE ERRORES
   // =========================================================================================================
   
   // Límites izquierdo, derecho, frontal y trasero para cada plataforma (se configuran por inspector)
   [SerializeField] private float leftLimit, rightLimit, forwardLimit, backLimit;
   
   // Cada vez que colisionamos con una plataforma, se modifican los límites
   private void OnCollisionEnter(Collision other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         other.gameObject.GetComponentInParent<PlayerController>().
            ChangeMovementLimits(leftLimit, rightLimit, forwardLimit, backLimit);
      }
   }
}
