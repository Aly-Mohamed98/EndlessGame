using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManager : MonoBehaviour
{
    public GameObject [] tilePrefabs;
    private float zSpawn = 0;
    private float zSpawnUp = 5;
    public float tileLength = 46;
    public int numberOfTiles = 8;
    private List<GameObject> activeTiles = new List<GameObject> ();
    private List<GameObject> activeTiles2 = new List<GameObject>();
    public Transform playerTransform;
    void Start()
    {
        for (int i = 0; i < numberOfTiles ; i++){
            if (i == 0){
                spawnTile(0);
                spawnTileUp(0);
            }
            else{
                spawnTile(Random.Range(1,numberOfTiles));
                spawnTileUp(Random.Range(1,numberOfTiles));
            }            
        }                
    }
    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z -35 > zSpawn - (numberOfTiles*tileLength)){
            spawnTile(Random.Range(1, tilePrefabs.Length));
            spawnTileUp(Random.Range(1, tilePrefabs.Length));
            deleteTile();
        }        
    }
    public void spawnTile(int index){
        GameObject go = Instantiate(tilePrefabs[index], transform.forward*zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn+= tileLength;
    }
    public void spawnTileUp(int index){
        GameObject go = Instantiate(tilePrefabs[index], new Vector3(0,10,zSpawnUp),  new Quaternion(0, 0, 1, 0));
        activeTiles2.Add(go);
        zSpawnUp+= tileLength;
    }
    private void deleteTile(){
         Destroy(activeTiles[0]);
         Destroy(activeTiles2[0]);
         activeTiles.RemoveAt(0); 
         activeTiles2.RemoveAt(0);
    }
}
