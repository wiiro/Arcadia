using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescarteMao : MonoBehaviour {

    public GameObject hand;
    public GameObject deck;
    public GameObject cemiterio;
    public GameObject limbo;
    public GameObject contador;
    public Button botao;
    Transform Children;

    public void Start()
    {
        botao.onClick.AddListener(Descartar);
        
    }

    public void Descartar()
    {

        Children = limbo.transform.GetChild(0);
        Children.transform.SetParent(cemiterio.transform);

        while (hand.transform.childCount > 0)
        {
            Children = hand.transform.GetChild(0);
            Children.transform.SetParent(cemiterio.transform);
        }

        deck.GetComponent<Saque>().SaqueInicial();
        deck.GetComponent<Saque>().SaqueInicial();
        deck.GetComponent<Saque>().SaqueInicial();
        deck.GetComponent<Saque>().SaqueInicial();
        deck.GetComponent<Saque>().SaqueInicial();

        contador.GetComponent<Text>().text = ("" + deck.transform.childCount);
    }

    public bool VerificaViloes()
    {
        int numViloes = 0;
        for (int i = 0; i < deck.transform.childCount; i++)
        {
            Children = deck.transform.GetChild(i);
            if (Children.transform.CompareTag("Preto"))
            {
                numViloes++;
            }
        }
        if (numViloes == deck.transform.childCount)
            return true;
        else
            return false;
    }

}

