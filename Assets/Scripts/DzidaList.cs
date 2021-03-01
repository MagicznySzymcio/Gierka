using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DzidaList : MonoBehaviour
{
    public static int liczbaDzid = 0;
    [SerializeField] private static int maxDzid = 3;
    private static Queue<GameObject> listaDzid = new Queue<GameObject>();
    public static SpriteRenderer spriteToFade;
    static public DzidaList instance;

    private void Awake()
    {
        instance = this;
    }
    public static void DzidaUpdate(GameObject dzida)
    {
        liczbaDzid++;
        listaDzid.Enqueue(dzida);

        if (liczbaDzid > maxDzid)
        {
            GameObject go = listaDzid.Dequeue();
            spriteToFade = go.GetComponent<SpriteRenderer>();
            instance.StartCoroutine("FadeOut");
            
        }

        //Debug.Log(liczbaDzid);        
    }

    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f-= 0.05f)
        {
            Color c = spriteToFade.material.color;
            c.a = f;
            spriteToFade.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

}