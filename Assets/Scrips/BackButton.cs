using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [SerializeField] private Button backButton;

    private void Awake()
    {
        // Ensure the button triggers the scene rollback when pressed.
        if (backButton == null)
        {
            backButton = GetComponent<Button>();
        }

        if (backButton != null)
        {
            backButton.onClick.AddListener(LoadPreviousScene);
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
            backButton.onClick.RemoveListener(LoadPreviousScene);
        }
    }

    private void LoadPreviousScene()
    {
        var activeScene = SceneManager.GetActiveScene();
        int previousIndex = activeScene.buildIndex - 1;

        if (previousIndex >= 0)
        {
            SceneManager.LoadScene(previousIndex);
        }
        else
        {
            Debug.LogWarning("BackButton: No existe una escena anterior en Build Settings.");
        }
    }
}
