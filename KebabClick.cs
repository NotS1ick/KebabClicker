using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KebabClick : MonoBehaviour
{   
    public GameObject Kebab;
    public GameObject TimesPressedLog;
    private ParticleSystem particleSystem;
    public static float timesPressed = 0;

    void Start() {
        particleSystem = GetComponent<ParticleSystem>();
        DisableParticles();
        timesPressed--;
        TimesPressed();
    }

    void TimesPressed() {
        timesPressed++;
        TimesPressedLog.GetComponent<TextMeshProUGUI>().text = timesPressed.ToString();
    }

    public void UpdateUi()
    { 
        TimesPressedLog.GetComponent<TextMeshProUGUI>().text = timesPressed.ToString(); 
    }

    void DisableParticles()
    {
        if (particleSystem != null)
        {
            particleSystem.Stop();
        }
    }

    void EnableParticles()
    {
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
    }

    void OnMouseDown() {
        Debug.Log("Button Is pressed");
        if (!Pause.isPaused) {
            Kebab.transform.localScale = new Vector3(0.38f, 0.38f);
            EnableParticles();
            TimesPressed();
        } 
    }

    void OnMouseUp() {
        Debug.Log("The Mouse is up");
        Kebab.transform.localScale = new Vector3(0.4f, 0.4f);
        DisableParticles();
    }
}
