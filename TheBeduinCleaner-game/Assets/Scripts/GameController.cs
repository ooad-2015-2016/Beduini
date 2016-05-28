using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    private float maxWidth;
    public Camera cam;

    public GameObject sto;
	public GameObject sto_sivi;
	public GameObject sto_crveni;
	public GameObject sto_bonus;
	public GameObject sendvic;
	public GameObject tanjir;
	public GameObject kupac;

    public GameObject gameOverBtn;
    public GameObject gameOverTxt;
    public GameObject naslov;
    public GameObject startBtn;

    public float timeLeft = 0.0f;
    public Text timer;

    // Use this for initialization
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }

        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float stoWidth = sto.GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - stoWidth;
        
    }

    public void StartGame()
    {
		timeLeft = 30;

        naslov.SetActive(false);
        startBtn.SetActive(false);

        StartCoroutine(Spawn());
		StartCoroutine(SpawnSivi());
		StartCoroutine(SpawnCrveni());
		StartCoroutine(SpawnBonus());
		StartCoroutine(SpawnSendvic());
		StartCoroutine(SpawnTanjir());
		StartCoroutine(SpawnKupac());
    }

    void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0) timeLeft = 0.0f;
        timer.text = "Preostalo vremena:\n" + Mathf.RoundToInt(timeLeft).ToString();
        
    }

	IEnumerator SpawnConstruct(GameObject ob, float range_start, float range_end){

        while (timeLeft > 0)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-maxWidth, maxWidth), transform.position.y, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(ob, spawnPos, spawnRotation);
            yield return new WaitForSeconds(Random.Range(range_start, range_end));
        }
		
	}

    IEnumerator Spawn()
    {
        
        yield return new WaitForSeconds(2.0f);
        while (timeLeft > 0)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-maxWidth, maxWidth), transform.position.y, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(sto, spawnPos, spawnRotation);
            yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
        }

        yield return new WaitForSeconds(2);
        gameOverTxt.SetActive(true);
        yield return new WaitForSeconds(1);
        gameOverBtn.SetActive(true);
    }

	IEnumerator SpawnSivi() {
        while (timeLeft > 0)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-maxWidth, maxWidth), transform.position.y, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(sto_sivi, spawnPos, spawnRotation);
            yield return new WaitForSeconds(Random.Range(2.0f, 4.0f));
        }
    }

    IEnumerator SpawnCrveni()
    {
        while (timeLeft > 0)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-maxWidth, maxWidth), transform.position.y, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(sto_crveni, spawnPos, spawnRotation);
            yield return new WaitForSeconds(Random.Range(3.0f, 8.0f));
        }
    }

    IEnumerator SpawnBonus()
    {
        while (timeLeft > 0)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-maxWidth, maxWidth), transform.position.y, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(sto_bonus, spawnPos, spawnRotation);
            yield return new WaitForSeconds(Random.Range(10.0f, 30.0f));
        }
    }

    IEnumerator SpawnSendvic()
    {
        while (timeLeft > 0)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-maxWidth, maxWidth), transform.position.y, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(sendvic, spawnPos, spawnRotation);
            yield return new WaitForSeconds(Random.Range(5.0f, 15.0f));
        }
    }

    IEnumerator SpawnTanjir()
    {
        while (timeLeft > 0)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-maxWidth, maxWidth), transform.position.y, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(tanjir, spawnPos, spawnRotation);
            yield return new WaitForSeconds(Random.Range(0.6f, 8.0f));
        }
    }

    IEnumerator SpawnKupac()
    {
        while (timeLeft > 0)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-maxWidth, maxWidth), transform.position.y, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(kupac, spawnPos, spawnRotation);
            yield return new WaitForSeconds(Random.Range(2.0f, 5.0f));
        }
    }


    

}
