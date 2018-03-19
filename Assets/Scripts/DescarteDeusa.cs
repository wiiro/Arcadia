using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DescarteDeusa : MonoBehaviour {

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
    private void Update()
    {

    }

    public void Descartar()
    {
        Children = limbo.transform.GetChild(0);
        Children.transform.SetParent(cemiterio.transform);

        for (int i = 0; i < hand.transform.childCount; i++)
        {
            Children = hand.transform.GetChild(i);
			if (Children.transform.CompareTag ("Deusa") == true) {
				Children.transform.SetParent (cemiterio.transform);
				goto End; 
			}
        }

        End:
        deck.GetComponent<Saque>().SaqueInicial();
        deck.GetComponent<Saque>().SaqueInicial();
        contador.GetComponent<Text>().text = ("" + deck.transform.childCount);


    }
}
