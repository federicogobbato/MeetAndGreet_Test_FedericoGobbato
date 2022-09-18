using System;
using UnityEditor;
using UnityEditor.TestTools.TestRunner.Api;
using UnityEngine;

public static class RunTests 
{
    [MenuItem("CustomTestRunner/EditModeTests")]
    static void EditMode()
    {
        Run(TestMode.EditMode);
    }

    [MenuItem("CustomTestRunner/PlayModeTests")]
    static void PlayMode()
    {
        Run(TestMode.PlayMode);
    }

    private static void Run(TestMode testModeToRun)
    {
        var testRunnerApi = ScriptableObject.CreateInstance<TestRunnerApi>();
        var filter = new Filter()
        {
            testMode = testModeToRun
        };

        testRunnerApi.Execute(new ExecutionSettings(filter));
    }

}
