using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb;
    public GameObject player1;
    public Rigidbody2D rb2;
    public GameObject player2;
    int count, count1;
    Color BluePlayerColor = new Color(0f, 0.7529413f, 1f, 1f);//Blue Player Color
    Color RedPlayerColor = new Color(1f, 0.2470588f, 0.003921569f, 1f);//Red Player Color
    public SpriteRenderer sr;
    public Text redScoreText;
    public Text blueScoreText;
    public Text LevelText;
    int score = 0;
    int score2 = 0;
    bool blueFlag = false, redFlag = false;
    bool redMoveFlag = true, blueMoveFlag = true;
    public SpriteRenderer MultiPlatColor;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        count1 = 0;
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            LevelText.text = ("Level: 1");
        }
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            LevelText.text = ("Level: 2");
        }
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            LevelText.text = ("Level: 3");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player1 && redMoveFlag)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                count++;
                rb.gravityScale = 2;
                Push();
            }
            if (Input.GetKey(KeyCode.D))
            {
                player1.transform.position = new Vector3(player1.transform.position.x + 2 * Time.deltaTime, player1.transform.position.y, player1.transform.position.z);
            }
            if (Input.GetKey(KeyCode.A))
            {
                player1.transform.position = new Vector3(player1.transform.position.x - 2 * Time.deltaTime, player1.transform.position.y, player1.transform.position.z);
            }

        }
        if (player2 && blueMoveFlag) 
        { 
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                count1++;
                rb2.gravityScale = 2;
                Push1();
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                player2.transform.position = new Vector3(player2.transform.position.x + 2 * Time.deltaTime, player2.transform.position.y, player2.transform.position.z);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                player2.transform.position = new Vector3(player2.transform.position.x - 2 * Time.deltaTime, player2.transform.position.y, player2.transform.position.z);
            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            count = 0;
            count1 = 0;
        }
        //Death
        if (sr.color == RedPlayerColor && collision.gameObject.tag=="BlueGround")
        {
            //Destroy(collision.gameObject);
            Destroy(GameObject.FindGameObjectWithTag("RedPlayer"));
            SoundManager.PlaySound("GruntVoice02");
            score = 0; 
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                SceneManager.LoadScene("Level1");
                LevelText.text = ("Level: 1");
            }
            if (SceneManager.GetActiveScene().name == "Level2")
            {
                SceneManager.LoadScene("Level2");
                LevelText.text = ("Level: 2");
            }
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                SceneManager.LoadScene("Level3");
                LevelText.text = ("Level: 3");
            }
        }
        if(sr.color == BluePlayerColor && collision.gameObject.tag=="RedGround")
        {
            Destroy(GameObject.FindGameObjectWithTag("BluePlayer")); 
            SoundManager.PlaySound("GruntVoice02");
            score2 = 0;
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                SceneManager.LoadScene("Level1");
                LevelText.text = ("Level: 1");
            }
            if (SceneManager.GetActiveScene().name == "Level2")
            {
                SceneManager.LoadScene("Level2");
                LevelText.text = ("Level: 2");
            }
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                SceneManager.LoadScene("Level3");
                LevelText.text = ("Level: 3");
            }
        }
        //MultiColorMoverDeaths
        if (sr.color == BluePlayerColor && collision.gameObject.tag == "MPRed")
        {
            Destroy(GameObject.FindGameObjectWithTag("BluePlayer"));
            SoundManager.PlaySound("GruntVoice02");
            score2 = 0;
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                SceneManager.LoadScene("Level1");
                LevelText.text = ("Level: 1");
            }
            if (SceneManager.GetActiveScene().name == "Level2")
            {
                SceneManager.LoadScene("Level2");
                LevelText.text = ("Level: 2");
            }
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                SceneManager.LoadScene("Level3");
                LevelText.text = ("Level: 3");
            }
        }

        if (sr.color == RedPlayerColor && collision.gameObject.tag == "MPBlue")
        {
            Destroy(GameObject.FindGameObjectWithTag("RedPlayer"));
            SoundManager.PlaySound("GruntVoice02");
            score = 0;
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                SceneManager.LoadScene("Level1");
                LevelText.text = ("Level: 1");
            }
            if (SceneManager.GetActiveScene().name == "Level2")
            {
                SceneManager.LoadScene("Level2");
                LevelText.text = ("Level: 2");
            }
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                SceneManager.LoadScene("Level3");
                LevelText.text = ("Level: 3");
            }
        }

        //ColorChanger
        if(MultiPlatColor && MultiPlatColor.color==RedPlayerColor && collision.gameObject.tag =="CC2")
        {
            SoundManager.PlaySound("ButtonPress");
            MultiPlatColor.color = BluePlayerColor;
            MultiPlatColor.tag = "MPBlue";
            Destroy(collision.gameObject);
        }

        if (MultiPlatColor && MultiPlatColor.color == BluePlayerColor && collision.gameObject.tag == "CC1")
        {
            SoundManager.PlaySound("ButtonPress");
            MultiPlatColor.color = RedPlayerColor;
            MultiPlatColor.tag = "MPRed";
            Destroy(collision.gameObject);
        }

        //Death from Green
        if (sr.color == RedPlayerColor && collision.gameObject.tag.Contains("Green"))
        {
            Destroy(GameObject.FindGameObjectWithTag("RedPlayer"));
            SoundManager.PlaySound("GruntVoice02");
            score = 0;
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                SceneManager.LoadScene("Level1");
                LevelText.text = ("Level: 1");
            }
            if (SceneManager.GetActiveScene().name == "Level2")
            {
                SceneManager.LoadScene("Level2");
                LevelText.text = ("Level: 2");
            }
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                SceneManager.LoadScene("Level3");
                LevelText.text = ("Level: 3");
            }
        }

        if (sr.color == BluePlayerColor && collision.gameObject.tag.Contains("Green"))
        {
            Destroy(GameObject.FindGameObjectWithTag("BluePlayer"));
            SoundManager.PlaySound("GruntVoice02");
            score2 = 0;
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                SceneManager.LoadScene("Level1");
                LevelText.text = ("Level: 1");
            }
            if (SceneManager.GetActiveScene().name == "Level2")
            {
                SceneManager.LoadScene("Level2");
                LevelText.text = ("Level: 2");
            }
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                SceneManager.LoadScene("Level3");
                LevelText.text = ("Level: 3");
            }
        }

        //Diamonds
        if(sr.color==RedPlayerColor && collision.gameObject.tag=="RDiamond")
        {
            Destroy(collision.gameObject);
            SoundManager.PlaySound("Bonus");
            score++;
            redScoreText.text = ("Score: " + score.ToString());
        }
        if (sr.color == BluePlayerColor && collision.gameObject.tag == "BDiamond")
        {
            Destroy(collision.gameObject);
            SoundManager.PlaySound("Bonus");
            score2++;
            blueScoreText.text = ("Score: " + score2.ToString());
        }

        //WinningConditions
        Vector3 rpos = player1.transform.position;
        Vector3 bpos = player2.transform.position;
        Vector3 v1 = new Vector3(6.215f, 2.871f, 0f);
        Vector3 v2 = new Vector3(7.29f, 2.871f, 0f);
        float distance1 = Vector3.Distance(rpos, v2);
        float distance2 = Vector3.Distance(bpos, v1);

        if (distance1<1)
        {
            Debug.Log("Red Home");
            redFlag = true;
        }
        if(distance2<1)
        {
            Debug.Log("Blue Home");
            blueFlag = true;
        }

        if(redFlag && blueFlag)
        {
            if(SceneManager.GetActiveScene().name=="Level1")
            {
                SceneManager.LoadScene("Level2");
                LevelText.text = ("Level: 2");
            }
            if (SceneManager.GetActiveScene().name == "Level2")
            {
                SceneManager.LoadScene("Level3");
                LevelText.text = ("Level: 3");
            }
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                SceneManager.LoadScene("Level1");
                LevelText.text = ("Level: 1");
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Contains("MovingPlatform"))
        {
            count = 0;
            count1 = 0;
            player1.transform.parent = collision.gameObject.transform;
            player2.transform.parent = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("MovingPlatform"))
        {
            player1.transform.parent = null;
            player2.transform.parent = null;
        }
    }

    void Push()
    {
        if(count>3)
        {
            return;
        }
        SoundManager.PlaySound("Whoosh");
        rb.velocity = new Vector2(0, 1 * 5);
    }

    void Push1()
    {
        if(count1>3)
        {
            return;
        }
        SoundManager.PlaySound("Whoosh");
        rb2.velocity = new Vector2(0, 1 * 5);
    }
}
