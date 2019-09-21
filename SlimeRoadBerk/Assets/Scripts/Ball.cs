using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector3 direction;
    CharacterController ch;   
    float gravitys = 5,jumpforce = 15,movespeed = 5.05f,normalizedposition;
    public AudioSource BallSound;
    int bounce;
    void Start()
    {
        bounce = 0;
        ch = this.GetComponent<CharacterController>();
        this.transform.position = new Vector3(-0.55f, 0.6f, 0);
    }

    
    void Update()
    {


        if (ch.isGrounded) //Eger yere dustuyse tekrar ziplamasi bu fonksiyon icinde saglaniyor
        {
            this.transform.position =new Vector3(1.53f+(bounce*3.06f),this.transform.position.y,this.transform.position.z);
            BallSound.Play();
            float saved = direction.y;
            direction = (new Vector3(1.53f, 0, 0) * movespeed);            
            direction = direction.normalized * movespeed;
            direction.y = saved;
            direction.y = jumpforce;
            bounce++;
        }

        if (Input.touchCount > 0) //Top ekrana bastigimiz andan itibaren elimizin oldugu yere dogru hareket ediyor.
        {
            foreach (Touch touch in Input.touches)
            {
                
                normalizedposition = ((touch.position.x * 4) / Camera.main.pixelWidth) - 2.5f;     // Ekrandan gelen X eksenindeki pixel degerini -2 ile 2 arasina normalize ettim. Cunku platform -2 ile 2 genisliginde            
                if (normalizedposition < 0 && -this.transform.position.z > normalizedposition) 
                    direction.z = - normalizedposition*movespeed;
                else if (normalizedposition > 0 && -this.transform.position.z < normalizedposition)
                    direction.z = - normalizedposition*movespeed;
                else direction.z = 0;

            }
        }
        
            direction += gravitys * Time.deltaTime * Physics.gravity*0.99f;
            ch.Move(direction * Time.deltaTime);
        
    }

     void OnControllerColliderHit(ControllerColliderHit hit) 
     {
         if (hit.gameObject.tag == "Ring")
            GameObject.Find("WorldBuilder").GetComponent<Score>().Menu(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("WorldBuilder").GetComponent<Score>().CollectDiamond(other.gameObject);
    }

}
