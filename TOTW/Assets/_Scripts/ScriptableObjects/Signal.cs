using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este ScriptableObject es genérico para señales. Se crea uno por cada señal. 
// Cada señal tiene una lista de listeners (suscriptores), que son quienes reciben la señal al enviarse/"Raisearse".
[CreateAssetMenu]
public class Signal : ScriptableObject
{
    
    public List<SignalListener> listeners = new List<SignalListener>();                                         

    //Al ejecutar una señal, por medio de Raise, se recorre la lista de suscriptores y a cada uno se le activa el método que ejecuta las acciones correspondientes a esta señal enviada. 
    public void Raise()
    {
        // Se recorre la lista al revés por si algún listener se desubscribe no se genere un Out of Range Exception.
        for (int i = listeners.Count - 1; i >= 0; i--)     // Se empieza desde listeners.Count - 1 para comenzar desde el último agregado.
        {
          
            if(listeners[i] != null)
            {
                listeners[i].OnSignalRaised();              
            }
        }
    }


    //Cuando un SignalListener solicita suscripción o desuscripción a esta señal, se lo agrega o quita de la Lista según corresponda.
    public void RegisterListener(SignalListener listener)
    {
        listeners.Add(listener);                                        
    }

    public void DeRegisterListener(SignalListener listener)
    {
        listeners.Remove(listener);
    }
}
