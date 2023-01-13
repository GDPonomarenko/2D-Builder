using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Character : MonoBehaviour
{

    [Header("Character setting")]
    public AudioSource audioData;
    public float speedMove;
    public float speedDown;
    public float positionCharacterInTirrain;
    public int moveDistanceAround;
    public AudioClip walkAudio, chopAudio, buildAudio;
    [HideInInspector] public Animator animCharacter;
    public Vector2 spawnPosition;
    [HideInInspector] public Vector2 path;
    [HideInInspector] private Vector3 mousePositionOffset;
    [HideInInspector] public bool isSelect;
    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public Transform myTransform;

    public ParticleSystem particleSystemChop;
    public enum CharacterType
    {
        Worker,
        Lumberjack,
        Unemployed,
        Fermer,
        Solider
    }
    public CharacterType characterType;
    private IEnumerator corutine;
    public List<GameObject> target;
    [HideInInspector] public GameObject targetManager;
    private float TimeBuilding;
    private int indexSend;

    [HideInInspector] public GameObject buildingSelected;

    public void WalkCharacter(Vector2 path)
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(path.x, 0), Time.deltaTime * speedMove);
        animCharacter.SetBool("Walk", true);
        CheckDiraction(path);
    }

    public void CheckDiraction(Vector2 target)
    {
        if (target.x > myTransform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    public bool CheckCharacterDoneMove(Vector2 target)
    {

        if (Vector2.Distance(target, myTransform.position) < 0.2f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public Vector2 GenerationNewPath()
    {
        float newPath = Random.Range(spawnPosition.x - moveDistanceAround, spawnPosition.x + moveDistanceAround);

        if (newPath == myTransform.position.x)
        {
            GenerationNewPath();
        }
        return new Vector2(newPath, 0);
    }


    public void DownCharacter()
    {
        myTransform.position = Vector2.MoveTowards(myTransform.position, new Vector2(myTransform.position.x, positionCharacterInTirrain), Time.deltaTime * speedDown);
    }


    public void CharacterInTerrain()
    {
        animCharacter.SetBool("Select", false);
    }


    private void OnMouseDown()
    {
        SelectCharacter();
    }

    public void SelectCharacter()
    {
        StopWorkProcces();
        Vector3 selectPos = new Vector3(myTransform.position.x, myTransform.position.y - 0.1f, 0);
        mousePositionOffset = selectPos - GetMouseWorldPosition();
        animCharacter.SetBool("Select", true);
        isSelect = true;
    }

    private void OnMouseDrag()
    {
        myTransform.position = GetMouseWorldPosition() + mousePositionOffset;
        //partycleCharacterSystem.enableEmission = false;
    }

    private void OnMouseUp()
    {
        isSelect = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void MoveAroundSpawnPosition()
    {
        if (CheckCharacterDoneMove(path) == false)
        {
            WalkCharacter(path);
        }
        else
        {
            path = GenerationNewPath();
        }
    }

    public void MoveToTarget() {
        if (target.Count > 0)
        {
            Vector2 targetPos = new Vector2(target[0].transform.position.x, transform.position.y);
            if (CheckCharacterDoneMove(targetPos) == false)
            {
                WalkCharacter(targetPos);
            }
            else
            {
                switch (characterType) {
                    case CharacterType.Worker:
                        WorkBuild();
                        break;
                    case CharacterType.Lumberjack:
                        WorkChop();
                        break;
                }
            }
        }
    }

    public void WorkBuild() {
        if (indexSend == 0)
        {
            animCharacter.SetBool("Walk", false);
            animCharacter.SetBool("Work", true);
            TimeBuilding = target[0].gameObject.GetComponent<BuildingProcces>().timeBuilding;
            target[0].gameObject.GetComponent<BuildingProcces>().StartCoroutine("WaitAndPrint");
            corutine = WaitWorkProcces(TimeBuilding);
            StartCoroutine(corutine);
            indexSend++;
        }
    }


    public void WorkChop() {
        if (indexSend == 0)
        {
            animCharacter.SetBool("Walk", false);
            if (target[0].gameObject.tag == "Tree") {
                animCharacter.SetBool("Chop", true);
                target[0].gameObject.GetComponent<TreeController>().StartCoroutine("TreeFelling");
                corutine = WaitTreeFelling(target[0].gameObject.GetComponent<TreeController>().timeChop);
                StartCoroutine(corutine);
            }
            if (target[0].gameObject.tag == "Firewood") {
                //animCharacter.SetBool("Collect_Firewood", true);
                StartCoroutine(WaitCollectBrunches());
            }
            indexSend++;
        }
    }

    public void CollectFirewood()
    {
        if (indexSend == 0)
        {
            animCharacter.SetBool("Walk", false);
            animCharacter.SetBool("Chop", true);
            target[0].gameObject.GetComponent<TreeController>().StartCoroutine("TreeFelling");
            corutine = WaitTreeFelling(target[0].gameObject.GetComponent<TreeController>().timeChop);
            StartCoroutine(corutine);
            indexSend++;
        }
    }


    private IEnumerator WaitWorkProcces(float timeWait) {
        yield return new WaitForSeconds(timeWait);
        animCharacter.SetBool("Work", false);
        indexSend = 0;
        yield break;
    }

    private IEnumerator WaitTreeFelling(float timeWait)
    {
        yield return new WaitForSeconds(timeWait);
        animCharacter.SetBool("Chop", false);
        indexSend = 0;
        yield break;
    }

    private IEnumerator  WaitCollectBrunches() {
        yield return new WaitForSeconds(1);
        target[0].gameObject.GetComponent<Branches>().targetTransform = transform;
        target[0].gameObject.GetComponent<Branches>().selectBrunches = true;
        target.Insert(0, targetManager);
        indexSend = 0;
        yield break;
    }

    public void StopWorkProcces() {
        animCharacter.SetBool("Work", false);
        indexSend = 0;
    }

    public void ParticleSystemChop() {
        particleSystemChop.Play();
        audioData.pitch = Random.RandomRange(0.9f, 1.1f);
        audioData.clip = chopAudio;
        audioData.volume = 1f;
        audioData.Play();
    }

    public void AudioWalk() {
        audioData.volume = 0.01f;
        audioData.clip = walkAudio;
        audioData.pitch = Random.RandomRange(0.9f, 1.1f);
        audioData.Play();
    }

    public void BuildCharacter() {
        audioData.volume = 0.4f;
        audioData.clip = buildAudio;
        audioData.pitch = Random.RandomRange(0.9f, 1.1f);
        audioData.Play();
    }
}
