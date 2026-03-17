using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float range = 4f;
    
    public bool EnableRay;

    public GameObject player;

    void Start()
    {
        GetComponent<SphereCollider>().radius = range;
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnableRay = true;
            player = other.gameObject;
            print("Player Entered");

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnableRay = false;
            print("Player Exit");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

        Gizmos.color = Color.yellow;
        if (EnableRay)
        {
            Vector3 playerpos = player.transform.position;
            Vector3 dir = (playerpos - transform.position);
            Gizmos.DrawRay(transform.position, dir );
        }
      
        // Gizmos.DrawWireSphere(transform.position, rangeChase);
    }
}
