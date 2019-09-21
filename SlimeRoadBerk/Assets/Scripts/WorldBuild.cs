using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuild : MonoBehaviour
{
    public GameObject Platform,Ring,Diamond;
    public Material DarkColor;
    
    private void SpawnFloor() //Platformun Olusturulmasi.
    {
        float x = 0;

        for (int i = 0; i < 60; i++)
        {
            GameObject copied = Instantiate(Platform, new Vector3(x, 0, 0), Quaternion.identity);
            copied.name = i.ToString();
            copied.transform.parent = GameObject.Find("Floors").transform;
            copied.AddComponent<BoxCollider>();
            copied.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            x += 1.53f;
            if (i % 2 == 1)
                copied.GetComponent<Renderer>().material = DarkColor;
        }

    }

    private void SpawnRings() // Yuzuklerin rastgele konumda olusuturulmasi.
    {
        int howmany = Random.Range(8, 12);
        List<int> Places = new List<int>();
        bool uniquenumber;

        for (int i = 0; i < howmany; i++)
        {
            uniquenumber = false;
            while (uniquenumber == false)
            {
                int rnd = Random.Range(4, 25) * 2;
                if (Places.Contains(rnd) == false)
                {
                    Places.Add(rnd);
                    uniquenumber = true;
                    GameObject copied = Instantiate(Ring, new Vector3(GameObject.Find(rnd.ToString()).transform.position.x-0.3f, 2.6f, 0), Quaternion.identity);
                    copied.AddComponent<Movement>();
                    copied.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                    GameObject diamoncopy = Instantiate(Diamond,copied.transform.position, Quaternion.identity);
                    diamoncopy.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                    diamoncopy.transform.parent = copied.transform;
                    copied.transform.parent = GameObject.Find("Rings").transform;
                    copied.tag = "Ring";
                }

            }
        }
    }

    void Start()
    {
        Time.timeScale = 1f; // Restart yaptigimizda zamanin akisini normale cevirmemiz gerekiyor. Cunku restart menusunde oyun duruyor.
        SpawnFloor();
        SpawnRings();
    }

    void Update()
    {
        
    }
}
