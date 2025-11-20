using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerAccion : MonoBehaviour
{
    //fucniones para los botones
    [SerializeField] Button Play;
    [SerializeField] Button Restart;
    bool Re = false;

    //que objectos moveremos para accer animaciones 
    [SerializeField]
    Transform Object;

    [SerializeField] Transform Object2;

    [SerializeField]
    GameObject[] Figuras;

    //variables para la primera accion
    float duration = 2f;
    //saltos 
    //figura1
    float powerJump = 3f;
    //figura2
    float forceJump = 5f;

    Vector3 posFigura1 = new Vector3(-1.02f, 1.32f, 0.851028f);
    
    //Controlador de la animacion
    Tween TweenCurrent;

    //Posiciones para la figura accion

    //primera accion 
    Vector3 PosPeople1 = new Vector3(9.41f, 0, 0.851028f);
    Vector3 PosPeople2 = new Vector3(-9.16f, 0, 0);

    //segunda accion
    Vector3 Pos2People1 = new Vector3(-0.88f,0, 0.851028f);
    Vector3 Pos2People2 = new Vector3(-1.71f,0,0);

    //tercera accion
    Vector3 Pos3People1 = new Vector3(4.03f,0, -4.39f);
    Vector3 Pos3People2 = new Vector3(-6.68f, 0.11f, 3.69f);

    //cuarta Posicion
    Vector3 Pos4People1 = new Vector3(1.87f, 2,0);
    Vector3 Pos4People2 = new Vector3(1,2, 1.14f);

    //Quinta Posicion
    Vector3 Pos5People1 = new Vector3(-0.47f, 0, -12.07f);
    Vector3 Pos5People2 = new Vector3(0,0,0);
    private void Start()
    {
        Figuras[1].SetActive(false);
    }
    private void Update()
    {
        if (Re)
        {
            Play.interactable = false;
            Restart.interactable = true;
        }
        else
        {
            Play.interactable = true;
            Restart.interactable = false;
            TweenCurrent.Kill();
        }
         
    }
    public void ActivateRestart()
    {
        Reniciar();
    }

   public void ActivatePlay()
    {
        Re = true;
        MoveFigura1();
    }


    //Acciones 
    void MoveFigura1()
    {
       TweenCurrent = Object.DOJump(posFigura1, powerJump, 5, duration).OnComplete(() => { MoveFigura2(); }); ;
    }

    void MoveFigura2()
    {
        //preparamos el segundo escenario
        Figuras[0].SetActive(false);
        Figuras[1].SetActive(true);
        Object.transform.position = new Vector3(5.33f, 0, 0);
        Object2.transform.localScale = new Vector3(1,1,1);

        //hacemos la animacion de la segunda figura
        //primera accion
        TweenCurrent = DOTween.Sequence().Append(Object.DOMove(PosPeople1, duration)).Join(Object2.DOMove(PosPeople2, duration))

        //segunda accion
        .Append(Object.DOMove(Pos2People1, duration)).Join(Object2.DOMove(Pos2People2, duration))

        //tercera Accion
        .Append(Object.DORotate(Pos3People1, duration)).Join(Object2.DORotate(Pos3People2, duration))

        //quarta Accion
        .Append(Object.DOJump(Pos4People1, forceJump, 1, duration)).Join(Object2.DOJump(Pos4People2, forceJump, 1, duration))

        //Quinta accion
        .Append(Object.DOMove(Pos5People1, duration)).Join(Object2.DOMove(Pos5People2, duration));
        
    }

    void Reniciar()
    {
        Object.transform.position = new Vector3(5.33f, 0, 0);
        Object2.transform.position = new Vector3(-2.94f, 0.21f, 1.08f);
        Figuras[0].SetActive(true);
        Figuras[1].SetActive(false);
        Re = false;
    }
}
