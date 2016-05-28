using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    public Text scoreText;
    public int crniStoVal = 1;

    private int score;

	// Use this for initialization
	void Start () {
        score = 0;
        UpdateScore();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "crni_sto(Clone)") score += 1;
        if (other.gameObject.name == "crveni_sto(Clone)") score -= 5;
        if (other.gameObject.name == "sivi_sto(Clone)") score += 2;
        if (other.gameObject.name == "bonus_sto(Clone)") score += 10;
        if (other.gameObject.name == "kupac_box(Clone)") score -= 3;
        if (other.gameObject.name == "sendvic_box(Clone)") score += 3;
        if (other.gameObject.name == "tanjir(Clone)") score += 20;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
