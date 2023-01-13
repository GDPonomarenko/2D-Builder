using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    Vector3 mousePositionOffset;
    public GameObject targetManager;
    private List<GameObject> target;
    public float timeChop;
    public int countWood;
    public GameObject characterInProcces;
    public GameObject firewood;
    public List<Transform> branches;
    public GameObject selectTree;
    public AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        targetManager = GameObject.Find("TargetManager");
        target = targetManager.GetComponent<TargetManager>().targetTree;
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }


    private void OnMouseDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            target.Add(gameObject);
            selectTree.SetActive(true);
            //gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    public IEnumerator TreeFelling()
    {
        yield return new WaitForSeconds(timeChop);
        target.Remove(gameObject);
        transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(0, 0, 80, 0), 1);
        gameObject.GetComponent<Animator>().SetBool("Down_tree", true);
        audioData.Play();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Character_chopper") {
            characterInProcces = collision.gameObject;
        }
    }

    public void DestroyTree(){
        Destroy(gameObject);
    }

    public void GenerateFirewood() {
        for (int z =0; z< countWood; z++) {
            Instantiate(firewood, new Vector3(transform.position.x, transform.position.y+0.2f, transform.position.z), Quaternion.identity);
        }
    }

}
