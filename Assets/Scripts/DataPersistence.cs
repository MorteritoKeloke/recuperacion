using UnityEngine;

public class DataPersistence : MonoBehaviour
{
    // DataPersistence es un singleton
    public static DataPersistence sharedInstance;
    private Color[] playerColors;
    
    // Configuramos que DataPersistence sea un singleton
    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
            
            // Necesitamos no destruir DataPersistence entre escenas para que la información no se pierda
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
