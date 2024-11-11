using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehaviour : MonoBehaviour
{
    [SerializeField] Color inactiveColor, activeColor, errorColor;
    [SerializeField]bool isDeactivable;
    [SerializeField]float errorTime;


    int state; //0 desactivado, 1 actvado, -1 error

    MeshRenderer mr;

    //delegado es una descripción de función, parametro que guarda referencias a otras funciones
    //En este caso cualquier funcion que no reciba nada y no devuelva nada puede ser un TriggerDelegate
    //TriggerDelegate functionToCall; (hecho por medio de EL EVENTO)
    public delegate void TriggerDelegate(bool b, SwitchBehaviour sender);

    //El EVENTO
    event TriggerDelegate OnChangeState;


    public void Activate(bool activate)
    {
        if (activate)
        {
            Activate();
        }
        else
        {
            Deactivate();
        }
    }
    public void Activate()
    {
        if(state != 1)
        {
            state = 1;
            mr.materials[1].color = activeColor;
            if (OnChangeState != null)
            {
                OnChangeState(true, this);
            }
        }        
    }
    public void Deactivate()
    {
        if (state != 0)
        {
            state = 0;
            mr.materials[1].color = inactiveColor;
            if (OnChangeState != null)
            {
                OnChangeState(false, this);
            }
        }
    }
    public void Error()
    {
        if (state != -1)
        {
            state = -1;
            mr.materials[1].color = errorColor;
            StartCoroutine(DeactivateDelay());
        }       
    }

    IEnumerator DeactivateDelay()
    {
        yield return new WaitForSeconds(errorTime);
        Deactivate();
    }


    private void Start()
    {
        state = 0;
        //print("Activo? " + isActive);
        mr = GetComponent<MeshRenderer>();
    }

    ////si set function es publico el trigger delegate ha de ser publico tambien
    public void RegisterFunctionToCall(TriggerDelegate f)
    {
        //Registra/Suscribe a la funcion pasada en OnTriggered
        OnChangeState += f;
    }
    public void UnregisterFunctionToCall(TriggerDelegate f)
    {
        //Desuscribe a la funcion pasada en OnTriggered
        OnChangeState -= f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (state == 0) 
            {
                Activate();
                //door.Close();
                //functionToCall(); Una única función, OnTriggered() permite invocar varias funciones

            }
            else if(state ==1 && isDeactivable)
            {
                Deactivate();
                //door.Open();
            }
        }
    }
}
