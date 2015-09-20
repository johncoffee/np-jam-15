using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartUpController : MonoBehaviour
{
    public GameObject server;
    public Text screenText;
    private bool selected = false;
	// Update is called once per frame
	void Update ()
    {
        if (selected)
            return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(StartDelayed(1));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(StartDelayed(2));
        }
    }

    IEnumerator StartDelayed(int player)
    {
        selected = true;
        PlayerManager.isPlayerOne = player == 1;

        if (player == 1)
        {
            server.SetActive(true);
            DontDestroyOnLoad(server);
        }

        screenText.text = "Starting " + (player == 1 ? "in front." : "behind.");

        yield return new WaitForSeconds(3);

        Application.LoadLevel(1);
    }
}
