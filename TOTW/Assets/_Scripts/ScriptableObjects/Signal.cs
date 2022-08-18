using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este ScriptableObject es gen�rico para se�ales. Se crea uno por cada se�al. 
// Cada se�al tiene una lista de listeners (suscriptores), que son quienes reciben la se�al al enviarse/"Raisearse".
[CreateAssetMenu]
public class Signal : ScriptableObject
{
    
    public List<SignalListener> listeners = new List<SignalListener>();                                         

    //Al ejecutar una se�al, por medio de Raise, se recorre la lista de suscriptores y a cada uno se le activa el m�todo que ejecuta las acciones correspondientes a esta se�al enviada. 
    public void Raise()
    {
        // Se recorre la lista al rev�s por si alg�n listener se desubscribe no se genere un Out of Range Exception.
        for (int i = listeners.Count - 1; i >= 0; i--)     // Se empieza desde listeners.Count - 1 para comenzar desde el �ltimo agregado.
        {
          
            if(listeners[i] != null)
            {
                listeners[i].OnSignalRaised();              
            }
        }
    }


    //Cuando un SignalListener solicita suscripci�n o desuscripci�n a esta se�al, se lo agrega o quita de la Lista seg�n corresponda.
    public void RegisterListener(SignalListener listener)
    {
        listeners.Add(listener);                                        
    }

    public void DeRegisterListener(SignalListener listener)
    {
        listeners.Remove(listener);
    }
}
