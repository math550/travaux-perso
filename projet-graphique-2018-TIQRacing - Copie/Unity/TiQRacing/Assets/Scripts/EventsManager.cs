using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventsManager
{

    
    public static UnityEvent ServersLoaded;
    public static UnityEvent EventX;
    public static UnityEvent EventY;

    private static Dictionary<string, UnityEvent> m_MyEvents = new Dictionary<string, UnityEvent>();
    

    public static void AddListener(string a_EventName, UnityAction a_Action)
    {
        UnityEvent thisEvent = null;

        bool t_EventExists = m_MyEvents.TryGetValue(a_EventName, out thisEvent);

        if(!t_EventExists)
        {
            thisEvent = new UnityEvent();
            m_MyEvents.Add(a_EventName, thisEvent);
            
        }
        else
        {
            Debug.Log("Listener not added: " + a_EventName);
        }

        thisEvent.AddListener(a_Action);
    }

    public static void RemoveListener(string a_EventName, UnityAction a_Action)
    {
        UnityEvent thisEvent = null;
        
        bool t_EventExists = m_MyEvents.TryGetValue(a_EventName, out thisEvent);

        if (!t_EventExists)
        {
            thisEvent.RemoveListener(a_Action);
            Debug.Log("Listener removed: " + a_EventName);
        }
    }

    public static void TriggerListener(string a_EventName)
    {
        UnityEvent thisEvent = null;
        Debug.Log("Trying to trigger event: " + a_EventName);
        bool t_EventExists = m_MyEvents.TryGetValue(a_EventName, out thisEvent);

        if (t_EventExists)
        {
            thisEvent.Invoke();
        }
        else
        {
            Debug.Log("Error : Event doesn't exist");
        }
    }
}
