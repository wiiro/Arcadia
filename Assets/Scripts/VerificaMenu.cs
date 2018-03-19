using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

public class VerificaMenu : MonoBehaviour {
    public GameObject hand;
    public GameObject deck;
    public GameObject botaoDeusa;
    public GameObject botaoDeck;
    public Transform Children;
    bool ver;

    // Update is called once per frame
    void Update () {

        ver = VerificaViloes();

        if(ver == true) {
            botaoDeck.GetComponent<Button>().interactable = false;
        }else
        {
            botaoDeck.GetComponent<Button>().interactable = true;
        }

        for (int i = 0; i < hand.transform.childCount; i++)
        {
            Children = hand.transform.GetChild(i);
            if (Children.transform.CompareTag("Deusa") == true)
            {
                botaoDeusa.GetComponent<Button>().interactable = true;
                break;
            }
            else
            {
                botaoDeusa.GetComponent<Button>().interactable = false;
            }
        }
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
