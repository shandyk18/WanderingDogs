using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D Player;
    public Transform level;

    public GameObject Camera;
    private Rigidbody2D CameraRB;
    private Camera cam;

    public Text Score;
    public Text FinalScore;
    public Button PlayAgainButton;
    public RectTransform GameOver;

    private float minY = -4.5f, maxY = -3.5f, nextLvl = 0f, highest, dist = 1.5f;
    public float camSpeed = 1;
    private int score = 0;

    public bool switched = false;
    public bool diagonal = false;

    public AudioSource audioSource;
    public AudioClip upAudio;
    public AudioClip endAudio;

    public float lastPosition;

    void Start()
    {
        CameraRB = Camera.GetComponent<Rigidbody2D>();
        cam = Camera.GetComponent<Camera>();
        Time.timeScale = 1f;
        GameOver.gameObject.SetActive(false);
        PlayAgainButton = PlayAgainButton.GetComponent<Button>();
        highest = transform.position.y - 1.5f;
        Score.text = "Score: " + score;
        audioSource = GetComponent<AudioSource>();
        lastPosition = transform.position.y;
    }

    void Update()
    {
        //Keeps the dog on the world in the X-axis and stops it from going too far down.
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7f, 7f),
        	Mathf.Clamp(transform.position.y, minY, maxY));
        onUpAudio();

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && maxY - transform.position.y >= 1.5f)
        {
            if (!switched)
            {

                if (diagonal)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + dist);
                    OnMoveUp();
                    //Camera.parent = null;
                    transform.position = new Vector2(transform.position.x + 1f, transform.position.y);
                }
                else
                {
                    Player.MovePosition(Player.position + Vector2.up * dist);
                    OnMoveUp();
                }
            }
            else
            {

                if (diagonal)
                {
                    //Camera.parent = null;
                    transform.position = new Vector2(transform.position.x, transform.position.y - dist);
                    transform.position = new Vector2(transform.position.x - 1f, transform.position.y);
                }
                else
                {
                    //Camera.parent = null;
                    Player.MovePosition(Player.position + Vector2.down * dist);
                }
            }

        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {

            if (!switched)
            {

                if (diagonal)
                {
                    //Camera.parent = null;
                    transform.position = new Vector2(transform.position.x, transform.position.y - dist);
                    transform.position = new Vector2(transform.position.x - 1f, transform.position.y);
                }
                else
                {
                    //Camera.parent = null;
                    Player.MovePosition(Player.position + Vector2.down * dist);
                }

            }
            else
            {

                if (diagonal)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + dist);
                    OnMoveUp();
                    //Camera.parent = null;
                    transform.position = new Vector2(transform.position.x + 1f, transform.position.y);
                }
                else
                {
                    Player.MovePosition(Player.position + Vector2.up * dist);
                    OnMoveUp();
                }
            }

        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (!switched)
            {

                if (diagonal)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + dist);
                    OnMoveUp();
                    //Camera.parent = null;
                    transform.position = new Vector2(transform.position.x - 1f, transform.position.y);

                }
                else
                {
                    //Camera.parent = null;
                    Player.MovePosition(Player.position + Vector2.left);
                }
            }
            else
            {

                if (diagonal)
                {
                    //Camera.parent = null;
                    transform.position = new Vector2(transform.position.x + 1f, transform.position.y);
                    transform.position = new Vector2(transform.position.x, transform.position.y - dist);
                }
                else
                {
                    //Camera.parent = null;
                    Player.MovePosition(Player.position + Vector2.right);
                }
            }

        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (!switched)
            {
                if (diagonal)
                {
                    //Camera.parent = null;
                    transform.position = new Vector2(transform.position.x + 1f, transform.position.y);
                    transform.position = new Vector2(transform.position.x, transform.position.y - dist);
                }
                else
                {
                    //Camera.parent = null;
                    Player.MovePosition(Player.position + Vector2.right);
                }
            }
            else
            {

                if (diagonal)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + dist);
                    OnMoveUp();
                    //Camera.parent = null;
                    transform.position = new Vector2(transform.position.x - 1f, transform.position.y);

                }
                else
                {
                    //Camera.parent = null;
                    Player.MovePosition(Player.position + Vector2.left);
                }
            }

        }

        //Manually reset level
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //Spawns next segment once player is past the center of the current world tile.
        if (Camera.transform.position.y >= nextLvl - 1f)
        {
            nextLvl += 9f;

            level = Instantiate(level, new Vector2(0, nextLvl), Quaternion.identity);
            level.tag = "New";
            GameObject toDestroy = GameObject.FindWithTag("Previous");
            if (toDestroy)
            {
                //Destroy(toDestroy);
            }
            GameObject.FindWithTag("Current").tag = "Previous";
            GameObject.FindWithTag("New").tag = "Current";
        }

        //Camera Movement
        if (score >= 1) {
            CameraRB.velocity = Vector2.up * camSpeed;
        }
        Vector3 screenPoint = cam.WorldToViewportPoint(transform.position);
        bool onScreen = screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0;
        if (!onScreen) {
            OnDeath("screen");
        }

        maxY = cam.ViewportToWorldPoint(new Vector3(0, 1, cam.nearClipPlane)).y - 0.5f;

    }

    void OnMoveUp()
    {
        //Updates score if the player moves above the previous highest Y-value.
        if (transform.position.y > highest)
        {
            Debug.Log("Highscore");
            score++;
            Score.text = "Score: " + score;
            highest = transform.position.y;
        }
    }

    //Displays final score and resets the level upon hitting a car.
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Car")
        {
            OnDeath("car");
        }
    }

    public void OnDeath(string text)
    {
        //Debug.Log("Oh noes we died");
        GameOver.gameObject.SetActive(true);
        Time.timeScale = 0;
        Score.text = "";
        if (text == "car")
        {
            FinalScore.text = "That's going to be " + Random.Range(2, 10) + " years in a wheelchair now...";
        }
        else if (text == "screen")
        {
            FinalScore.text = "You clearly didn't love her enough...";
        }
        audioSource.PlayOneShot(endAudio, 1.0f);
        FinalScore.text += "\nFinal Score: " + score;
    }

    public void OnclickRestart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SwitchControls()
    {
        switched = !switched;
    }

    public void MoveDiagonal()
    {
        diagonal = !diagonal;
    }

    public void onUpAudio()
    {
        if (transform.position.y > lastPosition)
        {
            audioSource.PlayOneShot(upAudio, 0.8f);
            lastPosition = transform.position.y;
        }
        else if(transform.position.y < lastPosition)
        {
            lastPosition = transform.position.y;
        }
        else
        {
        }
    }
}