using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PantallaButton : MonoBehaviour
{
    [SerializeField] private Button botonNumeros;
    [SerializeField] private string nombreEscenaMenu = "Numeros";

    private void Awake()
    {
        if (botonNumeros != null)
        {
            botonNumeros.onClick.AddListener(IrNumeros);
        }
    }

    private void OnDestroy()
    {
        if (botonNumeros != null)
        {
            botonNumeros.onClick.RemoveListener(IrNumeros);
        }
    }

    public void IrNumeros()
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
