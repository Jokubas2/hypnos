using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabSpawner : MonoBehaviour
{

    public GameObject cube;

    void Start()
    {
        

        for(int i = 0; i<250; i++)
        {

            float t = 120f;
            float p = 50f;

            float x = Random.Range(-t, t);
            //if(x>p||x<-p) x = Random.Range(-t, t);
            float y = Random.Range(-t, t);
            //if(y>p||y<-p) y = Random.Range(-t, t);
            float z;



            z = Random.Range(-t, t);
            while (x*x + y*y + z*z < 69*69)
            {
                z = Random.Range(-t, t);
            }
            


            Instantiate(cube, new Vector3(x, y, z), Quaternion.identity);
        }

    }
}
