using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private List<string> names = new();
    [SerializeField]
    private List<GameObject> prefabs = new();


    // Start is called before the first frame update
    void Start()
    {
        // spawn a player
        Spawn("player");

        for (int i = 0; i < 5; i++)
        {
            Spawn("sphere").GetComponent<Rigidbody>().AddExplosionForce(9, new Vector3(Random.Range(0, 1), -1, Random.Range(0, 1)), 5, 5);
        }

    }

    public GameObject Spawn(string name) => Instantiate(prefabs[names.IndexOf(name)]);

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 100) > 60)
            StartCoroutine(SpawnDelay(Random.Range(1, 5)));
    }
    IEnumerator SpawnDelay(float delay)
    {
        yield return new WaitForSeconds(delay);// wait 
        for (int i = 0; i < 5; i++)// spawn 5 objects at 0 0 0, moving in random directions
        {
            Spawn("sphere").GetComponent<Rigidbody>().AddExplosionForce(9, new Vector3(Random.Range(-1, 1), -1, Random.Range(-1, 1)), 5, 5);
        }
    }

}
