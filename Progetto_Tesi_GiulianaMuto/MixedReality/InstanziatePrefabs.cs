using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using static Vive.Plugin.SR.SceneUnderstandingObjects;

public class InstanziatePrefabs : MonoBehaviour
{


    //i prefabs degli oggetti 3D
    public GameObject pref_chair, pref_wall, pref_ceiling, pref_table, pref_floor;
 

    public void InitializationPrefabs(String element, Vector3 position, Vector3 scale, GameObject obj)
    {
       // Debug.Log("Sto inizializando i prefab");
       
          //In base all'oggetto che trovo creo il prefab corrispondente
          //mi definisco la posizione
          //creo il prefab
          //modifico la scala del prefab
          //rendo il prefab figlio del meshcube
          //Eccezzione di floor: gli ho dato un valore nell'asse delle Y perchè così si trova un poco più in alto del pavimento

        if (element.Equals("Chair"))
        {
            position = new Vector3(position.x, position.y, position.z);
            pref_chair = Instantiate(pref_chair, position, new Quaternion(0, 0, 0, 0));
            pref_chair.transform.localScale = scale;
            pref_chair.transform.SetParent(obj.transform);
            
        }

        if (element.Equals("Wall"))
        {
            position = new Vector3(position.x, position.y, position.z);
            pref_wall = Instantiate(pref_wall, position, new Quaternion(0, 0, -90, 0));
            pref_wall.transform.localScale = new Vector3(-0.111f, scale.y, scale.z);
            pref_wall.transform.SetParent(obj.transform);

            
        }

        if (element.Equals("Ceiling"))
        {
            position = new Vector3(position.x,position.y , position.z);
            pref_ceiling = Instantiate(pref_ceiling, position,new Quaternion(0,0,180,0));
            pref_ceiling.transform.localScale = scale;
            pref_ceiling.transform.SetParent(obj.transform);
        }

        if (element.Equals("Table"))
        {

            position = new Vector3(position.x, position.y, position.z);
            pref_table = Instantiate(pref_table, position, Quaternion.identity);
            pref_table.transform.localScale = scale;
            pref_table.transform.SetParent(obj.transform);
        }

 
        if (element.Equals("Floor"))
        {
            position = new Vector3(position.x, 0.40f, position.z);
            pref_floor = Instantiate(pref_floor, position, Quaternion.identity);
            pref_floor.transform.localScale = scale;
            pref_floor.transform.SetParent(obj.transform);

        }
    }
}
