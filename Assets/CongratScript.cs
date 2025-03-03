using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh text;
    public ParticleSystem sparksParticles;

    private List<string> textToDisplay = new List<string>();

    //private float rotatingSpeed;
    private float timeToNextText;

    private int currentText;

    // Start is called before the first frame update
    void Start()
    {
        timeToNextText = 0.0f;
        currentText = 0;

        //rotatingSpeed = 1.0f;

        textToDisplay.Add("Congratulations!!!");
        textToDisplay.Add("All Errors Fixed!!!!");

        text.text = textToDisplay[0];

        sparksParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        timeToNextText += Time.deltaTime;

        if (timeToNextText >= 1.5f && currentText < textToDisplay.Count)
        {
            currentText++;
            timeToNextText = 0;
            StartCoroutine(Display());
        }
        if (currentText >= textToDisplay.Count)
        {
            currentText = 0;
            StartCoroutine(Display());
        }
    }

    private IEnumerator Display()
    {
        yield return new WaitForEndOfFrame();
        text.text = textToDisplay[currentText];
    }
}