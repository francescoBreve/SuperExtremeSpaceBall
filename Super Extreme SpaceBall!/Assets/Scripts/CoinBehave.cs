using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehave : MonoBehaviour
{
    public float coinSpeed;
    public int coinValue;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        coinSpeed *= LevelManager.FPS_MODIFIER;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,coinSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            FindObjectOfType<LevelManager>().playerCoins += coinValue;
            Destroy(gameObject);
        }
    }
}
