using UnityEngine;

public class prefabSpawner : MonoBehaviour
{
    public GameObject cube;
    public GameObject namas;
    public GameObject sphere;

    public float radius = 120f;
    public int objectKiekis = 50;

    public int minDydis = 3;
    public int maxDydis = 50;

    private void Start()
    {
        for (int i = 0; i < objectKiekis; i++)
        {
            float x = 0, y = 0, z = 0;

            //nustato kur bus kubelis
            x = Random.Range(-radius, radius);
            //x^2 + y^2 <= radius^2
            //y^2 <= radius^2 - x^2
            float temp = (float)System.Math.Sqrt(radius * radius - x * x);
            y = Random.Range(-temp, temp);
            //x^2 + y^2 + z^2 <= radius^2
            //z^2 <= radius^2 - x^2 - y^2
            temp = (float)System.Math.Sqrt(radius * radius - x * x - y * y);
            z = Random.Range(-temp, temp);

            Vector3 pradinesKoords;
            int rand = Random.Range(0, 6);

            //padaro, kad normaliai random, nes kitu atvieju nesigauna normaliai
            switch (rand)
            {
                case 0:
                    pradinesKoords = new Vector3(x, y, z);
                    break;

                case 1:
                    pradinesKoords = new Vector3(x, z, y);
                    break;

                case 2:
                    pradinesKoords = new Vector3(y, x, z);
                    break;

                case 3:
                    pradinesKoords = new Vector3(y, z, x);
                    break;

                case 4:
                    pradinesKoords = new Vector3(z, y, x);
                    break;

                case 5:
                    pradinesKoords = new Vector3(z, x, y);
                    break;
            }

            GameObject clone;
            clone = Instantiate(sphere, new Vector3(x, y, z), Quaternion.Euler(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360))));

            float randX = Random.Range(minDydis, maxDydis);
            //float randY = Random.Range(1, 8);
            //float randZ = Random.Range(1, 4);

            clone.transform.localScale = new Vector3(randX, randX, randX);

            /*GameObject namas = Resources.Load<GameObject>("Assets/normal_house_prototype.obj");

            MeshFilter meshas;
            meshas = clone.GetComponent<MeshFilter>();
            meshas.sharedMesh = namas.GetComponent<MeshFilter>().sharedMesh;
            meshas.GetComponent<Renderer>().material.color = new Color(30, 240, 30);*/
        }
    }
}