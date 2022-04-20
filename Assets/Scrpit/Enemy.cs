using UnityEngine;

public class Enemy : Character
{
    // Start is called before the first frame update
    UnityEngine.AI.NavMeshAgent navigator;
    public Transform player_transform;
    UnitHealthBar healthBar;

    void Start()
    {
        base.init();
        navigator = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navigator.updateRotation = false;
		navigator.updateUpAxis = false;
        healthBar = GetComponentInChildren<UnitHealthBar>();
        healthBar.SetMaxHealth(character_stat.HealthMax);
//        Debug.Log(character_stat.HealthMax);
        healthBar.refillHealth();
        healthBar.gameObject.SetActive(false);
    }

    void dumbAi()
    {
        if (player_transform)
            runTo(player_transform.position);
    }

    public void runTo(Vector3 pos)
    {
        navigator.enabled = true;
        navigator.SetDestination(pos);
        //myDestinationPos = pos;
        _renderer.flipX = pos.x < transform.position.x;
        animator.SetBool(moving_hash, true);
    }

    public void CheckArrived()
    {
        if (!gameObject.activeSelf)
            return;
        if ((navigator.enabled) && navigator.remainingDistance <= navigator.stoppingDistance
        && (!navigator.hasPath || navigator.velocity.sqrMagnitude == 0f)) {
            animator.SetBool(moving_hash, false);
            navigator.enabled = false;
        }
    }

    float timer = 0;
    private void OnCollisionStay2D(Collision2D other)
    {
        if (character_stat.Health > 0 &&
        other.gameObject.tag == "Player" && Time.time > timer) {
            other.gameObject.GetComponent<Character>().takeDamage(character_stat.Attak);
            animator.SetTrigger(attack_hash);
            timer = Time.time + character_stat.Attak_speed;
        }
            
    }

    public override void takeDamage(float dmg)
    {
        base.takeDamage(dmg);
        healthBar.gameObject.SetActive(true);
        healthBar.SetHealth(character_stat.Health);
    }

    public override void death()
    {
        base.death();
        healthBar.refillHealth();
        healthBar.gameObject.SetActive(false);
        Debug.Log("OUTE");
    }



    // Update is called once per frame
    void Update()
    {
        //Camera.main.ScreenPointToRay(Input.mousePosition);
        updateCha();
        if (character_stat.Health <= 0)
            return;
        dumbAi();
        CheckArrived();
        if (Input.GetMouseButtonDown(1))
            runTo(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        //animator.SetTrigger(attack_hash);
    }
}
