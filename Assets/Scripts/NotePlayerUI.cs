using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class NotePlayerUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public AudioClip clip;
    public float pressScale = 0.95f;
    public float pressAlpha = 0.85f; // optional fade for visual feedback

    AudioSource audioSource;
    RectTransform rt;
    Image image;
    Vector3 originalScale;
    Color originalColor;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rt = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        originalScale = rt.localScale;
        if (image) originalColor = image.color;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Play();
        PressVisual(true);
        // You can use eventData.pointerId if you want to track finger -> key mapping
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PressVisual(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // In case finger drags off
        PressVisual(false);
    }

    void Play()
    {
        if (clip == null || audioSource == null) return;
        audioSource.PlayOneShot(clip);
    }

    void PressVisual(bool down)
    {
        if (rt)
            rt.localScale = down ? originalScale * pressScale : originalScale;
        if (image)
            image.color = down ? new Color(originalColor.r, originalColor.g, originalColor.b, pressAlpha) : originalColor;
    }
}
