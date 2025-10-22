using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PantallaAbc : MonoBehaviour
{
    [SerializeField] private Button botonAbc;
    [SerializeField] private string nombreEscenaMenu = "Abecedario";

    private void Awake()
    {
        if (botonAbc != null)
        {
            botonAbc.onClick.AddListener(IrAlAbecedario);
        }
    }

    private void OnDestroy()
    {
        if (botonAbc != null)
        {
            botonAbc.onClick.RemoveListener(IrAlAbecedario);
        }
    }

    public void IrAlAbecedario()
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
