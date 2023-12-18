using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : Trap
{   


    private bool _isTrapActive = true;

    protected override void KillPlayer(IPlayer player)
    {
        if (_isTrapActive)
        {
            base.KillPlayer(player);
        }
    }
    // private void OnTriggerEnter2D(Collider2D collider)
    // {
    //     if(collider.gameObject.CompareTag("Player"))
    //     {
            
    //     }
    // }


}
