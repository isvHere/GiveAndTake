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
    int time = 120;
    public Text Timer1;
    public Text Timer2;
    public List<Cartao> cardsPlayer1Direita;
    public List<Cartao> cardsPlayer1Esquerda;
    public List<Cartao> cardsPlayer2Direita;
    public List<Cartao> cardsPlayer2Esquerda;

    private void Start()
    {
        showCards1Direita();

        showCards1Esquerda();

        showCards2Direita();

        showCards2Esquerda();

        InvokeRepeating("UpdateTimer", 1f, 1f);
    }

    public void showCards1Direita()
    {
        int randomIndex = Random.Range(0, cardsPlayer1Direita.Count);

        // Acessa o objeto na lista usando o �ndice aleat�rio.
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

        // Acessa o objeto na lista usando o �ndice aleat�rio.
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

        // Acessa o objeto na lista usando o �ndice aleat�rio.
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

        // Acessa o objeto na lista usando o �ndice aleat�rio.
        Cartao objectToToggle = cardsPlayer2Esquerda[randomIndex];

        // Ativa ou desativa o objeto selecionado.
        objectToToggle.gameObject.SetActive(!objectToToggle.gameObject.activeSelf);
        objectToToggle.itemSlot.gameObject.SetActive(!objectToToggle.itemSlot.gameObject.activeSelf);
        objectToToggle.itemSlot2.gameObject.SetActive(!objectToToggle.itemSlot2.gameObject.activeSelf);
        if (objectToToggle.itemSlot3 != null) objectToToggle.itemSlot3.gameObject.SetActive(!objectToToggle.itemSlot3.gameObject.activeSelf);

    }

    private void UpdateTimer()
    {
        // Decrementa o tempo restante.
        time--;

        // Atualiza os textos dos temporizadores.
        Timer1.text = time.ToString() + " segundos";
        Timer2.text = time.ToString() + " segundos";

        // Se o tempo acabou, voc� pode adicionar aqui a l�gica para terminar o jogo.
        if (time <= 0)
        {
            // Por exemplo:
            // Time.timeScale = 0; // Pausa o jogo.
        }
    }


    public void AddScorePlayer1()
    {
        scorePlayer1++;
        scoreTextPlayer1.text = scorePlayer1.ToString();
    }

    public void AddScorePlayer2()
    {
        scorePlayer2++;
        scoreTextPlayer2.text = scorePlayer2.ToString();
    }
}
