using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pantalla1 : MonoBehaviour
{
    [SerializeField] private Button botonInicio;
    [SerializeField] private string nombreEscenaMenu = "Menu";

    private void Awake()
    {
        if (botonInicio != null)
        {
            botonInicio.onClick.AddListener(IrAlMenu);
        }
    }

    private void OnDestroy()
    {
        if (botonInicio != null)
        {
            botonInicio.onClick.RemoveListener(IrAlMenu);
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
}
