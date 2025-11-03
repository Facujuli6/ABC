using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pantalla1 : MonoBehaviour
{
    [SerializeField] private Button botonInicio;
    [SerializeField] private Button botonSalir;
    [SerializeField] private string nombreEscenaMenu = "Menu";
    [Header("Animacion de transicion")]
    [SerializeField] private bool usarAnimacionAntesDeCargar = false;
    [SerializeField] private Animator animadorTransicion;
    [SerializeField] private string triggerAnimacion = "Play";
    [SerializeField] private float tiempoEsperaAnimacion = 0.5f;
    [SerializeField] private bool deshabilitarBotonDuranteTransicion = true;

    private bool transicionEnCurso = false;

    private void Awake()
    {
        if (botonInicio != null)
        {
            botonInicio.onClick.AddListener(ManejarInicio);
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
            botonInicio.onClick.RemoveListener(ManejarInicio);
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
            Debug.LogWarning("Pantalla1: nombreEscenaMenu esta vacio, asigna el nombre de la escena del menu.");
        }
    }

    private void SalirDelJuego()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private void ManejarInicio()
    {
        if (transicionEnCurso)
        {
            return;
        }

        if (usarAnimacionAntesDeCargar && animadorTransicion != null)
        {
            StartCoroutine(ReproducirAnimacionYCargar());
            return;
        }

        if (usarAnimacionAntesDeCargar && animadorTransicion == null)
        {
            Debug.LogWarning("Pantalla1: No se ha asignado un Animator para la transicion, se cargara la escena inmediatamente.");
        }

        IrAlMenu();
    }

    private IEnumerator ReproducirAnimacionYCargar()
    {
        transicionEnCurso = true;

        if (deshabilitarBotonDuranteTransicion && botonInicio != null)
        {
            botonInicio.interactable = false;
        }

        if (!string.IsNullOrEmpty(triggerAnimacion))
        {
            animadorTransicion.ResetTrigger(triggerAnimacion);
            animadorTransicion.SetTrigger(triggerAnimacion);
        }
        else
        {
            animadorTransicion.Play(0, 0, 0f);
        }

        float espera = Mathf.Max(0f, tiempoEsperaAnimacion);
        if (espera > 0f)
        {
            yield return new WaitForSeconds(espera);
        }
        else
        {
            yield return null;
        }

        IrAlMenu();
    }
}
