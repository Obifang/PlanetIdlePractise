using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public int Cost = 0;

    private void Start()
    {
        
    }

    public void Spawn(GameObject objectToSpawn)
    {
        if (GameManager.Instance.Gold - Cost < 0 || GameManager.Instance.CurrentState == GameManager.GameStates.PlacingObject) {
            return;
        }

        var newObj = Instantiate(objectToSpawn, GameManager.Instance.planet.transform, true);
        GameManager.Instance.UpdateGold(-Cost);
    }
}
