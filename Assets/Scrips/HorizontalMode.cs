using UnityEngine;

public class HorizontalMode : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Permite girar la pantalla a Landscape Right si el dispositivo se inclina.")]
    private bool allowUpsideLandscape = true;

    private ScreenOrientation previousOrientation;
    private bool previousPortrait;
    private bool previousPortraitUpsideDown;
    private bool previousLandscapeLeft;
    private bool previousLandscapeRight;
    private bool orientationForced;

    private void OnEnable()
    {
        CacheCurrentOrientation();
        ForceHorizontalLayout();
    }

    private void OnDisable()
    {
        RestorePreviousOrientation();
    }

    private void OnDestroy()
    {
        RestorePreviousOrientation();
    }

    private void CacheCurrentOrientation()
    {
        previousOrientation = Screen.orientation;
        previousPortrait = Screen.autorotateToPortrait;
        previousPortraitUpsideDown = Screen.autorotateToPortraitUpsideDown;
        previousLandscapeLeft = Screen.autorotateToLandscapeLeft;
        previousLandscapeRight = Screen.autorotateToLandscapeRight;
    }

    private void ForceHorizontalLayout()
    {
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = allowUpsideLandscape;

        Screen.orientation = ScreenOrientation.LandscapeLeft;
        if (allowUpsideLandscape)
        {
            Screen.orientation = ScreenOrientation.AutoRotation;
        }

        orientationForced = true;
    }

    private void RestorePreviousOrientation()
    {
        if (!orientationForced)
        {
            return;
        }

        Screen.autorotateToPortrait = previousPortrait;
        Screen.autorotateToPortraitUpsideDown = previousPortraitUpsideDown;
        Screen.autorotateToLandscapeLeft = previousLandscapeLeft;
        Screen.autorotateToLandscapeRight = previousLandscapeRight;
        Screen.orientation = previousOrientation;

        orientationForced = false;
    }
}
