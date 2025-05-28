using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject[] tileprefab;
    public float zspawn = 0;
    public float lenghttile = 32;
    public int numbertiles = 4;

    public Transform playerposisi;
    private List<GameObject>  activetile = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < numbertiles; i++)
        {
            if (i == 0)
            {
                spawntile(3);
            }
                
            else
            {
                spawntile(Random.RandomRange(0, tileprefab.Length));
            }
            
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        if (playerposisi.position.z -lenghttile > zspawn - (numbertiles * lenghttile))
        {
            spawntile(Random.Range(0,tileprefab.Length));
            deletetile();
        }
    }

    public void spawntile(int tileindex)
    {
        GameObject go=Instantiate(tileprefab[tileindex], transform.forward * zspawn, transform.rotation);
        activetile.Add(go);
        zspawn += lenghttile;
    }

    private void deletetile()
    {
        Destroy(activetile[0]);
        activetile.RemoveAt(0);
    }
}
