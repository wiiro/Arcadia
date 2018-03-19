using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Saque : MonoBehaviour
{

    public Transform Children;
    public GameObject hand;
    public GameObject deck;
    public GameObject limbo;
    public GameObject cartaVilao;
    public GameObject cemiterio;
    public GameObject contador;
    public GameObject menuVilao;

    public void Start()
    {
       
        SaqueInicial();
        SaqueInicial();
        SaqueInicial();
        SaqueInicial();
        SaqueInicial();

    }

    public void SaqueInicial()
    {
    Start:
        if (this.transform.childCount > 0)
        {
            int n = Random.Range(0, this.transform.childCount);
            Children = this.transform.GetChild(n);
            if (Children.transform.CompareTag("Preto"))
            {
                Children.transform.SetParent(limbo.transform);
                goto Start;
            }
            Children.SetParent(hand.transform);
        }
            while (limbo.transform.childCount > 0)
            {
                Children = limbo.transform.GetChild(0);
                Children.transform.SetParent(deck.transform);
            }

        contador.GetComponent<Text>().text = ("" + deck.transform.childCount);
    }

    public void Sacar()
    {
        int n = Random.Range(0, this.transform.childCount);
        Children = this.transform.GetChild(n);

        if (Children.transform.CompareTag("Preto"))
        {
            Children.transform.SetParent(limbo.transform);
            menuVilao.SetActive(true);
        }
        else
        {
            Children.SetParent(hand.transform);
        }

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
