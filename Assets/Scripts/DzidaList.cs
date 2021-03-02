using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DzidaList : MonoBehaviour
{
    public static int liczbaDzid = 0;
    [SerializeField] private static int maxDzid = 15;
    private static Queue<GameObject> listaDzid = new Queue<GameObject>();

    public static void DzidaUpdate(GameObject dzida)
    {
        liczbaDzid++;
        listaDzid.Enqueue(dzida);

        if (liczbaDzid > maxDzid)
        {
            GameObject go = listaDzid.Dequeue();
            go.GetComponent<DzidaController>().Fade();
            // Destroy(listaDzid.Dequeue());
        }

        //Debug.Log(liczbaDzid);        
    }

}