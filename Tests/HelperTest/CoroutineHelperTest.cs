using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Helpers;
using NUnit.Framework;
using UnityEditor.Compilation;
using UnityEngine;
using UnityEngine.TestTools;

public class CoroutineHelperTest
{
    [SetUp]
    public void SetUp()
    {
        Bonjour = string.Empty;
    }

    // A Test behaves as an ordinary method
    [Test]
    public void NewTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
        
    }

    
    //[UnityTest]
    public IEnumerator TestCoroutineChaining()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        CoroutineHelper.ChainCoroutines(
            Say("Bo", 1),
            Say("nj", 100),
            Say("ou", 1),
            Say("r", 1),
            TestCheckCoroutine(nameof(Bonjour))
        );
        //yield return new WaitForSeconds(1);
        yield return null;
        Assert.That(Bonjour, Is.EqualTo(nameof(Bonjour)));
    }
    //TODO: find a proper way to test coroutine stuff ?
    private volatile string Bonjour = String.Empty;

    private IEnumerator Say(string what, float waitTime)
    {
        if (Bonjour != null) Bonjour = Bonjour + what;
        yield return new WaitForSeconds(waitTime / 100);
    }

    private IEnumerator TestCheckCoroutine(string valueExpected)
    {
        yield return null;
        Assert.That(Bonjour, Is.EqualTo(valueExpected));
        Assert.Pass("Test ran successfully - Coroutines validated");
    }

}
