using UnityEngine;
using System.Collections;

public class DestroyContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        if (other.tag != "Player")
        {
            PlayerData.Instance.Score += 100;
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
