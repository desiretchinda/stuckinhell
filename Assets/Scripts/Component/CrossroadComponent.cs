using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///The component that manages the intersection to define the possible directions of a vehicle
///The function that clamps the position of the parraport camera to a limit
/// </summary>
public class CrossroadComponent : MonoBehaviour
{

    /// <summary>
    /// Possible directions in an intersection
    /// </summary>
    public List<DataEnum.PossibleDirection> possibleDirection = new List<DataEnum.PossibleDirection>();


}
