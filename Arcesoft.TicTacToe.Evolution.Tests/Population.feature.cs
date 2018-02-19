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
    public partial class PopulationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Population.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Population", "Verify that the population is working as expected", ProgrammingLanguage.CSharp, new string[] {
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Population")))
            {
                global::Arcesoft.TicTacToe.Evolution.Tests.PopulationFeature.FeatureSetup(null);
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
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Population should promote fittest in one cycle")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Population")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        public virtual void PopulationShouldPromoteFittestInOneCycle()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Population should promote fittest in one cycle", ((string[])(null)));
#line 8
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line 9
 testRunner.Given("I have an evolution factory", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "MutationRate",
                        "MaximumPopulationSize",
                        "IndividualChildBearingLimit",
                        "MaximumGenesPerIndividual",
                        "BreederType",
                        "FitnessEvaluatorType",
                        "MatchTournaments"});
            table1.AddRow(new string[] {
                        "0",
                        "10",
                        "5",
                        "2",
                        "ASexual",
                        "AllOrNothing",
                        "5"});
#line 10
 testRunner.Given("I have the following evolution settings", ((string)(null)), table1, "Given ");
#line 13
 testRunner.Given("I have a population", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Turn",
                        "Priority",
                        "Alleles"});
            table2.AddRow(new string[] {
                        "First",
                        "0",
                        "____R____"});
            table2.AddRow(new string[] {
                        "Third",
                        "0",
                        "DDDDDDDDR"});
#line 14
 testRunner.Given("I have an individual called \'SuperSayan\' with id \'10000000-0000-0000-0000-0000000" +
                    "00000\' and with the following genes", ((string)(null)), table2, "Given ");
#line 18
 testRunner.Given("I add my individual to the population", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
 testRunner.When("I evolve the population \'1\' times", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Turn",
                        "Priority",
                        "Alleles"});
            table3.AddRow(new string[] {
                        "First",
                        "0",
                        "____R____"});
            table3.AddRow(new string[] {
                        "Third",
                        "0",
                        "DDDDDDDDR"});
#line 20
 testRunner.Then("I expect the population to contain \'2\' individuals with parent ids \'10000000-0000" +
                    "-0000-0000-000000000000\' and the following genes", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Population should promote fittest for many cycles")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Population")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Behavioral")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        public virtual void PopulationShouldPromoteFittestForManyCycles()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Population should promote fittest for many cycles", new string[] {
                        "ignore"});
#line 26
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line 27
 testRunner.Given("I have an evolution factory", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "MutationRate",
                        "MaximumPopulationSize",
                        "IndividualChildBearingLimit",
                        "MaximumGenesPerIndividual",
                        "BreederType",
                        "FitnessEvaluatorType",
                        "MatchTournaments"});
            table4.AddRow(new string[] {
                        "0",
                        "10",
                        "5",
                        "2",
                        "ASexual",
                        "AllOrNothing",
                        "5"});
#line 28
 testRunner.Given("I have the following evolution settings", ((string)(null)), table4, "Given ");
#line 31
 testRunner.Given("I have a population", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Turn",
                        "Priority",
                        "Alleles"});
            table5.AddRow(new string[] {
                        "First",
                        "0",
                        "____R____"});
            table5.AddRow(new string[] {
                        "Third",
                        "0",
                        "DDDDDDDDR"});
#line 32
 testRunner.Given("I have an individual called \'SuperSayan\' with id \'10000000-0000-0000-0000-0000000" +
                    "00000\' and with the following genes", ((string)(null)), table5, "Given ");
#line 36
 testRunner.Given("I add my individual to the population", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
 testRunner.When("I evolve the population \'1000\' times", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Turn",
                        "Priority",
                        "Alleles"});
            table6.AddRow(new string[] {
                        "First",
                        "0",
                        "____R____"});
            table6.AddRow(new string[] {
                        "Third",
                        "0",
                        "DDDDDDDDR"});
#line 38
 testRunner.Then("I expect the entire population to contain the following genes", ((string)(null)), table6, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
