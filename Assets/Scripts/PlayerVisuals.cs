using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    public const string playerShape;
    public const string playerColor;
    
    /*
    * PLAYER SHAPE
    * 0: sphere
    * 1: cube
    * 2: capsule
    */
    private int playerShape;

    /*
    * PLAYER COLOR
    * 0: red
    * 1: green
    * 2: blue
    */
    private int playerColor;
    [SerializeField] private Material playerMaterial;

    private void Start()
    {
        SetPlayerShape();
        SetPlayerColor();
    }

    public void SetPlayerShape()
    {
        // Configuramos la forma del player
        if (PlayerPrefs.HasKey(playerShape))
        {
            playerShape = PlayerPrefs.GetInt(playerShape);
        }
        else
        {
            // Si no hay valores guardados, por defecto mostramos el cubo
            playerShape = 1;
        }
        
        // Dejamos activo el único hijo que coincide con la variable playerShape
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == playerShape);
        }
    }
    
    public void SetPlayerColor()
    {
        // Configuramos el color del player
        if (PlayerPrefs.HasKey(playerColor))
        {
            playerColor = PlayerPrefs.GetInt(playerColor);
        }
        else
        {
            // Si no hay valores guardados, por defecto mostramos el color verde
            playerColor = 1;
        }

        PlayerMaterial.color = DataPersistence.sharedInstance.playerColors[playerColor];
    }
}
