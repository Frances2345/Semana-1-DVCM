using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float range = 4f;
    public float speed = 3f;
    
    public GameObject player;
    private bool EnableRay = false;

    void Start()
    {
        if(GetComponent<SphereCollider>() != null)
        {
            GetComponent<SphereCollider>().radius = range;
        }

    }

    void Update()
    {
        if(EnableRay && player != null)
        {

            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnableRay = true;
            player = other.gameObject;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnableRay = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Mencho Murio");
            Destroy(gameObject);
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
