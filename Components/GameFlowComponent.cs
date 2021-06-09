using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.DataModel.Enum;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public class GameFlowComponent : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TurnFlow()
        {
            // Gather all players components

            // Handle start of turn process

            // Start Allied Agents actions

            // Draw and setup player hands & cards

            // Ask every PlayerActorComponent for cards activation

            // Wait async for all activations

            // Once all activations are received, feed PlayerActorComponents with the correct Effects

            // Wait async for the end of a timer OR all players ending their turns

            // Run Enemy Agent Actions

            // Run World Element activations

            // Activate EoT processes

            // EoT
            // CleanUp
            // Display
            // Start next one
        }

        // TODO: Find correct way to do => <= with actions within a single function ?
        // - You want to the above process including the "Wait Async" in single easy to read workflow
        // - should be easy implementation of the come-wait-go of the process
        // - Flow methods should contain most of the directing processes of the game
        // - Screens, player action, input or display should be managed elsewhere
        // TODO: add a display manager with the =><= async wait baked in => to display status screen on-the-go

    }

    public static class GameEventObserver
    {
        //TODO make this class threadsafe
        public static EventHandler<GameStepEventArgs> GameStepEventHandler;
        public static EventHandler<GameFlowEventArgs> GameFlowEventHandler;

        //TODO : make these step asynch & use them in the gameflow
        public static void CallStepEvent()
        {
            //GameStepEventHandler.Invoke();
        }
        

        public static void SubscribeGameStep(EventHandler<GameStepEventArgs> stepEventAction)
        {
            GameStepEventHandler += stepEventAction;
        }
        public static void SubscribeGameFlow(EventHandler<GameFlowEventArgs> flowEventAction)
        {
            GameFlowEventHandler += flowEventAction;
        }
        public static void UnSubscribeGameStep(EventHandler<GameStepEventArgs> stepEventAction)
        {
            GameStepEventHandler -= stepEventAction;
        }
        public static void UnSubscribeGameFlow(EventHandler<GameFlowEventArgs> flowEventAction)
        {
            GameFlowEventHandler -= flowEventAction;
        }
    }

    public class GameFlowEventArgs : EventArgs
    {
        public GameFlowEventArgs(GameFlowEvent gameFlowEvent)
        {
            FlowEvent = gameFlowEvent;
        }

        public GameFlowEvent FlowEvent { get; set; }
    }

    public class GameStepEventArgs : EventArgs
    {
        public GameStepEventArgs(GameStep gameStep)
        {
            Step = gameStep;
        }

        public GameStep Step { get; set; }
    }
}
