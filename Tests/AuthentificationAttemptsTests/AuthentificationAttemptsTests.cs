using NUnit.Framework;

namespace Tasks.Tests;

public class AuthentificationAttemptsTests
{
    [Test]
    public void TestAuthenticate_CorrectLoginAndPassword_ShouldReturnTrue()
    {
        var auth = new AuthentificationAttempts("King", "Lion");
        var result = auth.Authenticate("King", "Lion");
        Assert.That(result.IsAuthenticated, Is.True);
        Assert.That(result.TriesRemaining, Is.EqualTo(3));
    }
    
    [Test]
    public void TestAuthenticate_InCorrectLoginAndPassword_ShouldReturnFalse()
    {
        var auth = new AuthentificationAttempts("King", "Lion");
        var result = auth.Authenticate("Prince", "Lion");
        Assert.That(result.IsAuthenticated, Is.False);
        Assert.That(result.TriesRemaining, Is.EqualTo(2));
    }

    [Test]
    public void TheTriesAreOver_AfterMaxFailedAttempts()
    {
        var auth = new AuthentificationAttempts("Martin", "Luter");

        auth.Authenticate("Gloria", "Luter");
        auth.Authenticate("Martin", "Muller");
        var result = auth.Authenticate("Martin", "Nuter");
        
        Assert.That(result.IsAuthenticated, Is.False);
        Assert.That(result.TriesRemaining, Is.EqualTo(0));
    }
    
    [Test]
    public void ShouldResetTriesCount_AfterSuccessfulLogin()
    {
        var auth = new AuthentificationAttempts("Martin", "Luter");

        auth.Authenticate("Gloria", "Luter");
        auth.Authenticate("Martin", "Muller");
        var result = auth.Authenticate("Martin", "Luter");
        
        Assert.That(result.IsAuthenticated, Is.True);
        Assert.That(result.TriesRemaining, Is.EqualTo(3));
    }
    
    [Test]
    public void PropertyFalseAutentificationAttempts()
    {
        var auth = new AuthentificationAttempts("King", "Lion");
        var result = auth.Authenticate("Prince", "Lion");
        Assert.That(result.IsAuthenticated, Is.False);
    }
    
    [Test]
    public void PropertyTrueAutentificationAttempts()
    {
        var auth = new AuthentificationAttempts("King", "Lion");
        var result = auth.Authenticate("King", "Lion");
        Assert.That(result.IsAuthenticated,Is.True);
    }
}