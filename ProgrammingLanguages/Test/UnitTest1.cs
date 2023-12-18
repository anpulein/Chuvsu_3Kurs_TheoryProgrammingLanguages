using LexicalAnalysis.Workers;

namespace Test;

public class Tests
{
    private string _inFile;
    private string _outFile;
    
    [SetUp]
    public void Setup()
    {
        _inFile = "/Users/anpulein/Documents/Projects/Chuvsu/Chuvsu_3Kurs_TheoryProgrammingLanguages/ProgrammingLanguages/LexicalAnalysis/Test/In.txt";
        _outFile = "/Users/anpulein/Documents/Projects/Chuvsu/Chuvsu_3Kurs_TheoryProgrammingLanguages/ProgrammingLanguages/LexicalAnalysis/Test/Out.txt";
    }

    [Test]
    public void Test1()
    {
        
        var lexAnal = new LexicalAnalyzer(_inFile);
        
        lexAnal.Analyze();
        
        lexAnal.Write(_outFile);
        
        Assert.Pass();
    }
}