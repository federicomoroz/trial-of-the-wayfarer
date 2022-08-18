using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

    /* Esta clase se agrega a los objetos que necesiten ejecutar acciones al darse determinada señal. Actúa a modo de receptor.
       Su función consiste en: 1) Definir acciones determinadas en objetos determinados (por inspector). 
                               2) Suscribirse a una señal de interés. 
                               3) Ejecutar las acciones cuando se Raisea la señal.*/

public class SignalListener : MonoBehaviour
{
    public Signal     signal;                                        
    public UnityEvent signalEvent;

    public void OnSignalRaised()
    {         
        signalEvent.Invoke();                                               //Cuando la señal de interés es activada, se activan las acciones anexadas al/a los evento/s.
    }

    private void OnEnable()
    {
        signal.RegisterListener(this);                                      //Este SignalListener solicita a la señal de interés suscribirse a lista de listeners en cuanto el objeto que lo posee es activado en escena.
    }

    private void OnDisable()
    {
        signal.DeRegisterListener(this);                                    //Al desactivarse el objeto que posee al SignalListener, este se desuscribe de la lista de Listeners. 
    }
}
