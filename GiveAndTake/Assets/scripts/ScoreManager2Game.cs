using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager2Game : MonoBehaviour
{
    int scorePlayer1 = 0;
    int scorePlayer2 = 0;
    public Text scoreTextPlayer1;
    public Text scoreTextPlayer2;
    public Text scoreTextWin1;
    public Text scoreTextWin2;
    public Text scoreTextLose1;
    public Text scoreTextLose2;
    public Text scoreTextDraw1;
    public Text scoreTextDraw2;
    public GameObject popUpWin1;
    public GameObject popUpWin2;
    public GameObject popUpLose1;
    public GameObject popUpLose2;
    public GameObject popUpDraw1;
    public GameObject popUpDraw2;
    public List<Cartao> cardsPlayer1Direita;
    public List<Cartao> cardsPlayer1Esquerda;
    public List<Cartao> cardsPlayer2Direita;
    public List<Cartao> cardsPlayer2Esquerda;
    public GameObject background;
    public AudioSource audioSource;
    public GameObject popUpTecnico;
    public GameObject bacgroundTecnico;
    public GameObject configurationsMenu;
    public TimeManager timeManager;

    public void Awake()
    {
        SetTimeEnabled();
    }
    private void Start()
    {
        SetTimeEnabled();

        showCards1Direita();

        showCards1Esquerda();

        showCards2Direita();

        showCards2Esquerda();

        configurationsMenu.SetActive(true);
        bacgroundTecnico.SetActive(false);
        popUpTecnico.SetActive(false);

        audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        UpdateScore();
    }

    public void showCards1Direita()
    {
        int randomIndex = Random.Range(0, cardsPlayer1Direita.Count);

        // Acessa o objeto na lista usando o índice aleatório.
        Cartao objectToToggle = cardsPlayer1Direita[randomIndex];

        // Ativa ou desativa o objeto selecionado.
        objectToToggle.gameObject.SetActive(!objectToToggle.gameObject.activeSelf);
        objectToToggle.itemSlot.gameObject.SetActive(!objectToToggle.itemSlot.gameObject.activeSelf);
        objectToToggle.itemSlot2.gameObject.SetActive(!objectToToggle.itemSlot2.gameObject.activeSelf);
        if (objectToToggle.itemSlot3 != null) objectToToggle.itemSlot3.gameObject.SetActive(!objectToToggle.itemSlot3.gameObject.activeSelf);

    }
    public void showCards1Esquerda()
    {
        int randomIndex = Random.Range(0, cardsPlayer1Esquerda.Count);

        // Acessa o objeto na lista usando o índice aleatório.
        Cartao objectToToggle = cardsPlayer1Esquerda[randomIndex];

        // Ativa ou desativa o objeto selecionado.
        objectToToggle.gameObject.SetActive(!objectToToggle.gameObject.activeSelf);
        objectToToggle.itemSlot.gameObject.SetActive(!objectToToggle.itemSlot.gameObject.activeSelf);
        objectToToggle.itemSlot2.gameObject.SetActive(!objectToToggle.itemSlot2.gameObject.activeSelf);
        if (objectToToggle.itemSlot3 != null) objectToToggle.itemSlot3.gameObject.SetActive(!objectToToggle.itemSlot3.gameObject.activeSelf);

    }

    public void showCards2Direita()
    {
        int randomIndex = Random.Range(0, cardsPlayer2Direita.Count);

        // Acessa o objeto na lista usando o índice aleatório.
        Cartao objectToToggle = cardsPlayer2Direita[randomIndex];

        // Ativa ou desativa o objeto selecionado.
        objectToToggle.gameObject.SetActive(!objectToToggle.gameObject.activeSelf);
        objectToToggle.itemSlot.gameObject.SetActive(!objectToToggle.itemSlot.gameObject.activeSelf);
        objectToToggle.itemSlot2.gameObject.SetActive(!objectToToggle.itemSlot2.gameObject.activeSelf);
        if (objectToToggle.itemSlot3 != null) objectToToggle.itemSlot3.gameObject.SetActive(!objectToToggle.itemSlot3.gameObject.activeSelf);
    }

    public void showCards2Esquerda()
    {
        int randomIndex = Random.Range(0, cardsPlayer2Esquerda.Count);

        // Acessa o objeto na lista usando o índice aleatório.
        Cartao objectToToggle = cardsPlayer2Esquerda[randomIndex];

        // Ativa ou desativa o objeto selecionado.
        objectToToggle.gameObject.SetActive(!objectToToggle.gameObject.activeSelf);
        objectToToggle.itemSlot.gameObject.SetActive(!objectToToggle.itemSlot.gameObject.activeSelf);
        objectToToggle.itemSlot2.gameObject.SetActive(!objectToToggle.itemSlot2.gameObject.activeSelf);
        if (objectToToggle.itemSlot3 != null) objectToToggle.itemSlot3.gameObject.SetActive(!objectToToggle.itemSlot3.gameObject.activeSelf);

    }

    private void UpdateScore()
    {

        float time = timeManager.RemainingTime;
        
        // Se o tempo acabou, voc� pode adicionar aqui a l�gica para terminar o jogo.
        if (time <= 0)
        {
            // Por exemplo:
            Time.timeScale = 0; // Pausa o jogo.

            audioSource.Play();

            background.SetActive(true);

            if (scorePlayer1 > scorePlayer2)
            {
                if (scorePlayer1 == 1)
                {

                    scoreTextWin1.text = "A tua equipa fez " + scorePlayer1.ToString() + " ponto";
                }
                else
                {
                    scoreTextWin1.text = "A tua equipa fez " + scorePlayer1.ToString() + " pontos";
                    
                }
                if (scorePlayer2 == 1)
                {

                    scoreTextLose2.text = "A tua equipa fez " + scorePlayer2.ToString() + " ponto";
                }
                else
                {
                    scoreTextLose2.text = "A tua equipa fez " + scorePlayer2.ToString() + " pontos";

                }
                popUpLose2.gameObject.SetActive(true);
                popUpWin1.gameObject.SetActive(true);

            }
            else if (scorePlayer1 < scorePlayer2)
            {

                if (scorePlayer1 == 1)
                {

                    scoreTextLose1.text = "A tua equipa fez " + scorePlayer1.ToString() + " ponto";
                }
                else
                {
                    scoreTextLose1.text = "A tua equipa fez " + scorePlayer1.ToString() + " pontos";

                }
                if (scorePlayer2 == 1)
                {

                    scoreTextWin2.text = "A tua equipa fez " + scorePlayer2.ToString() + " ponto";
                }
                else
                {
                    scoreTextWin2.text = "A tua equipa fez " + scorePlayer2.ToString() + " pontos";

                }

                popUpWin2.gameObject.SetActive(true);
                popUpLose1.gameObject.SetActive(true);

            }
            else
            {

                if (scorePlayer1 == 1)
                {

                    scoreTextDraw1.text = "A tua equipa fez " + scorePlayer1.ToString() + " ponto";
                }
                else
                {
                    scoreTextDraw1.text = "A tua equipa fez " + scorePlayer1.ToString() + " pontos";

                }
                if (scorePlayer2 == 1)
                {

                    scoreTextDraw2.text = "A tua equipa fez " + scorePlayer2.ToString() + " ponto";
                }
                else
                {
                    scoreTextDraw2.text = "A tua equipa fez " + scorePlayer2.ToString() + " pontos";

                }

                popUpDraw1.gameObject.SetActive(true);
                popUpDraw2.gameObject.SetActive(true);
            }
            
            configurationsMenu.SetActive(false);
            bacgroundTecnico.SetActive(true);
            popUpTecnico.SetActive(true);
        }
    }


    public void AddScorePlayer1()
    {
        scorePlayer1++;
        if (scorePlayer1 == 1)
        {

            scoreTextPlayer1.text = scorePlayer1.ToString() + " ponto";
        }
        else
        {
            scoreTextPlayer1.text = scorePlayer1.ToString() + " pontos";
        }

    }

    public void AddScorePlayer2()
    {
        scorePlayer2++;

        if (scorePlayer2 == 1)
        {

            scoreTextPlayer2.text = scorePlayer2.ToString() + " ponto";
        }
        else
        {
            scoreTextPlayer2.text = scorePlayer2.ToString() + " pontos";
        }

    }

    public void SetTimeEnabled(){
        PlayerPrefs.SetInt("TimeEnabled", 1);
        PlayerPrefs.Save();
    }
}
