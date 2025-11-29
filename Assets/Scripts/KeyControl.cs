using UnityEngine;

public class KeyControl : MonoBehaviour
{
    // natural low octave
    [SerializeField] GameObject lowA;
    [SerializeField] GameObject lowB;
    [SerializeField] GameObject lowC;
    [SerializeField] GameObject lowD;
    [SerializeField] GameObject lowE;
    [SerializeField] GameObject lowF;
    [SerializeField] GameObject lowG;

    // natural up octave
    [SerializeField] GameObject upA;
    [SerializeField] GameObject upB;
    [SerializeField] GameObject upC;
    [SerializeField] GameObject upD;
    [SerializeField] GameObject upE;
    [SerializeField] GameObject upF;
    [SerializeField] GameObject upG;

    // sharps (s) - low octave
    [SerializeField] GameObject lowAs; // A#
    [SerializeField] GameObject lowCs; // C#
    [SerializeField] GameObject lowDs; // D#
    [SerializeField] GameObject lowFs; // F#
    [SerializeField] GameObject lowGs; // G#

    // sharps (s) - up octave
    [SerializeField] GameObject upAs; // A#
    [SerializeField] GameObject upCs; // C#
    [SerializeField] GameObject upDs; // D#
    [SerializeField] GameObject upFs; // F#
    [SerializeField] GameObject upGs; // G#

    void Update()
    {
        bool shift = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool ctrl = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);

        // handle each key (keycode, low natural, up natural, low sharp, up sharp)
        HandleKey(KeyCode.A, lowA, upA, lowAs, upAs, shift, ctrl);
        HandleKey(KeyCode.B, lowB, upB, null, null, shift, ctrl); // B has no sharp in your set
        HandleKey(KeyCode.C, lowC, upC, lowCs, upCs, shift, ctrl);
        HandleKey(KeyCode.D, lowD, upD, lowDs, upDs, shift, ctrl);
        HandleKey(KeyCode.E, lowE, upE, null, null, shift, ctrl); // E has no sharp in your set
        HandleKey(KeyCode.F, lowF, upF, lowFs, upFs, shift, ctrl);
        HandleKey(KeyCode.G, lowG, upG, lowGs, upGs, shift, ctrl);
    }

    void HandleKey(KeyCode key, GameObject lowNatural, GameObject upNatural,
                   GameObject lowSharp, GameObject upSharp, bool shift, bool ctrl)
    {
        if (!Input.GetKeyDown(key)) return;

        // ctrl + shift => up sharp
        if (ctrl && shift)
        {
            PlayGameObject(upSharp);
            return;
        }

        // ctrl only => low sharp
        if (ctrl)
        {
            PlayGameObject(lowSharp);
            return;
        }

        // shift only => up natural
        if (shift)
        {
            PlayGameObject(upNatural);
            return;
        }

        // no modifier => low natural
        PlayGameObject(lowNatural);
    }


    void PlayGameObject(GameObject g)
    {
        if (g == null) return; // nothing to play for this combination
        g.SetActive(false);
        g.SetActive(true);
    }

    public void LowPressC() { }
}
