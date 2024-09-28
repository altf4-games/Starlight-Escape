using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public float speed = 3.0f;

    private float distance;
    private bool isAttacking = false;

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 dir = player.transform.position - transform.position.normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        if (distance <= 1f && !isAttacking)
        {
            isAttacking = true;
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(.5f);
        Debug.Log("Attacking player");
        player.GetComponent<PlayerHealth>().TakeDamage(10);
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }
}
