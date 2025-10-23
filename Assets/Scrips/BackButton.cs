using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private string menuSceneName = "Menu";

    private void Awake()
    {
        // Ensure the button loads the menu scene when pressed.
        if (backButton == null)
        {
            backButton = GetComponent<Button>();
        }

        if (backButton != null)
        {
            backButton.onClick.AddListener(LoadMenuScene);
        }
        else
        {
            Debug.LogWarning("BackButton: Asigna el Boton Back en el inspector.");
        }
    }

    private void OnDestroy()
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveListener(LoadMenuScene);
        }
    }

    private void LoadMenuScene()
    {
        if (string.IsNullOrEmpty(menuSceneName))
        {
            Debug.LogWarning("BackButton: El nombre de la escena de menu no esta configurado.");
            return;
        }

        if (Application.CanStreamedLevelBeLoaded(menuSceneName))
        {
            SceneManager.LoadScene(menuSceneName);
        }
        else
        {
            Debug.LogWarning($"BackButton: La escena \"{menuSceneName}\" no esta en Build Settings.");
        }
    }
}
