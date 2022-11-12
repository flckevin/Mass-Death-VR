using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CorePattern;
/***************************************
 * Authour: HAN 18080038
 * Object hold: GameManager
 * Content: manage every event in game
 **************************************/
namespace CoreEvent
{
    public class EventDispatch : Singleton<EventDispatch>
    {
        //declare new dictionary to store all events
        public Dictionary<EventsType, Action<object>> eventDict = new();

        //function to add event
        public void Addevent(EventsType eventType, Action<object> function)
        {
            //checking whether event already contain key
            if(eventDict.ContainsKey(eventType))
            {
                //if it does
                //add function to that event
                eventDict[eventType] += function;
            }
            else // it does not contain key
            {
                //add new key along with event
                eventDict.Add(eventType,function);
            }

        }

        //function to remove evnt
        public void RemoveEvent(EventsType eventType)
        {
            //if event does contain given key then stop
            if(!eventDict.ContainsKey(eventType)) return;
            //it it does
            //remove it
            eventDict.Remove(eventType);
        }

        //function to call event
        public void CallFunction(EventsType eventType)
        {
            //declare new varible to store a function inside dictionary
            var func = eventDict[eventType];

            //if function does not exist
            if(eventDict == null)
            {
                //remove the event then stop
                RemoveEvent(eventType);
                return;
            }
            else // it does contain
            {
                //call function
                func(null);
            }
        }

       
    }

   
}
