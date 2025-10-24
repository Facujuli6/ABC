using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pantalla1 : MonoBehaviour
{
    [SerializeField] private Button botonInicio;
    [SerializeField] private Button botonSalir;
    [SerializeField] private string nombreEscenaMenu = "Menu";

    private void Awake()
    {
        if (botonInicio != null)
        {
            botonInicio.onClick.AddListener(IrAlMenu);
        }
        if (botonSalir != null)
        {
            botonSalir.onClick.AddListener(SalirDelJuego);
        }
    }

    private void OnDestroy()
    {
        if (botonInicio != null)
        {
            botonInicio.onClick.RemoveListener(IrAlMenu);
        }
        if (botonSalir != null)
        {
            botonSalir.onClick.RemoveListener(SalirDelJuego);
        }
    }

    public void IrAlMenu()
    {
        if (!string.IsNullOrWhiteSpace(nombreEscenaMenu))
        {
            SceneManager.LoadScene(nombreEscenaMenu);
        }
        else
        {
            Debug.LogWarning("Pantalla1: nombreEscenaMenu está vacío, asigna el nombre de la escena del menú.");
        }
    }

    private void SalirDelJuego()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
