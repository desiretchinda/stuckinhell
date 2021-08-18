using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Class that containt a dialogue choice data in our system
/// </summary>
[Serializable]
public class ChoiceData
{

    public string choiceText;

    public List<DataEnum.PlayerAction> choiceActions = new List<DataEnum.PlayerAction>();

    public int nextDialogId = -1;
}
