using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TreasureController : MonoBehaviour {

    private string colOtherLayer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        colOtherLayer = LayerMask.LayerToName(col.gameObject.layer);

        //If the contact is with a hostility

        if (colOtherLayer == ConstantNames.PLAYER)
        {
            Destroy(col.gameObject);
            SceneManager.LoadScene("Game Over");
            Destroy(gameObject);    //Destroy the projectile
        }
    }
}
