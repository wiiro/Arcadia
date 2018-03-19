using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescarteDeck : MonoBehaviour
{

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
        int i = 0;

        Children = limbo.transform.GetChild(0);
        Children.transform.SetParent(cemiterio.transform);

        Start:
        bool ver = VerificaViloes();
        while (i < 5)
            {
            if (deck.transform.childCount == 0 || ver == true) break;
            int n = Random.Range(0, deck.transform.childCount);
            Debug.Log("" + n);
            Children = deck.transform.GetChild(n);
            if (Children.transform.tag == "Preto")
                {
                    Children.transform.SetParent(limbo.transform);
                    goto Start;
                }
            Children.SetParent(cemiterio.transform);
            i++;
            Debug.Log("" + deck.transform.childCount);
            if (deck.transform.childCount == 0) goto End;
        }
        contador.GetComponent<Text>().text = ("" + deck.transform.childCount);
    End:
        while (limbo.transform.childCount > 0)
        {
            Children = limbo.transform.GetChild(0);
            Children.transform.SetParent(deck.transform);
            contador.GetComponent<Text>().text = ("" + deck.transform.childCount);
        }

        if(deck.transform.childCount > 0)deck.GetComponent<Saque>().SaqueInicial();
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
