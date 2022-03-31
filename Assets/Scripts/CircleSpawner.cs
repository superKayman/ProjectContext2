using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    //https://answers.unity.com/questions/1661755/how-to-instantiate-objects-in-a-circle-formation-a.html
    //script hier van daan en zelf aan gepast

    public GameObject[] fishPefab;
    public Material[] strawMat;
    public int amountFish;
    public float minHeight;
    public float maxHeight;
    public float minRadius;
    public float maxRadius;
    public bool good = true;

    void Start()
    {
        CreateEnemiesAroundPoint(amountFish, this.transform.position);
    }

    public void CreateEnemiesAroundPoint(int num, Vector3 point)
    {

        for (int i = 0; i < num; i++)
        {
            
            /* Distance around the circle */
            //var radians = 2 * Mathf.PI / num * i;
            //Debug.Log("rad: " + radians);

            var radians = Random.Range(0, 2 * Mathf.PI);
            /* Get the vector direction */
            var vertrical = Mathf.Sin(radians);
            var horizontal = Mathf.Cos(radians);

            var spawnDir = new Vector3(horizontal, 0, vertrical);

            float radius = Random.Range(minRadius, maxRadius);
            /* Get the spawn position */
            var spawnPos = point + spawnDir * radius; // Radius is just the distance away from the point

            /* Now spawn */
            int r = Random.Range(0, fishPefab.Length);
            var fish = Instantiate(fishPefab[r], spawnPos, Quaternion.identity) as GameObject;
            fish.transform.position = new Vector3(fish.transform.position.x, Random.Range(minHeight, maxHeight), fish.transform.position.z);
            /* Rotate the enemy to face towards player */
            fish.transform.LookAt(point);  //+ new Vector3 (0,0,0)
            //enemy.transform.Rotate = new Vector3(0, 0, 0);

            /* Adjust height */
            //enemy.transform.Translate(new Vector3(0, enemy.transform.localScale.y / 2, 0));
            if(good == true)
            {
                fish.transform.parent = this.gameObject.transform;
                Rigidbody rb = fish.GetComponent<Rigidbody>();
                rb.useGravity = false;
                rb.detectCollisions = false;

                GameObject go =  fish.transform.Find("Straw").gameObject;
                go.SetActive(false);
            }
            else
            {
                Animator ani = fish.transform.GetChild(0).GetComponent<Animator>();
                ani.speed = 5;

                Renderer ren = fish.transform.Find("Straw").GetComponent<Renderer>();
                //ren.material = new Material(Shader.Find("Unlit/Texture"));
                ren.material = strawMat[Random.Range(0, strawMat.Length)];
            }
        }
    }
}
