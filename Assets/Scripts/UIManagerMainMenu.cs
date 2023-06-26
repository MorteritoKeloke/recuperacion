using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerMainMenu : MonoBehaviour
{
    // UIManagerMainMenu es un singleton
    public static UIManagerMainMenu sharedInstance;
    
    [SerializeField] private GameObject instructionsPanel;

    // Configuramos que UIManagerMainMenu sea un singleton
    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Nos aseguramos de que al empezar el panel de instrucciones está oculto
        ShowInstructionsPanel();
    }

    // Función que se encarga de mostrar el Instructions Panel
    public void ShowInstructionsPanel()
    {
        instructionsPanel.SetActive(true);
    }

    // Función que se encarga de ocultar el Instructions Panel
    public void HideInstructionsPanel()
    {
        instructionsPanel.SetActive(false);
    }

}
