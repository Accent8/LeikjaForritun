using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// er með þetta svo að enemy getur labbað um
using UnityEngine.AI;

// scripta til að stjórna enemy
public class EnemyController : MonoBehaviour
{

    // look radius notað til að sjá hversu nálægt player er við enemy
    public float lookRadius = 10f;
    // svo taget breyta (er bara player útaf þetta er enemy controler)
    Transform target;
    // NavMeshAgent svo að enemy getur labbað um
    NavMeshAgent agent;
    // combat svo að enemy getur ráðist á player
    CharacterCombat combat;
    // layermask svo að enemy veit hvað er ground
    public LayerMask whatIsGround;
    // svo vector3 breyta fyrir walk points
    public Vector3 walkPoint;
    // bara bool til að sjá hvort enemy er með walkpoint
    bool walkPointSet;
    // og svo rangið á walkpointum fyrir enemy (bara hversu langt hann getur labbað í einu) þessu get ég breytt í unity
    public float walkPointRange;

    // Start is called before the first frame update
    void Start()
    {
        // target verður bara að player
        target = PlayerManager.instance.player.transform;
        // agent verður bara NavMeshAgent sem er á enemy objectinu
        agent = GetComponent<NavMeshAgent>();
        // og svo fæ ég character combat sem er líka á enemy objectinu
        combat = GetComponent<CharacterCombat>();

    }

    // Update is called once per frame
    void Update()
    {
        // hér skoða ég lengdina á milli player (target) og enemy (transform)
        float distance = Vector3.Distance(target.position,transform.position);
        // ef distance er minna en eða jafnt og lookradius
        if (distance <= lookRadius) 
        {   // þá set ég destinationið hjá enemy á player posistion
            agent.SetDestination(target.position);
            // og ef distance er minna en eða jafnt og stoppintDistance hjá enemy (NavMeshAgent breyta í unity)
            if(distance <= agent.stoppingDistance) 
            {   // nær það í statinn hjá playernum
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                // ef hann er með stats
                if (targetStats != null)
                {   // attackar enemy statin hjá playernum
                    combat.Attack(targetStats);
                    // og kallar á fall til að passa að enemy object er að horfa á player
                    FaceTarget();
                }
            }
        }
        // ef distance er stærra en look radius
        else
        {   // kalla ég á Patroling fall
            Patroling();
        }
    }
    // fall til að enemy horfir á player
    void FaceTarget()
    {   // tekur in normalized direction á player
        Vector3 direction = (target.position - transform.position).normalized;
        // svo er þetta svo að hann horfir á playerinn þótt hann sé stoppaður þá mun hann samt "rotate-a" til að horfa á player (það er það sem Quaternion gerir)
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        // Quaternion reiknar þetta út fyrir mig og svo læt ég hann rotate-a yfir smá tíma svo hann snappi ekki á milli
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime *5f);
    }
    // fall svo að enemy geti Patrolað sem þýðir basicly að Enemy mun labba um á milli punkta ef player er ekki í lookradius
    private void Patroling()
    {   // ef enemy er ekki með walk points kallar hann á fall til að leita af walkpoints
        if (!walkPointSet) 
            SearchWalkPoint();
        // ef hann er með walkpoints
        if (walkPointSet)
            // þá bara labbar hann að walk pointinu
            agent.SetDestination(walkPoint);
        // breyta til að sjá lengd fyrir enemy til að labba að walkpoint
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //þegar hann er kominn á walkpoint
        if (distanceToWalkPoint.magnitude < 1f)
            // setur það walkPointSet á false og þá þarf hann að leita að nýjum walkPoint
            walkPointSet = false;
    }
    // fall til að leita af walkpoints
    private void SearchWalkPoint()
    {
        //reiknar random punkta á x og z ás á bilinum sem ég get stilt í unity í bæði mínus og plús frá enemy
        // þannig segjum ef hann er með range af 10 getur enemy fundið walkpoint sem er bilinum -10 og 10 á z og x frá postition af enemy
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        // svo er bara að setja Walkpointið sem postion + random talan svo hann mun ekki bara labba yfir mappið
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        // svo skoðar hann hvort að walkpoint sé á jörðinni svo að enemy labbi ekki af mappinu
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    // svo er þetta bara fyrir mig að sjá í unity hversu stórt lookRadiusið sé
    private void OnDrawGizmosSelected()
    {
        // bara litur og svo teiknar hring af stærð lookRadius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
