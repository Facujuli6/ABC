using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PantallaAnimals : MonoBehaviour
{
    [SerializeField] private Button botonAnimals;
    [SerializeField] private string nombreEscenaMenu = "Animales";

    private void Awake()
    {
        if (botonAnimals != null)
        {
            botonAnimals.onClick.AddListener(IrAnimales);
        }
    }

    private void OnDestroy()
    {
        if (botonAnimals != null)
        {
            botonAnimals.onClick.RemoveListener(IrAnimales);
        }
    }

    public void IrAnimales()
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
