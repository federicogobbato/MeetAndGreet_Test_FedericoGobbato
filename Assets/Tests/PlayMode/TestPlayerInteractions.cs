using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class TestPlayerInteractions
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// The player jumps randomly and try to catch a token
    /// </summary>
    [UnityTest]
    public IEnumerator Test_CollectToken()
    {
        yield return new WaitForSeconds(1.0f);

        GameObject player = GameObject.Find("Player");
        PlayerController playerController = player.GetComponent<PlayerController>();
        var tokenController = GameObject.FindObjectOfType<TokenController>();

        Vector3 initPosition = player.transform.position;
        float maxHumpHeight = playerController.model.jumpModifier;
        float forceToEnd = 0;

        while (tokenController.collectedTokens == 0)
        {
            player.transform.position += new Vector3(0.01f, 0.0f, 0.0f);

            //Set Randomly the y position between max jump height and the y init position
            Vector3 newPosition = player.transform.position;
            newPosition.y = Random.Range(initPosition.y, maxHumpHeight);
            player.transform.position = newPosition;

            //The test is shut down after 10 seconds
            forceToEnd += Time.deltaTime;
            if (forceToEnd >= 10)
            {
                Assert.Fail("Time out, no token collected.");
            }
            yield return null;
        }

        Assert.AreEqual(1, tokenController.collectedTokens, "No token collected, something went wrong.");
    }
}
