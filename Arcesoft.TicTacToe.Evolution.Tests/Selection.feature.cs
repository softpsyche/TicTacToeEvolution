﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Arcesoft.TicTacToe.Evolution.Tests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class SelectionFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Selection.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Selection", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
                    "f two numbers", ProgrammingLanguage.CSharp, new string[] {
                        "Behavioral"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Selection")))
            {
                global::Arcesoft.TicTacToe.Evolution.Tests.SelectionFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(TestContext);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 7
#line 8
 testRunner.Given("I have a container", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.Given("I have a tictactoe factory", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Match builder should build many matches correctly")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Selection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        public virtual void MatchBuilderShouldBuildManyMatchesCorrectly()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Match builder should build many matches correctly", ((string[])(null)));
#line 11
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 12
 testRunner.Given("I have a match builder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 13
 testRunner.Given("I have \'50\' individuals", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
 testRunner.When("I repeat the test \'500\' times using \'5\' tournaments and \'50\' individuals", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void MatchBuilderShouldBuildMatchesForA(string name, string individuals, string tournaments, string expectedTournaments, string expectedMatches, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Match builder should build matches for a", exampleTags);
#line 16
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 17
 testRunner.Given("I have a match builder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
 testRunner.Given(string.Format("I have \'{0}\' individuals", individuals), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
 testRunner.When(string.Format("I build matches with \'{0}\' tournaments for my given individuals", tournaments), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
 testRunner.Then(string.Format("I expect all given individuals to have at least \'{0}\' tournaments each", expectedTournaments), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
 testRunner.Then(string.Format("I expect the number of matches to be at least \'{0}\'", expectedMatches), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Match builder should build matches for a: tiny set")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Selection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "tiny set")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Name", "tiny set")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Individuals", "2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Tournaments", "1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ExpectedTournaments", "1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ExpectedMatches", "2")]
        public virtual void MatchBuilderShouldBuildMatchesForA_TinySet()
        {
#line 16
this.MatchBuilderShouldBuildMatchesForA("tiny set", "2", "1", "1", "2", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Match builder should build matches for a: small set")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Selection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "small set")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Name", "small set")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Individuals", "4")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Tournaments", "3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ExpectedTournaments", "3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ExpectedMatches", "12")]
        public virtual void MatchBuilderShouldBuildMatchesForA_SmallSet()
        {
#line 16
this.MatchBuilderShouldBuildMatchesForA("small set", "4", "3", "3", "12", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Match builder should build matches for a: medium set")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Selection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "medium set")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Name", "medium set")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Individuals", "20")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Tournaments", "6")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ExpectedTournaments", "6")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ExpectedMatches", "120")]
        public virtual void MatchBuilderShouldBuildMatchesForA_MediumSet()
        {
#line 16
this.MatchBuilderShouldBuildMatchesForA("medium set", "20", "6", "6", "120", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Match builder should build matches for a: large set")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Selection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "large set")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Name", "large set")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Individuals", "100")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Tournaments", "5")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ExpectedTournaments", "5")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ExpectedMatches", "500")]
        public virtual void MatchBuilderShouldBuildMatchesForA_LargeSet()
        {
#line 16
this.MatchBuilderShouldBuildMatchesForA("large set", "100", "5", "5", "500", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Match builder should build matches for a: huge set")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Selection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "huge set")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Name", "huge set")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Individuals", "1000")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Tournaments", "6")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ExpectedTournaments", "6")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ExpectedMatches", "6000")]
        public virtual void MatchBuilderShouldBuildMatchesForA_HugeSet()
        {
#line 16
this.MatchBuilderShouldBuildMatchesForA("huge set", "1000", "6", "6", "6000", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Match builder should build matches for a: set with too many tournaments")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Selection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "set with too many tournaments")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Name", "set with too many tournaments")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Individuals", "10")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Tournaments", "15")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ExpectedTournaments", "9")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ExpectedMatches", "90")]
        public virtual void MatchBuilderShouldBuildMatchesForA_SetWithTooManyTournaments()
        {
#line 16
this.MatchBuilderShouldBuildMatchesForA("set with too many tournaments", "10", "15", "9", "90", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Match builder should build matches for a: invalid set")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Selection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "invalid set")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Name", "invalid set")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Individuals", "3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Tournaments", "1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ExpectedTournaments", "1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ExpectedMatches", "3")]
        public virtual void MatchBuilderShouldBuildMatchesForA_InvalidSet()
        {
#line 16
this.MatchBuilderShouldBuildMatchesForA("invalid set", "3", "1", "1", "3", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Match evaluator should evaluate when there are no moves")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Selection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        public virtual void MatchEvaluatorShouldEvaluateWhenThereAreNoMoves()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Match evaluator should evaluate when there are no moves", ((string[])(null)));
#line 32
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 33
 testRunner.Given("I have a match evaluator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table1.AddRow(new string[] {
                        "John"});
            table1.AddRow(new string[] {
                        "Sally"});
#line 34
 testRunner.Given("I have the following individuals", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "PlayerXName",
                        "PlayerOName"});
            table2.AddRow(new string[] {
                        "John",
                        "Sally"});
#line 38
 testRunner.Given("I create matches for the following individuals", ((string)(null)), table2, "Given ");
#line 41
 testRunner.When("I evaluate the matches", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "IndividualName",
                        "Player",
                        "MetricType"});
            table3.AddRow(new string[] {
                        "John",
                        "X",
                        "LostDueToNoMoves"});
            table3.AddRow(new string[] {
                        "Sally",
                        "O",
                        "WonDueToNoMoves"});
#line 42
 testRunner.Then("I expect the ledger to contain", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Match evaluator should evaluate WonDueToNoMoves/LostDueToNoMoves for player X/O")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Selection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        public virtual void MatchEvaluatorShouldEvaluateWonDueToNoMovesLostDueToNoMovesForPlayerXO()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Match evaluator should evaluate WonDueToNoMoves/LostDueToNoMoves for player X/O", ((string[])(null)));
#line 47
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 48
 testRunner.Given("I have a match evaluator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table4.AddRow(new string[] {
                        "John"});
            table4.AddRow(new string[] {
                        "Sally"});
#line 49
 testRunner.Given("I have the following individuals", ((string)(null)), table4, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        "",
                        ""});
            table5.AddRow(new string[] {
                        "",
                        "",
                        "D"});
            table5.AddRow(new string[] {
                        "D",
                        "R",
                        ""});
            table5.AddRow(new string[] {
                        "",
                        "D",
                        ""});
#line 53
 testRunner.Given("I add a gene to individual \'John\' for turn \'First\' with priority \'1\' and the foll" +
                    "owing alleles", ((string)(null)), table5, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        "",
                        ""});
            table6.AddRow(new string[] {
                        "R",
                        "",
                        ""});
            table6.AddRow(new string[] {
                        "",
                        "D",
                        ""});
            table6.AddRow(new string[] {
                        "",
                        "",
                        ""});
#line 58
 testRunner.Given("I add a gene to individual \'Sally\' for turn \'Second\' with priority \'1\' and the fo" +
                    "llowing alleles", ((string)(null)), table6, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        "",
                        ""});
            table7.AddRow(new string[] {
                        "O",
                        "",
                        ""});
            table7.AddRow(new string[] {
                        "",
                        "X",
                        "R"});
            table7.AddRow(new string[] {
                        "",
                        "",
                        ""});
#line 63
 testRunner.Given("I add a gene to individual \'John\' for turn \'Third\' with priority \'1\' and the foll" +
                    "owing alleles", ((string)(null)), table7, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "PlayerXName",
                        "PlayerOName"});
            table8.AddRow(new string[] {
                        "John",
                        "Sally"});
#line 68
 testRunner.Given("I create matches for the following individuals", ((string)(null)), table8, "Given ");
#line 71
 testRunner.When("I evaluate the matches", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "IndividualName",
                        "Player",
                        "MetricType",
                        "Description"});
            table9.AddRow(new string[] {
                        "John",
                        "X",
                        "Moved",
                        "Moved to \'Center\' for board _________"});
            table9.AddRow(new string[] {
                        "Sally",
                        "O",
                        "Moved",
                        "Moved to \'NorthWest\' for board ____X____"});
            table9.AddRow(new string[] {
                        "John",
                        "X",
                        "Moved",
                        "Moved to \'Eastern\' for board O___X____"});
            table9.AddRow(new string[] {
                        "Sally",
                        "O",
                        "LostDueToNoMoves",
                        "Lost due to no move for board O___XX___"});
            table9.AddRow(new string[] {
                        "John",
                        "X",
                        "WonDueToNoMoves",
                        "Won due to no move for board O___XX___"});
#line 72
 testRunner.Then("I expect the ledger to contain", ((string)(null)), table9, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Match evaluator should evaluate WonDueToNoMoves/LostDueToNoMoves for player O/X")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Selection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        public virtual void MatchEvaluatorShouldEvaluateWonDueToNoMovesLostDueToNoMovesForPlayerOX()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Match evaluator should evaluate WonDueToNoMoves/LostDueToNoMoves for player O/X", ((string[])(null)));
#line 80
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Match evaluator should evaluate win/loss game for player X/O")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Selection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        public virtual void MatchEvaluatorShouldEvaluateWinLossGameForPlayerXO()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Match evaluator should evaluate win/loss game for player X/O", ((string[])(null)));
#line 82
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Match evaluator should evaluate win/loss game for player O/X")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Selection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        public virtual void MatchEvaluatorShouldEvaluateWinLossGameForPlayerOX()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Match evaluator should evaluate win/loss game for player O/X", ((string[])(null)));
#line 84
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Match evaluator should evaluate tie game")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Selection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        public virtual void MatchEvaluatorShouldEvaluateTieGame()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Match evaluator should evaluate tie game", ((string[])(null)));
#line 86
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("AllOrNothing Fitness evaluator should evaluate fitness")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Selection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        public virtual void AllOrNothingFitnessEvaluatorShouldEvaluateFitness()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("AllOrNothing Fitness evaluator should evaluate fitness", ((string[])(null)));
#line 90
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 91
 testRunner.Given("I have a container", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 92
 testRunner.Given("I mock the match builder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id"});
            table10.AddRow(new string[] {
                        "00000000-0000-0000-0000-000000000000"});
#line 93
 testRunner.Given("I setup the match builder build method to return the following matches", ((string)(null)), table10, "Given ");
#line 96
 testRunner.Given("I mock the match evaluator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "MatchId",
                        "IndividualId",
                        "MetricType"});
            table11.AddRow(new string[] {
                        "10000000-0000-0000-0000-000000000000",
                        "10000000-0000-0000-0000-000000000000",
                        "Moved"});
            table11.AddRow(new string[] {
                        "10000000-0000-0000-0000-000000000000",
                        "10000000-0000-0000-0000-000000000000",
                        "Lost"});
            table11.AddRow(new string[] {
                        "20000000-0000-0000-0000-000000000000",
                        "10000000-0000-0000-0000-000000000000",
                        "Moved"});
            table11.AddRow(new string[] {
                        "20000000-0000-0000-0000-000000000000",
                        "10000000-0000-0000-0000-000000000000",
                        "LostDueToNoMoves"});
            table11.AddRow(new string[] {
                        "30000000-0000-0000-0000-000000000000",
                        "10000000-0000-0000-0000-000000000000",
                        "Moved"});
            table11.AddRow(new string[] {
                        "30000000-0000-0000-0000-000000000000",
                        "10000000-0000-0000-0000-000000000000",
                        "LostDueToInvalidMove"});
            table11.AddRow(new string[] {
                        "40000000-0000-0000-0000-000000000000",
                        "10000000-0000-0000-0000-000000000000",
                        "Moved"});
            table11.AddRow(new string[] {
                        "40000000-0000-0000-0000-000000000000",
                        "10000000-0000-0000-0000-000000000000",
                        "Won"});
            table11.AddRow(new string[] {
                        "50000000-0000-0000-0000-000000000000",
                        "10000000-0000-0000-0000-000000000000",
                        "Moved"});
            table11.AddRow(new string[] {
                        "50000000-0000-0000-0000-000000000000",
                        "10000000-0000-0000-0000-000000000000",
                        "WonDueToNoMoves"});
            table11.AddRow(new string[] {
                        "60000000-0000-0000-0000-000000000000",
                        "10000000-0000-0000-0000-000000000000",
                        "Moved"});
            table11.AddRow(new string[] {
                        "60000000-0000-0000-0000-000000000000",
                        "10000000-0000-0000-0000-000000000000",
                        "WonDueToInvalidMove"});
            table11.AddRow(new string[] {
                        "70000000-0000-0000-0000-000000000000",
                        "10000000-0000-0000-0000-000000000000",
                        "Moved"});
            table11.AddRow(new string[] {
                        "70000000-0000-0000-0000-000000000000",
                        "10000000-0000-0000-0000-000000000000",
                        "Tied"});
            table11.AddRow(new string[] {
                        "80000000-0000-0000-0000-000000000000",
                        "10000000-0000-0000-0000-000000000000",
                        "Moved"});
            table11.AddRow(new string[] {
                        "80000000-0000-0000-0000-000000000000",
                        "10000000-0000-0000-0000-000000000000",
                        "Tied"});
            table11.AddRow(new string[] {
                        "10000000-0000-0000-0000-000000000002",
                        "20000000-0000-0000-0000-000000000000",
                        "Moved"});
            table11.AddRow(new string[] {
                        "10000000-0000-0000-0000-000000000002",
                        "20000000-0000-0000-0000-000000000000",
                        "Lost"});
            table11.AddRow(new string[] {
                        "20000000-0000-0000-0000-000000000002",
                        "20000000-0000-0000-0000-000000000000",
                        "Moved"});
            table11.AddRow(new string[] {
                        "20000000-0000-0000-0000-000000000002",
                        "20000000-0000-0000-0000-000000000000",
                        "LostDueToNoMoves"});
            table11.AddRow(new string[] {
                        "30000000-0000-0000-0000-000000000002",
                        "20000000-0000-0000-0000-000000000000",
                        "Moved"});
            table11.AddRow(new string[] {
                        "30000000-0000-0000-0000-000000000002",
                        "20000000-0000-0000-0000-000000000000",
                        "LostDueToInvalidMove"});
            table11.AddRow(new string[] {
                        "40000000-0000-0000-0000-000000000002",
                        "20000000-0000-0000-0000-000000000000",
                        "Moved"});
            table11.AddRow(new string[] {
                        "40000000-0000-0000-0000-000000000002",
                        "20000000-0000-0000-0000-000000000000",
                        "Won"});
            table11.AddRow(new string[] {
                        "50000000-0000-0000-0000-000000000002",
                        "20000000-0000-0000-0000-000000000000",
                        "Moved"});
            table11.AddRow(new string[] {
                        "50000000-0000-0000-0000-000000000002",
                        "20000000-0000-0000-0000-000000000000",
                        "WonDueToNoMoves"});
            table11.AddRow(new string[] {
                        "60000000-0000-0000-0000-000000000002",
                        "20000000-0000-0000-0000-000000000000",
                        "Moved"});
            table11.AddRow(new string[] {
                        "60000000-0000-0000-0000-000000000002",
                        "20000000-0000-0000-0000-000000000000",
                        "WonDueToInvalidMove"});
            table11.AddRow(new string[] {
                        "70000000-0000-0000-0000-000000000002",
                        "20000000-0000-0000-0000-000000000000",
                        "Moved"});
            table11.AddRow(new string[] {
                        "70000000-0000-0000-0000-000000000002",
                        "20000000-0000-0000-0000-000000000000",
                        "Tied"});
            table11.AddRow(new string[] {
                        "80000000-0000-0000-0000-000000000002",
                        "20000000-0000-0000-0000-000000000000",
                        "Moved"});
            table11.AddRow(new string[] {
                        "80000000-0000-0000-0000-000000000002",
                        "20000000-0000-0000-0000-000000000000",
                        "Tied"});
            table11.AddRow(new string[] {
                        "90000000-0000-0000-0000-000000000002",
                        "20000000-0000-0000-0000-000000000000",
                        "Moved"});
            table11.AddRow(new string[] {
                        "90000000-0000-0000-0000-000000000002",
                        "20000000-0000-0000-0000-000000000000",
                        "Tied"});
            table11.AddRow(new string[] {
                        "99000000-0000-0000-0000-000000000002",
                        "20000000-0000-0000-0000-000000000000",
                        "Moved"});
            table11.AddRow(new string[] {
                        "99000000-0000-0000-0000-000000000002",
                        "20000000-0000-0000-0000-000000000000",
                        "Tied"});
#line 97
 testRunner.Given("I setup the match evaluator evaluate method to return the following ledger", ((string)(null)), table11, "Given ");
#line 135
 testRunner.Given("I have a fitness evaluator of type \'AllOrNothing\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "MatchTournaments"});
            table12.AddRow(new string[] {
                        "5"});
#line 136
 testRunner.Given("I have the following evolution settings", ((string)(null)), table12, "Given ");
#line 139
 testRunner.Given("I have a tictactoe factory", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Id"});
            table13.AddRow(new string[] {
                        "John",
                        "10000000-0000-0000-0000-000000000000"});
            table13.AddRow(new string[] {
                        "Sally",
                        "20000000-0000-0000-0000-000000000000"});
            table13.AddRow(new string[] {
                        "Wayne",
                        "30000000-0000-0000-0000-000000000000"});
#line 140
 testRunner.Given("I have the following individuals", ((string)(null)), table13, "Given ");
#line 145
 testRunner.When("I evaluate fitness", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "IndividualId",
                        "Score",
                        "PercentageOfAllScores"});
            table14.AddRow(new string[] {
                        "10000000-0000-0000-0000-000000000000",
                        ".625",
                        "0.471698"});
            table14.AddRow(new string[] {
                        "20000000-0000-0000-0000-000000000000",
                        ".7",
                        "0.528302"});
#line 146
 testRunner.Then("I expect the fitness scores to contain the following", ((string)(null)), table14, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
