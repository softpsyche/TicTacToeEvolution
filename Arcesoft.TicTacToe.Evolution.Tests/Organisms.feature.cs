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
    public partial class OrganismsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Organisms.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Organisms", "\tVerify that tic tac toe individuals are working correctly", ProgrammingLanguage.CSharp, new string[] {
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Organisms")))
            {
                global::Arcesoft.TicTacToe.Evolution.Tests.OrganismsFeature.FeatureSetup(null);
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
#line 5
#line 6
 testRunner.Given("I have a container", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.Given("I have a tictactoe factory", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.Given("I have an evolution factory", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Individual should get genes correctly")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Organisms")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        public virtual void IndividualShouldGetGenesCorrectly()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Individual should get genes correctly", ((string[])(null)));
#line 10
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line 11
 testRunner.Given("I have an individual", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Turn",
                        "Priority",
                        "Alleles"});
            table1.AddRow(new string[] {
                        "First",
                        "34",
                        "DDD_X_ORA"});
            table1.AddRow(new string[] {
                        "Third",
                        "99",
                        "RDX_X_ODA"});
#line 12
 testRunner.When("I set the following genes on the individual", ((string)(null)), table1, "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Turn",
                        "Priority",
                        "Alleles"});
            table2.AddRow(new string[] {
                        "First",
                        "34",
                        "DDD_X_ORA"});
            table2.AddRow(new string[] {
                        "Third",
                        "99",
                        "RDX_X_ODA"});
#line 16
 testRunner.Then("The individual should contain the following genes", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Individual should copy correctly")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Organisms")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        public virtual void IndividualShouldCopyCorrectly()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Individual should copy correctly", ((string[])(null)));
#line 21
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Turn",
                        "Priority",
                        "Alleles"});
            table3.AddRow(new string[] {
                        "First",
                        "34",
                        "DDD_X_ORA"});
            table3.AddRow(new string[] {
                        "Third",
                        "99",
                        "RDX_X_ODA"});
            table3.AddRow(new string[] {
                        "Ninth",
                        "0",
                        "DXO___RAA"});
#line 22
 testRunner.Given("I have an individual with the following genes", ((string)(null)), table3, "Given ");
#line 27
 testRunner.When("I make \'2\' copies of the individual", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Turn",
                        "Priority",
                        "Alleles"});
            table4.AddRow(new string[] {
                        "First",
                        "34",
                        "DDD_X_ORA"});
            table4.AddRow(new string[] {
                        "Third",
                        "99",
                        "RDX_X_ODA"});
            table4.AddRow(new string[] {
                        "Ninth",
                        "0",
                        "DXO___RAA"});
#line 28
 testRunner.Then("All individual copies should contain the following genes", ((string)(null)), table4, "Then ");
#line 33
 testRunner.Then("There should be exactly \'2\' individual copies", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Individual should find move")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Organisms")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        public virtual void IndividualShouldFindMove()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Individual should find move", ((string[])(null)));
#line 35
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        "",
                        ""});
            table5.AddRow(new string[] {
                        "X",
                        "",
                        "O"});
            table5.AddRow(new string[] {
                        "O",
                        "X",
                        ""});
            table5.AddRow(new string[] {
                        "X",
                        "",
                        "O"});
#line 36
 testRunner.Given("I have a new game in the following state", ((string)(null)), table5, "Given ");
#line 41
 testRunner.Given("I have an individual", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        "",
                        ""});
            table6.AddRow(new string[] {
                        "X",
                        "",
                        "O"});
            table6.AddRow(new string[] {
                        "O",
                        "X",
                        "R"});
            table6.AddRow(new string[] {
                        "X",
                        "",
                        "O"});
#line 42
 testRunner.Given("I add a gene to my individual for turn \'Sixth\' with priority \'1\' and the followin" +
                    "g alleles", ((string)(null)), table6, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        "",
                        ""});
            table7.AddRow(new string[] {
                        "D",
                        "",
                        "D"});
            table7.AddRow(new string[] {
                        "D",
                        "R",
                        "D"});
            table7.AddRow(new string[] {
                        "D",
                        "",
                        "O"});
#line 47
 testRunner.Given("I add a gene to my individual for turn \'Seventh\' with priority \'2\' and the follow" +
                    "ing alleles", ((string)(null)), table7, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        "",
                        ""});
            table8.AddRow(new string[] {
                        "D",
                        "",
                        "D"});
            table8.AddRow(new string[] {
                        "D",
                        "X",
                        "D"});
            table8.AddRow(new string[] {
                        "D",
                        "R",
                        "O"});
#line 52
 testRunner.Given("I add a gene to my individual for turn \'Seventh\' with priority \'18\' and the follo" +
                    "wing alleles", ((string)(null)), table8, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        "",
                        ""});
            table9.AddRow(new string[] {
                        "D",
                        "R",
                        "D"});
            table9.AddRow(new string[] {
                        "D",
                        "X",
                        "D"});
            table9.AddRow(new string[] {
                        "D",
                        "",
                        "O"});
#line 57
 testRunner.Given("I add a gene to my individual for turn \'Seventh\' with priority \'7\' and the follow" +
                    "ing alleles", ((string)(null)), table9, "Given ");
#line 62
 testRunner.When("I try to find a move for the current game with my individual", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
 testRunner.Then("I expect the move to be \'Northern\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Individual should not find move")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Organisms")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        public virtual void IndividualShouldNotFindMove()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Individual should not find move", ((string[])(null)));
#line 65
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        "",
                        ""});
            table10.AddRow(new string[] {
                        "",
                        "",
                        ""});
            table10.AddRow(new string[] {
                        "",
                        "",
                        ""});
            table10.AddRow(new string[] {
                        "",
                        "",
                        ""});
#line 66
 testRunner.Given("I have a new game in the following state", ((string)(null)), table10, "Given ");
#line 71
 testRunner.Given("I have an individual", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        "",
                        ""});
            table11.AddRow(new string[] {
                        "",
                        "",
                        ""});
            table11.AddRow(new string[] {
                        "",
                        "",
                        ""});
            table11.AddRow(new string[] {
                        "",
                        "",
                        ""});
#line 72
  testRunner.Given("I add a gene to my individual for turn \'First\' with priority \'1\' and the followin" +
                    "g alleles", ((string)(null)), table11, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        "",
                        ""});
            table12.AddRow(new string[] {
                        "",
                        "",
                        ""});
            table12.AddRow(new string[] {
                        "",
                        "",
                        ""});
            table12.AddRow(new string[] {
                        "",
                        "X",
                        ""});
#line 77
 testRunner.Given("I add a gene to my individual for turn \'First\' with priority \'1\' and the followin" +
                    "g alleles", ((string)(null)), table12, "Given ");
#line 82
 testRunner.When("I try to find a move for the current game with my individual", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 83
 testRunner.Then("I expect the move to be null", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Individual should find responses correctly")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Organisms")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        public virtual void IndividualShouldFindResponsesCorrectly()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Individual should find responses correctly", ((string[])(null)));
#line 85
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        "",
                        ""});
            table13.AddRow(new string[] {
                        "",
                        "",
                        "O"});
            table13.AddRow(new string[] {
                        "",
                        "X",
                        ""});
            table13.AddRow(new string[] {
                        "",
                        "",
                        ""});
#line 86
 testRunner.Given("I have a new game in the following state", ((string)(null)), table13, "Given ");
#line 91
 testRunner.Given("I have an individual", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        "",
                        ""});
            table14.AddRow(new string[] {
                        "",
                        "",
                        "O"});
            table14.AddRow(new string[] {
                        "D",
                        "D",
                        ""});
            table14.AddRow(new string[] {
                        "",
                        "R",
                        ""});
#line 92
 testRunner.Given("I add a gene to my individual for turn \'Third\' with priority \'3\' and the followin" +
                    "g alleles", ((string)(null)), table14, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        "",
                        ""});
            table15.AddRow(new string[] {
                        "D",
                        "R",
                        "O"});
            table15.AddRow(new string[] {
                        "D",
                        "X",
                        ""});
            table15.AddRow(new string[] {
                        "D",
                        "",
                        ""});
#line 97
 testRunner.Given("I add a gene to my individual for turn \'Third\' with priority \'5\' and the followin" +
                    "g alleles", ((string)(null)), table15, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        "",
                        ""});
            table16.AddRow(new string[] {
                        "",
                        "",
                        "O"});
            table16.AddRow(new string[] {
                        "R",
                        "X",
                        ""});
            table16.AddRow(new string[] {
                        "",
                        "",
                        ""});
#line 102
 testRunner.Given("I add a gene to my individual for turn \'Third\' with priority \'1\' and the followin" +
                    "g alleles", ((string)(null)), table16, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        "",
                        ""});
            table17.AddRow(new string[] {
                        "",
                        "R",
                        "O"});
            table17.AddRow(new string[] {
                        "",
                        "X",
                        ""});
            table17.AddRow(new string[] {
                        "",
                        "",
                        ""});
#line 107
 testRunner.Given("I add a gene to my individual for turn \'First\' with priority \'7\' and the followin" +
                    "g alleles", ((string)(null)), table17, "Given ");
#line 112
 testRunner.When("I find responses for the current game with my individual", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "Move"});
            table18.AddRow(new string[] {
                        "Western"});
            table18.AddRow(new string[] {
                        "Southern"});
            table18.AddRow(new string[] {
                        "Northern"});
#line 113
 testRunner.Then("I expect the responses to contain in the following order", ((string)(null)), table18, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
