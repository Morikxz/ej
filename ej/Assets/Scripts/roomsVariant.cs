using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomsVariant : MonoBehaviour
{
    public GameObject[] topRooms;
    public GameObject[] bottomRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    
    public GameObject key;
    public GameObject bonus_gun;
    public GameObject miach;

    [HideInInspector] public List<GameObject> rooms;

    private void Start() {
        StartCoroutine(RandomSpawner());
    }

    IEnumerator RandomSpawner() {
        yield return new WaitForSeconds(2f);
        AddRoom lastRoom = rooms[rooms.Count - 1].GetComponent<AddRoom>();
        int rand = Random.Range(2, rooms.Count - 2);
        int rand_shance = Random.Range(0, 5);

        Instantiate(key, rooms[rand].transform.position, Quaternion.identity);
        Instantiate(bonus_gun, rooms[rooms.Count - 2].transform.position, Quaternion.identity);
        
        //if(rand_shance == 5){
            Instantiate(miach, rooms[rooms.Count - rand_shance].transform.position, Quaternion.identity);
        //}   

        lastRoom.door.SetActive(true);
        lastRoom.DestroyWalls();
    }
}
