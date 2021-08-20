using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Class that containt vehicle data in our system
/// </summary>
[Serializable]
public class PlayerAction
{

    /// <summary>
    /// The vehicle acceleration
    /// </summary>
    public DataEnum.PlayerAction action;

    public int parameter;

    /// <summary>
    /// After every how many day player can do this action
    /// </summary>
    public int availableAfterEveryThisDay;


    public string ToString()
    {

        switch (action)
        {
            case DataEnum.PlayerAction.GetJob:
                return "Get Job ";
            case DataEnum.PlayerAction.OrderItem:
                return "Order Item";
            case DataEnum.PlayerAction.Rob:
                return "Rob this facility " + parameter + "$";
            case DataEnum.PlayerAction.Chat:
                return "Chat with manager ";
            case DataEnum.PlayerAction.Hack:
                return "Hack this facility " + parameter + "$";
            case DataEnum.PlayerAction.Work:
                return "Work "+parameter +"$";
            case DataEnum.PlayerAction.Sleep:
                return "Sleep";
            case DataEnum.PlayerAction.GetPromotion:
                return "Get promotion";
            case DataEnum.PlayerAction.Dance:
                return "Dance";
        }
        return "";
    }

}
