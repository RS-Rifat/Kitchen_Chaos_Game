using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;


    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // player has no kithchen object
            if (player.HasKitchenObject())
            {
                // playr is carrying kitchen object
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                // Player not carrying anything
            }
        }
        else
        {
            // player has kitchen object
            if (player.HasKitchenObject())
            {
                //player is carrying something
            }
            else
            {
                // player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlternate(Player player)
    {
        if(HasKitchenObject())
        {
            // There is a kitchenObject here
            GetKitchenObject().DestroySelf();


            Transform kitchenObjectTransform = Instantiate(cutKitchenObjectSO.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);

        }
        
    }

    //end
}
