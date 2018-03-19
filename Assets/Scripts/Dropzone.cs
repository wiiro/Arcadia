using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class Dropzone : MonoBehaviour, IDropHandler
{

    Transform limpaMesa;

    public GameObject cemiterio;
    public GameObject imgBorda, imgCiclo, imgArq;
    public GameObject deck, hand;
    public GameObject telaVitoria, telaDerrota, telaSair;

    public Sprite imgAbom, imgAssas, imgBruxa, imgGuer, imgGolem, imgPet, imgFada;
    public Sprite imgShanoa, imgAmaterasu, imgEllie, imgFaith, imgJill, imgLaraCroft, imgLightning, imgNova, imgPoppy, imgRed, imgSamus, imgTracer;
    public Sprite orb1Img, orb2Img, orb3Img, orb4Img, orb5Img, orb6Img, orb7Img, orb8Img;
    public Sprite checkmark;

    public GameObject cartaFicha1, cartaFicha2, cartaFicha3, cartaFicha4, cartaFicha5, cartaFicha6, cartaFicha7, cartaFicha8;

    public Sprite textoCiclo1, textoCiclo2, textoCiclo3, textoCiclo4, textoCiclo5, textoCiclo6, textoCiclo7, textoCiclo8;
    public Sprite textoMentor, textoGuardiao, textoCamaleao, textoSombra, textoArauto, textoPicaro, textoTercMasc, textoHeroina;
    public Text CaixaArquetipo;

    public int input = 0;
    int rosa = 0, verde = 0, roxo = 0, amarelo = 0, deusa = 0;
    int masc = 0, fem = 0;
    bool[] Ciclos = new bool[8];
    string[] Tipos = new string[8];
    public string corCiclo = "";
    int ciclo = 0;
    bool win = false, lose = false, menu = false;

    public void Start()
    { 
    }

    public void Update()
    {
        
        if (Input.GetKeyDown("escape"))
        {
            if(menu == false)
            {
                telaSair.SetActive(true);
                menu = true;
            }
            else
            {
                telaSair.SetActive(false);
                menu = false;
            }         
        }

        if(this.transform.childCount > 13)
        {
            limpaMesa = this.transform.GetChild(0);
            limpaMesa.SetParent(cemiterio.transform);
        }

        if(win == true)
        {
            telaVitoria.SetActive(true);
        }

        if(hand.transform.childCount == 0)
        {
            lose = true;
        }


        if(lose == true)
        {
            telaDerrota.SetActive(true);
        }
    }

    public void OnDrop(PointerEventData e)
    {
        Debug.Log("OnDrop to " + gameObject.name);

        Drag d = e.pointerDrag.GetComponent<Drag>();
        if (d != null)
        {
            if (input == 0 && d.tag != "Deusa")
            {
                d.currentParent = this.transform;
                defineBorda(e);
                VerCarta(e);
                corCiclo = d.tag;
                input++;
                if (deck.transform.childCount > 0) deck.GetComponent<Saque>().Sacar();
                d.isDraggable = false;
            }else if (input < 3 && input > 0)
            {
                Transform ultimaCarta = this.transform.GetChild(this.transform.childCount - 1);
                if ((d.simbolo != ultimaCarta.GetComponent<Drag>().simbolo && d.CompareTag(corCiclo)) || d.CompareTag("Deusa") && ultimaCarta.tag != "Deusa")
                {
                    d.currentParent = this.transform;
                    VerCarta(e);
                    input++;
                    if (deck.transform.childCount > 0) deck.GetComponent<Saque>().Sacar();
                    d.isDraggable = false;
                }
            }

            if (input == 3)
                {
                    Ciclos[ciclo] = true;
                    GameObject img = GameObject.Find("Orb"+ (ciclo+1));
                if (ciclo == 0) {
                    img.GetComponent<Image>().sprite = orb1Img;
                    cartaFicha1.GetComponent<Image>().sprite = imgBorda.GetComponent<Image>().sprite;
                    imgCiclo.GetComponent<Image>().sprite = textoCiclo2;
                    imgArq.GetComponent<Image>().sprite = textoGuardiao;
                }
                if (ciclo == 1) {
                    img.GetComponent<Image>().sprite = orb2Img;
                    cartaFicha2.GetComponent<Image>().sprite = imgBorda.GetComponent<Image>().sprite;
                    imgCiclo.GetComponent<Image>().sprite = textoCiclo3;
                    imgArq.GetComponent<Image>().sprite = textoCamaleao;
                }
                if (ciclo == 2)
                {
                    img.GetComponent<Image>().sprite = orb3Img;
                    cartaFicha3.GetComponent<Image>().sprite = imgBorda.GetComponent<Image>().sprite;
                    imgCiclo.GetComponent<Image>().sprite = textoCiclo4;
                    imgArq.GetComponent<Image>().sprite = textoSombra;
                }
                if (ciclo == 3)
                {
                    img.GetComponent<Image>().sprite = orb4Img;
                    cartaFicha4.GetComponent<Image>().sprite = imgBorda.GetComponent<Image>().sprite;
                    imgCiclo.GetComponent<Image>().sprite = textoCiclo5;
                    imgArq.GetComponent<Image>().sprite = textoArauto;
                }
                if (ciclo == 4)
                {
                    img.GetComponent<Image>().sprite = orb5Img;
                    cartaFicha5.GetComponent<Image>().sprite = imgBorda.GetComponent<Image>().sprite;
                    imgCiclo.GetComponent<Image>().sprite = textoCiclo6;
                    imgArq.GetComponent<Image>().sprite = textoPicaro;
                }
                if (ciclo == 5)
                {
                    img.GetComponent<Image>().sprite = orb6Img;
                    cartaFicha6.GetComponent<Image>().sprite = imgBorda.GetComponent<Image>().sprite;
                    imgCiclo.GetComponent<Image>().sprite = textoCiclo7;
                    imgArq.GetComponent<Image>().sprite = textoTercMasc;
                }
                if (ciclo == 6)
                {
                    img.GetComponent<Image>().sprite = orb7Img;
                    cartaFicha7.GetComponent<Image>().sprite = imgBorda.GetComponent<Image>().sprite;
                    imgCiclo.GetComponent<Image>().sprite = textoCiclo8;
                    imgArq.GetComponent<Image>().sprite = textoHeroina;
                }
                    if (ciclo == 7){
                    img.GetComponent<Image>().sprite = orb8Img;

                    win = true;
                }

                    ciclo ++;
                    input = 0;
                    corCiclo = "";
                }
            
        }

        


    }

    public void defineBorda(PointerEventData eventData)
    {
        Drag carta = eventData.pointerDrag.GetComponent<Drag>();

        if (carta.name == "Abominacao") {imgBorda.GetComponent<Image>().sprite = imgAbom; Tipos[ciclo] = carta.name; }
        if (carta.name == "Assassino") { imgBorda.GetComponent<Image>().sprite = imgAssas; Tipos[ciclo] = carta.name; }
        if (carta.name == "Bruxa") { imgBorda.GetComponent<Image>().sprite = imgBruxa; Tipos[ciclo] = carta.name; }
        if (carta.name == "Guerreiro") { imgBorda.GetComponent<Image>().sprite = imgGuer; Tipos[ciclo] = carta.name; }
        if (carta.name == "Golem") { imgBorda.GetComponent<Image>().sprite = imgGolem; Tipos[ciclo] = carta.name; }
        if (carta.name == "Pet") { imgBorda.GetComponent<Image>().sprite = imgPet; Tipos[ciclo] = carta.name; }
        if (carta.name == "Fada") { imgBorda.GetComponent<Image>().sprite = imgFada; Tipos[ciclo] = carta.name; }
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
