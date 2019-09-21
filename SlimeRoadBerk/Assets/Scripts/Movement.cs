using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    int rnd;
    float speed;
    //Cemberlerin Hareketlerini Saglayan Script
    void Start()
    {
        rnd = Random.Range(0, 2); //Hangi yone gideceklerini rastgele belirlemek icin
        speed = Random.Range(50, 150); //Ne hizda gideceklerini rastgele belirlemek icin
        speed = speed / 100; 
    }

    
    void Update()
    {
        if(rnd==0)//O yonde sinira ulastiginda tam tersi yone donmesi icin
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y, -1.9f), Time.deltaTime * speed);
            if (this.transform.position.z < -1.1)
            {
                rnd = 1;
                
            }
        }

       if (rnd == 1)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y, 1.9f), Time.deltaTime * speed);
            if (this.transform.position.z > 1.1)
                rnd = 0;
           
        }
        

    }
}
