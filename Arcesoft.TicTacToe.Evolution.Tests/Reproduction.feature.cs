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
    public partial class ReproductionFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Reproduction.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Reproduction", "\tValidate all reproduction type functions", ProgrammingLanguage.CSharp, new string[] {
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Reproduction")))
            {
                global::Arcesoft.TicTacToe.Evolution.Tests.ReproductionFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ASexual breeder should breed individuals")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Reproduction")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        public virtual void ASexualBreederShouldBreedIndividuals()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ASexual breeder should breed individuals", ((string[])(null)));
#line 10
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "MutationRate",
                        "MaximumPopulationSize",
                        "IndividualChildBearingLimit"});
            table1.AddRow(new string[] {
                        "1.0",
                        "10",
                        "5"});
#line 11
 testRunner.Given("I have the following evolution settings", ((string)(null)), table1, "Given ");
#line 14
 testRunner.Given("I have an asexual breeder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Id"});
            table2.AddRow(new string[] {
                        "Alpha",
                        "10000000-0000-0000-0000-000000000000"});
            table2.AddRow(new string[] {
                        "Beta",
                        "20000000-0000-0000-0000-000000000000"});
            table2.AddRow(new string[] {
                        "Gamma",
                        "30000000-0000-0000-0000-000000000000"});
            table2.AddRow(new string[] {
                        "Delta",
                        "40000000-0000-0000-0000-000000000000"});
#line 15
 testRunner.Given("I have the following individuals", ((string)(null)), table2, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "IndividualId",
                        "Turn",
                        "Priority",
                        "Alleles"});
            table3.AddRow(new string[] {
                        "10000000-0000-0000-0000-000000000000",
                        "First",
                        "10",
                        "DDD_X_ORA"});
            table3.AddRow(new string[] {
                        "10000000-0000-0000-0000-000000000000",
                        "Second",
                        "20",
                        "RDX_X_ODA"});
            table3.AddRow(new string[] {
                        "20000000-0000-0000-0000-000000000000",
                        "Third",
                        "50",
                        "DXO___RAA"});
            table3.AddRow(new string[] {
                        "30000000-0000-0000-0000-000000000000",
                        "Fourth",
                        "25",
                        "DDD_O_DDD"});
            table3.AddRow(new string[] {
                        "40000000-0000-0000-0000-000000000000",
                        "Fifth",
                        "5",
                        "DDDDDDDDD"});
#line 21
 testRunner.Given("I have the following genes on my individuals", ((string)(null)), table3, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "IndividualId",
                        "Score",
                        "PercentageOfAllScores"});
            table4.AddRow(new string[] {
                        "10000000-0000-0000-0000-000000000000",
                        ".30",
                        "0.30"});
            table4.AddRow(new string[] {
                        "20000000-0000-0000-0000-000000000000",
                        ".50",
                        "0.50"});
            table4.AddRow(new string[] {
                        "30000000-0000-0000-0000-000000000000",
                        ".20",
                        "0.20"});
            table4.AddRow(new string[] {
                        "40000000-0000-0000-0000-000000000000",
                        ".0",
                        "0"});
#line 28
 testRunner.Given("I have the following fitness scores for my individuals", ((string)(null)), table4, "Given ");
#line 34
 testRunner.When("I breed my individuals", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "ParentIds"});
            table5.AddRow(new string[] {
                        "10000000-0000-0000-0000-000000000000"});
            table5.AddRow(new string[] {
                        "10000000-0000-0000-0000-000000000000"});
            table5.AddRow(new string[] {
                        "10000000-0000-0000-0000-000000000000"});
            table5.AddRow(new string[] {
                        "20000000-0000-0000-0000-000000000000"});
            table5.AddRow(new string[] {
                        "20000000-0000-0000-0000-000000000000"});
            table5.AddRow(new string[] {
                        "20000000-0000-0000-0000-000000000000"});
            table5.AddRow(new string[] {
                        "20000000-0000-0000-0000-000000000000"});
            table5.AddRow(new string[] {
                        "20000000-0000-0000-0000-000000000000"});
            table5.AddRow(new string[] {
                        "30000000-0000-0000-0000-000000000000"});
            table5.AddRow(new string[] {
                        "30000000-0000-0000-0000-000000000000"});
#line 35
 testRunner.Then("I expect the new generation of individuals to contain", ((string)(null)), table5, "Then ");
#line 47
 testRunner.Then("I expect the size of the new generation to be exactly \'10\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Turn",
                        "Priority",
                        "Alleles"});
            table6.AddRow(new string[] {
                        "First",
                        "10",
                        "DDD_X_ORA"});
            table6.AddRow(new string[] {
                        "Second",
                        "20",
                        "RDX_X_ODA"});
#line 48
 testRunner.Then("I expect \'3\' individuals with parents \'10000000-0000-0000-0000-000000000000\' to c" +
                    "ontain the following genes", ((string)(null)), table6, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Turn",
                        "Priority",
                        "Alleles"});
            table7.AddRow(new string[] {
                        "Third",
                        "50",
                        "DXO___RAA"});
#line 52
 testRunner.Then("I expect \'5\' individuals with parents \'20000000-0000-0000-0000-000000000000\' to c" +
                    "ontain the following genes", ((string)(null)), table7, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Turn",
                        "Priority",
                        "Alleles"});
            table8.AddRow(new string[] {
                        "Fourth",
                        "25",
                        "DDD_O_DDD"});
#line 55
 testRunner.Then("I expect \'2\' individuals with parents \'30000000-0000-0000-0000-000000000000\' to c" +
                    "ontain the following genes", ((string)(null)), table8, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ASexual breeder should downsize population accordingly")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Reproduction")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        public virtual void ASexualBreederShouldDownsizePopulationAccordingly()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ASexual breeder should downsize population accordingly", ((string[])(null)));
#line 59
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "MutationRate",
                        "MaximumPopulationSize",
                        "IndividualChildBearingLimit"});
            table9.AddRow(new string[] {
                        "1.0",
                        "3",
                        "5"});
#line 60
 testRunner.Given("I have the following evolution settings", ((string)(null)), table9, "Given ");
#line 63
 testRunner.Given("I have an asexual breeder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Id"});
            table10.AddRow(new string[] {
                        "Alpha",
                        "10000000-0000-0000-0000-000000000000"});
            table10.AddRow(new string[] {
                        "Beta",
                        "20000000-0000-0000-0000-000000000000"});
            table10.AddRow(new string[] {
                        "Gamma",
                        "30000000-0000-0000-0000-000000000000"});
            table10.AddRow(new string[] {
                        "Delta",
                        "40000000-0000-0000-0000-000000000000"});
#line 64
 testRunner.Given("I have the following individuals", ((string)(null)), table10, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "IndividualId",
                        "Turn",
                        "Priority",
                        "Alleles"});
            table11.AddRow(new string[] {
                        "10000000-0000-0000-0000-000000000000",
                        "First",
                        "10",
                        "DDD_X_ORA"});
            table11.AddRow(new string[] {
                        "10000000-0000-0000-0000-000000000000",
                        "Second",
                        "20",
                        "RDX_X_ODA"});
            table11.AddRow(new string[] {
                        "20000000-0000-0000-0000-000000000000",
                        "Third",
                        "50",
                        "DXO___RAA"});
            table11.AddRow(new string[] {
                        "30000000-0000-0000-0000-000000000000",
                        "Fourth",
                        "25",
                        "DDD_O_DDD"});
            table11.AddRow(new string[] {
                        "40000000-0000-0000-0000-000000000000",
                        "Fifth",
                        "5",
                        "DDDDDDDDD"});
#line 70
 testRunner.Given("I have the following genes on my individuals", ((string)(null)), table11, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "IndividualId",
                        "Score",
                        "PercentageOfAllScores"});
            table12.AddRow(new string[] {
                        "10000000-0000-0000-0000-000000000000",
                        ".30",
                        "0.30"});
            table12.AddRow(new string[] {
                        "20000000-0000-0000-0000-000000000000",
                        ".50",
                        "0.50"});
            table12.AddRow(new string[] {
                        "30000000-0000-0000-0000-000000000000",
                        ".20",
                        "0.20"});
            table12.AddRow(new string[] {
                        "40000000-0000-0000-0000-000000000000",
                        ".0",
                        "0"});
#line 77
 testRunner.Given("I have the following fitness scores for my individuals", ((string)(null)), table12, "Given ");
#line 83
 testRunner.When("I breed my individuals", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "ParentIds"});
            table13.AddRow(new string[] {
                        "10000000-0000-0000-0000-000000000000"});
            table13.AddRow(new string[] {
                        "20000000-0000-0000-0000-000000000000"});
            table13.AddRow(new string[] {
                        "20000000-0000-0000-0000-000000000000"});
#line 84
 testRunner.Then("I expect the new generation of individuals to contain", ((string)(null)), table13, "Then ");
#line 89
 testRunner.Then("I expect the size of the new generation to be exactly \'3\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ASexual breeder should obey child bearing limits")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Reproduction")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        public virtual void ASexualBreederShouldObeyChildBearingLimits()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ASexual breeder should obey child bearing limits", ((string[])(null)));
#line 91
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "MutationRate",
                        "MaximumPopulationSize",
                        "IndividualChildBearingLimit"});
            table14.AddRow(new string[] {
                        "1.0",
                        "10",
                        "3"});
#line 92
 testRunner.Given("I have the following evolution settings", ((string)(null)), table14, "Given ");
#line 95
 testRunner.Given("I have an asexual breeder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Id"});
            table15.AddRow(new string[] {
                        "Alpha",
                        "10000000-0000-0000-0000-000000000000"});
            table15.AddRow(new string[] {
                        "Beta",
                        "20000000-0000-0000-0000-000000000000"});
            table15.AddRow(new string[] {
                        "Gamma",
                        "30000000-0000-0000-0000-000000000000"});
            table15.AddRow(new string[] {
                        "Delta",
                        "40000000-0000-0000-0000-000000000000"});
#line 96
 testRunner.Given("I have the following individuals", ((string)(null)), table15, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "IndividualId",
                        "Turn",
                        "Priority",
                        "Alleles"});
            table16.AddRow(new string[] {
                        "10000000-0000-0000-0000-000000000000",
                        "First",
                        "10",
                        "DDD_X_ORA"});
            table16.AddRow(new string[] {
                        "10000000-0000-0000-0000-000000000000",
                        "Second",
                        "20",
                        "RDX_X_ODA"});
            table16.AddRow(new string[] {
                        "20000000-0000-0000-0000-000000000000",
                        "Third",
                        "50",
                        "DXO___RAA"});
            table16.AddRow(new string[] {
                        "30000000-0000-0000-0000-000000000000",
                        "Fourth",
                        "25",
                        "DDD_O_DDD"});
            table16.AddRow(new string[] {
                        "40000000-0000-0000-0000-000000000000",
                        "Fifth",
                        "5",
                        "DDDDDDDDD"});
#line 102
 testRunner.Given("I have the following genes on my individuals", ((string)(null)), table16, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "IndividualId",
                        "Score",
                        "PercentageOfAllScores"});
            table17.AddRow(new string[] {
                        "10000000-0000-0000-0000-000000000000",
                        ".30",
                        "0.30"});
            table17.AddRow(new string[] {
                        "20000000-0000-0000-0000-000000000000",
                        ".50",
                        "0.50"});
            table17.AddRow(new string[] {
                        "30000000-0000-0000-0000-000000000000",
                        ".20",
                        "0.20"});
            table17.AddRow(new string[] {
                        "40000000-0000-0000-0000-000000000000",
                        ".0",
                        "0"});
#line 109
 testRunner.Given("I have the following fitness scores for my individuals", ((string)(null)), table17, "Given ");
#line 115
 testRunner.When("I breed my individuals", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "ParentIds"});
            table18.AddRow(new string[] {
                        "10000000-0000-0000-0000-000000000000"});
            table18.AddRow(new string[] {
                        "10000000-0000-0000-0000-000000000000"});
            table18.AddRow(new string[] {
                        "10000000-0000-0000-0000-000000000000"});
            table18.AddRow(new string[] {
                        "20000000-0000-0000-0000-000000000000"});
            table18.AddRow(new string[] {
                        "20000000-0000-0000-0000-000000000000"});
            table18.AddRow(new string[] {
                        "20000000-0000-0000-0000-000000000000"});
            table18.AddRow(new string[] {
                        "30000000-0000-0000-0000-000000000000"});
            table18.AddRow(new string[] {
                        "30000000-0000-0000-0000-000000000000"});
            table18.AddRow(new string[] {
                        "40000000-0000-0000-0000-000000000000"});
#line 116
 testRunner.Then("I expect the new generation of individuals to contain", ((string)(null)), table18, "Then ");
#line 127
 testRunner.Then("I expect the size of the new generation to be exactly \'9\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
