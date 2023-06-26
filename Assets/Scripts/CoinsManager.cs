using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    // CoinsManager es un singleton
    public static CoinsManager sharedInstance;
    
    private int coins; // monedas que llevamos recogidas
    private int totalCoins; // total de monedas
    
    private AudioSource audioSource;

    // Game Object Win Platform que aparece cuando recogemos todas las monedas
    [SerializeField] private GameObject winPlatform;
    
    private void Awake()
    {
        // Configuramos que CoinsManager sea un singleton
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Cogemos la referencia del AudioSource del Player
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        // Nos aseguramos de que la Win Platform está desactivada por defecto
        winPlatform.SetActive(false);
        
        // Calculamos el total de monedas en escena
        GetTotalCoins();
    }

    public void UpdateCoins()
    {
        // Sumamos una moneda
        coins++; 
        
        // Actualizamos la UI del contador de monedas que llevamos recogidas
        UIManager.sharedInstance.SetCoinsText(coins); 
        
        // Hacemos que suene un SFX al recoger la moneda
        audioSource.PlayOneShot(audioSource.clip);

        // Si hemos recogido todas las monedas, mostramos la Win Platform
        if (coins >= totalCoins)
        {
            winPlatform.SetActive(true);
        }
    }
    
    private void GetTotalCoins()
    {
        // Calculamos el total de monedas buscando todos los Game Objects que tienen la componente Coin
        totalCoins = FindObjectsOfType<Coin>().Length;
        
        // Actualizamos la UI para que el total de monedas se muestre una vez calculado
        UIManager.sharedInstance.SetTotalCoinsText(totalCoins);
    }
}
