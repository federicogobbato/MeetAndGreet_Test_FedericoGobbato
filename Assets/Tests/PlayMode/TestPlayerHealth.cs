using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Platformer.Mechanics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class TestPlayerHealth
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene(0);
    }


    [UnityTest]
    public IEnumerator Test_CurrentPlayerHealth()
    {
        GameObject player = GameObject.Find("Player");

        Health controllerHealth = player.GetComponent<Health>();

        for(int i = 0; i < controllerHealth.maxHP; ++i)
        {
            controllerHealth.Decrement();
            yield return null;
        }

        Assert.AreEqual(controllerHealth.currentHP, 0, "Current health is not zero.");
    }
}
