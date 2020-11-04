using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    #region variables
    [Header("AudioClips")]
    public AudioClip RotateSound;
    public AudioClip LosingSound;
    [Space]
    bool isPlayerDead;
    [Space]
    // THis is for moving my cube constantly
    [Header("Player Movement Variables")]
    public Vector3 movePos = new Vector3(0.85f, 0f, 0f);
    public Vector3 newPos = new Vector3(0f, 0f, 0.7f);
    [Space]
    public GameObject cubeDieEffect;
    #endregion
    private void Start()
    {
        isPlayerDead = false;
    }
    private void CubeDie()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void Update()
    {

        // Checking If The User Pressed Button
        if (!PauseingTheGame.paused && !isPlayerDead)
        {
            transform.position += movePos;
            if (Input.GetButton("Left"))
            {
                transform.position += newPos;
            }
            if (Input.GetButton("Right"))
            {
                transform.position -= newPos;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                RotateLeft();
                AudioSource.PlayClipAtPoint(RotateSound, transform.position, 1f);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                RotateRight();
                AudioSource.PlayClipAtPoint(RotateSound, transform.position, 1f);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Barrier")
        {
            isPlayerDead = true;
            cubeDieEffect.SetActive(true);
            AudioSource.PlayClipAtPoint(LosingSound, transform.position, 1f);
            Invoke("CubeDie", 1f);
        }
        if (other.tag == "LavaBarrier")
        {
            isPlayerDead = true;
            cubeDieEffect.SetActive(true);
            AudioSource.PlayClipAtPoint(LosingSound, transform.position, 1f);
            Invoke("CubeDie", 1f);
        }
        if (other.tag == "Finish")
        {
            int saveLevel = PlayerPrefs.GetInt("unlockedLevel", 1);
            switch (SceneManager.GetActiveScene().buildIndex)
            {
                case 3:
                    if (saveLevel == 1)
                    {
                        PlayerPrefs.SetInt("unlockedLevel", 2);
                        PlayerPrefs.Save();
                    }
                    break;

                case 6:
                    if (saveLevel == 2)
                    {
                        PlayerPrefs.SetInt("unlockedLevel", 3);
                        PlayerPrefs.Save();
                    }
                    break;

                case 9:
                    if (saveLevel == 3)
                    {
                        PlayerPrefs.SetInt("unlockedLevel", 4);
                        PlayerPrefs.Save();
                    }
                    break;

                case 12:
                    if (saveLevel == 4)
                    {
                        PlayerPrefs.SetInt("unlockedLevel", 5);
                        PlayerPrefs.Save();
                    }
                    break;
            }

            PlayerPrefs.Save();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
    public void RotateLeft()
    {
        transform.Rotate(0f, -90f, 0f);
        if (movePos.x != 0f)
        {
            movePos.x = 0f;
            movePos.z += 0.85f;
            newPos.z = 0f;
            newPos.x -= 0.7f;
        }
        else
        {
            movePos.z = 0f;
            movePos.x = 0.85f;
            newPos.x = 0f;
            newPos.z = 0.7f;
        }
    }
    public void RotateRight()
    {
        transform.Rotate(0f, 90f, 0f);
        if (movePos.x != 0f)
        {
            movePos.x = 0f;
            movePos.z -= 0.85f;
            newPos.z = 0f;
            newPos.x -= -0.7f;
        }
        else
        {
            movePos.z = 0f;
            movePos.x = 0.85f;
            newPos.x = 0f;
            newPos.z = 0.7f;
        }
    }

}