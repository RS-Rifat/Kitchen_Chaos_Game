using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;

    [SerializeField] private KitchenObjectSO plateKitechenObjecetSO;

    private float spawmPlateTimer;
    private float spawmPlateTimerMax = 4f;
    private int plateSpawendAmount;
    private int plateSpawendAmountMax = 4;

    private void Update()
    {
        spawmPlateTimer += Time.deltaTime;
        if(spawmPlateTimer > spawmPlateTimerMax)
        {
            spawmPlateTimer = 0f;
            if(plateSpawendAmount < plateSpawendAmountMax)
            {
                plateSpawendAmount++;

                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            // Player is empty handed
            if(plateSpawendAmount > 0)
            {
                // There's at least one plate here
                plateSpawendAmount--;

                KitchenObject.SpawnKitchenObject(plateKitechenObjecetSO, player);

                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
