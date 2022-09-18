using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Platformer.Mechanics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class TestHitEnemy
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Checks if the player health is updated when hit an enemy
    /// </summary>
    [UnityTest]
    public IEnumerator Test_PlayerHealthOnHitEnemy()
    {
        yield return new WaitForSeconds(1.0f);

        GameObject player = GameObject.Find("Player");

        Health controllerHealth = player.GetComponent<Health>();
        controllerHealth.maxHP = 1;

        float forceToEnd = 0;

        while (controllerHealth.currentHP > 0)
        {
            player.transform.position += new Vector3(0.01f, 0.0f, 0.0f);

            //The test is shut down after 10 seconds
            forceToEnd += Time.deltaTime;
            if (forceToEnd >= 10)
            {
                Assert.AreEqual(0, controllerHealth.currentHP, "Time out, maybe not enemy found.");
            }
            yield return null;
        }

        Assert.AreEqual(0, controllerHealth.currentHP, "Current health is not zero, something went wrong.");
    }
}
