using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class Cemiterio : MonoBehaviour, IDropHandler
{
    public GameObject deck;
    public GameObject table;
    public GameObject cemiterio;

    int rosa = 0, verde = 0, roxo = 0, amarelo = 0, deusa = 0;
    int masc = 0, fem = 0;


    public void OnDrop(PointerEventData e)
    {
        Debug.Log("OnDrop to " + gameObject.name);

        Drag d = e.pointerDrag.GetComponent<Drag>();
        if (d != null)
        {
           d.currentParent = cemiterio.transform;
           table.GetComponent<Dropzone>().VerCarta(e);
           if (deck.transform.childCount > 0) deck.GetComponent<Saque>().Sacar();
           d.isDraggable = false;
        }
    }

    public void VerCarta(PointerEventData eventData)
    {
        Drag carta = eventData.pointerDrag.GetComponent<Drag>();

        if (eventData.pointerDrag.CompareTag("Rosa") && carta.simbolo == 1)
        {

            rosa += 1;
            masc += 1;

        }

        if (eventData.pointerDrag.CompareTag("Rosa") && carta.simbolo == 2)
        {

            rosa += 1;
            fem += 1;

        }

        if (eventData.pointerDrag.CompareTag("Verde") && carta.simbolo == 1)
        {

            verde += 1;
            masc += 1;

        }

        if (eventData.pointerDrag.CompareTag("Verde") && carta.simbolo == 2)
        {

            verde += 1;
            fem += 1;

        }


        if (eventData.pointerDrag.CompareTag("Roxo") && carta.simbolo == 1)
        {

            roxo += 1;
            masc += 1;

        }

        if (eventData.pointerDrag.CompareTag("Roxo") && carta.simbolo == 2)
        {

            roxo += 1;
            fem += 1;

        }

        if (eventData.pointerDrag.CompareTag("Amarelo") && carta.simbolo == 1)
        {

            amarelo += 1;
            masc += 1;

        }

        if (eventData.pointerDrag.CompareTag("Amarelo") && carta.simbolo == 2)
        {

            amarelo += 1;
            fem += 1;

        }

        if (eventData.pointerDrag.CompareTag("Deusa"))
        {

            deusa += 1;

        }


    }
}
