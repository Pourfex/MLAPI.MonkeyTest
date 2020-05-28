using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MLAPI;
using MLAPI.NetworkedVar.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ComplexNetworkScript : NetworkedBehaviour
{

    public int numberOfPoints = 115;

    public float delayBetweenTwoPoints = 0.3f;
    
    public NetworkedList<Vector3> networkedPosition = new NetworkedList<Vector3>(new MLAPI.NetworkedVar.NetworkedVarSettings()
    {
        SendChannel = "Reliable",
        ReadPermission = MLAPI.NetworkedVar.NetworkedVarPermission.Everyone,
        WritePermission = MLAPI.NetworkedVar.NetworkedVarPermission.Everyone,
        SendTickrate = 10
    }, new List<Vector3>());

    public List<Vector3> positions = new List<Vector3>();
    
    // Start is called before the first frame update
    void Start()
    {
        if (IsOwner)
        {
            StartCoroutine(AddValueToList(numberOfPoints, delayBetweenTwoPoints));
        }
    }

    private IEnumerator AddValueToList(int numberOfPoints, float delayBetweenTwoPoints)
    {
        var awaiter = new WaitForSeconds(delayBetweenTwoPoints);
        var rd = new Random();

        for (int i = 0; i < numberOfPoints +1; i++)
        {
            networkedPosition.Add(new Vector3(Random.Range(0f, 10f), Random.Range(0f, 10f), Random.Range(0f, 10f)));
            yield return awaiter;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (positions.Count != networkedPosition.Count)
        {
            positions = networkedPosition.ToList();
        }
    }
}
