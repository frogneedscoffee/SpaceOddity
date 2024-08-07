using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSteps : MonoBehaviour
{
    public float gameTime;
    [SerializeField] private GameObject instructOne;
    [SerializeField] private GameObject instructTwo;
    [SerializeField] private GameObject instructThree;

    public void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime >= 5 && gameTime <= 10)
        {
            Time.timeScale = 0f;
            instructOne.SetActive(true);
            //mostrar texto con instrucciones (mov);
        }

        if (gameTime >= 20 && gameTime <= 25)
        {
            Time.timeScale = 0f;
            instructTwo.SetActive(true);
            //mostrar texto con instrucciones (disparo);
        }

        if (gameTime >= 30 && gameTime <= 35)
        {
            Time.timeScale = 0f;
            instructThree.SetActive(true);
            //mostrar texto con instrucciones (esquiva);
        }

        if (gameTime >= 50)
        {
            Time.timeScale = 0f;
        }

        else
        {
            Time.timeScale = 1.0f;
            instructOne.SetActive(false);
            instructTwo.SetActive(false);
            instructThree.SetActive(false);
            //seguimos juego;
        }
    }
}
