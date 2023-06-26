using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFlow : MonoBehaviour
{
    // BUILD INDEX:
    // * 0: Main Menu
    // * 1: Movement
    // * 2: Options
    // * 3: Animations
    public void ChangeScene(int sceneIndex)
    {
        // Cambiamos a la escena indicada por parámetro
        SceneManager.LoadScene(sceneIndex);
    }
}