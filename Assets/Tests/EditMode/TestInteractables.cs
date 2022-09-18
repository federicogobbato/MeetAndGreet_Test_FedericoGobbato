using NUnit.Framework;
using System;
using UnityEngine;


public class TestInteractables
{
    /// <summary>
    /// Checks if the gameObejcts with the tag Interactable are too close,
    /// in the meantime checks if there are duplicated object in the same position.
    /// </summary>
    [Test]
    public void Test_DistanceInteractables()
    {
        var objects = GameObject.FindGameObjectsWithTag("Interactable");
        bool someInteractableAreTooClose = false;

        for (int i = 0; i < objects.Length; i++)
        {
            for (int j = i + 1; j < objects.Length; j++)
            {
                float radius1 = objects[i].GetComponent<CircleCollider2D>().radius;
                float radius2 = objects[i].GetComponent<CircleCollider2D>().radius;
                float minumDistance = radius1 + radius2 + 0.1f;
                float objectsDistance = Vector2.Distance(objects[i].transform.position, objects[j].transform.position);

                if (objectsDistance < minumDistance)
                {
                    someInteractableAreTooClose = true;
                    var message = $"Interactable at pos {objects[i].transform.position} and " +
                                    $"one at pos {objects[j].transform.position} are too close. " +
                                    $"Distance: {objectsDistance}"; 
                    Debug.LogWarning(message);
                }

                //var message = $"GameObjet at pos {objects[i].transform.position} and " +
                //              $"GameObjet at pos {objects[j].transform.position} are too close." +
                //              $"Distance {objectsDistance}";
                //Assert.GreaterOrEqual(objectsDistance, minumDistance, message);
            }
        }

        if (someInteractableAreTooClose)
            Assert.Fail("Some interactables are too close. (see log)");
    }
}



