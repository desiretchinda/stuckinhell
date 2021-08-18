using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Class that containt dialog data in our system
/// </summary>
[Serializable]
public class DialogData : BaseData
{

    /// <summary>
    /// Dialogue text
    /// </summary>
    public string dialogText;

    /// <summary>
    /// Differents choices of this dialog
    /// </summary>
    public List<ChoiceData> choices = new List<ChoiceData>();

    public override string ToString()
    {
        return name;
    }

}
