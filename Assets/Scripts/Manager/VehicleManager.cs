using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The component that will manage all vehicles on the scene
/// </summary>
public class VehicleManager : MonoBehaviour
{
    /// <summary>
    /// Max vehicle will can have in the scene
    /// </summary>
    public int poolNumber = 10;

    /// <summary>
    /// Differents possible spawnplaces
    /// </summary>
    public List<SpawnPlace> spawnPlaces = new List<SpawnPlace>();


    /// <summary>
    /// The initial directions of the vehicles spawn according to each place in spawnSpaces(spawnPlaces[0]=spawnPlacesTargetDirection[0],spawnPlaces[1]=spawnPlacesTargetDirection[1]
    /// </summary>
    public List<DataEnum.PossibleDirection> spawnPlacesTargetDirection = new List<DataEnum.PossibleDirection>();



    /// <summary>
    /// Liste of all vehicle that can be spawn. this vehicle are reuse each time they are availlable
    /// </summary>
    public List<VehicleComponent> possibleVehicles = new List<VehicleComponent>();


    /// <summary>
    /// Liste of all vehicle spawn. this vehicle are reuse each time they are availlable
    /// </summary>
    [HideInInspector]
    public List<VehicleComponent> spawnVehicles = new List<VehicleComponent>();

    /// <summary>
    /// Delay between each vehicle spawn
    /// </summary>
    public float delaySpaw = 5;

    /// <summary>
    /// Counter delay for next spawn
    /// </summary>
    private float counterDelay = 0;

    /// <summary>
    /// the index inside spawnPlace list for current place to spawn vehicle
    /// </summary>
    public int indexSpawnPlace;

    private VehicleComponent tmpVehicleData;

    // Start is called before the first frame update
    void Start()
    {
        counterDelay = delaySpaw;
    }

    // Update is called once per frame
    void Update()
    {

        VehicleSpawner();
    }

    /// <summary>
    /// Function responsible for spawning vehicle
    /// </summary>
    void VehicleSpawner()
    {

        if (spawnVehicles == null)
            return;

        counterDelay -= (float)Time.deltaTime;

        if (counterDelay <= 0)
        {
            if (spawnPlaces.Count > 0)
            {

                indexSpawnPlace = Random.Range(0, spawnPlaces.Count);
                SetUpVehicle(GetAvailableVehicle(), spawnPlaces[indexSpawnPlace]);

                counterDelay = delaySpaw;

            }

        }
    }

    /// <summary>
    /// Get from our vehicle pool and available vehicle
    /// </summary>
    /// <returns></returns>
    public VehicleComponent GetAvailableVehicle()
    {
        for (int i = 0, length = spawnVehicles.Count; i < length; i++)
        {
            if (spawnVehicles[i] && spawnVehicles[i].availableForSpawn)
                return spawnVehicles[i];
        }

        if (spawnVehicles.Count < poolNumber)
        {
           
            tmpVehicleData = possibleVehicles[Random.Range(0, possibleVehicles.Count)];
            if (tmpVehicleData == null)
                return null;
            spawnVehicles.Add(Instantiate(tmpVehicleData));
            spawnVehicles[spawnVehicles.Count - 1].acceleration = tmpVehicleData.acceleration;
            spawnVehicles[spawnVehicles.Count - 1].rotationAcceleration = tmpVehicleData.rotationAcceleration;
            return spawnVehicles[spawnVehicles.Count - 1];
        }

        return null;
    }

    /// <summary>
    /// Init function for a new spawn vehicle
    /// </summary>
    /// <param name="spawnVehicle"></param>
    /// <param name="spawnPlace"></param>
    /// <param name="direction"></param>
    public void SetUpVehicle(VehicleComponent spawnVehicle, SpawnPlace spawnPlace)
    {
        if (!spawnVehicle)
            return;

        if (!spawnPlace)
            return;

        spawnVehicle.transform.position = spawnPlace.transform.position;

        if (spawnVehicle.spRender)
            spawnVehicle.spRender.sprite = spawnVehicle.spSide;

        switch (spawnPlace.nextDirection)
        {
            case DataEnum.PossibleDirection.Up:
                spawnVehicle.direction = Vector3.up;
                spawnVehicle.preventDirection = DataEnum.PossibleDirection.Down;

                if (spawnVehicle.spRender)
                    spawnVehicle.spRender.sprite = spawnVehicle.spUp;

                break;
            case DataEnum.PossibleDirection.Down:
                spawnVehicle.direction = Vector3.down;
                spawnVehicle.preventDirection = DataEnum.PossibleDirection.Up;

                if (spawnVehicle.spRender)
                    spawnVehicle.spRender.sprite = spawnVehicle.spDown;
                break;
            case DataEnum.PossibleDirection.Right:
                spawnVehicle.direction = Vector3.right;
                spawnVehicle.preventDirection = DataEnum.PossibleDirection.Left;
                break;
            case DataEnum.PossibleDirection.Left:
                spawnVehicle.direction = Vector3.left;
                spawnVehicle.preventDirection = DataEnum.PossibleDirection.Right;
                break;
            default:
                break;
        }

        if (spawnVehicle.direction.x < 0)
            spawnVehicle.transform.localScale = new Vector3(2, 2);

        if (spawnVehicle.direction.x >= 0)
            spawnVehicle.transform.localScale = new Vector3(-2, 2);
        spawnVehicle.availableForSpawn = false;
        spawnVehicle.gameObject.SetActive(true);
    }
}
