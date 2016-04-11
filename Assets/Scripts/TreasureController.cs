using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TreasureController : MonoBehaviour {

    private string colOtherLayer;

    void OnCollisionEnter2D(Collision2D col)
    {
        colOtherLayer = LayerMask.LayerToName(col.gameObject.layer);

        //If the contact is with a hostility

        if (colOtherLayer == ConstantNames.PLAYER)
        {
            Destroy(col.gameObject);
            SceneManager.LoadScene("Win");
            Destroy(gameObject);    //Destroy the projectile
        }
    }
}
