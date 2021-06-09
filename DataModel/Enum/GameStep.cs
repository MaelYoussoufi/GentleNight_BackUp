using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.DataModel.Enum
{
    public enum GameStep
    {
        CardDraw,
        CardActivation,
        CardValidation,
        PlayerAction,
        EndOfTurnDelayedCardEffect,
        EndOfTurnWorldElementActivation,
        EndOfTurnProcesses
    }

    public enum GameFlowEvent
    {
        TurnStart,
        CardDrawn,
        HandsValidated,
        PlayerMovement,
        PlayerWorldElementActivation,
        //TODO fill that with other player actions and events
        //TODO check follow up events from the chart
    }
}
