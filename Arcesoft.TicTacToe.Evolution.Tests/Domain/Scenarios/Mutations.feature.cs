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
namespace Arcesoft.TicTacToe.Evolution.Tests.Domain.Scenarios
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class MutationsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Mutations.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Mutations", "\tValidate all mutation level features", ProgrammingLanguage.CSharp, new string[] {
                        "Domain"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Mutations")))
            {
                global::Arcesoft.TicTacToe.Evolution.Tests.Domain.Scenarios.MutationsFeature.FeatureSetup(null);
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
 testRunner.Given("I have an evolution factory", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.Given("I have a mutator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Should mutate all genes when mutation rate is 100 percent")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Mutations")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Domain")]
        public virtual void ShouldMutateAllGenesWhenMutationRateIs100Percent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Should mutate all genes when mutation rate is 100 percent", ((string[])(null)));
#line 10
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "MutationRate"});
            table1.AddRow(new string[] {
                        "1.0"});
#line 11
 testRunner.Given("I have the following population settings", ((string)(null)), table1, "Given ");
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
            table2.AddRow(new string[] {
                        "Ninth",
                        "0",
                        "DXO___RAA"});
#line 14
 testRunner.Given("I have an individual with the following genes", ((string)(null)), table2, "Given ");
#line 19
 testRunner.When("I mutate my given individual", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
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
#line 20
 testRunner.Then("I expect the individual to not contain any of the following genes", ((string)(null)), table3, "Then ");
#line 25
 testRunner.Then("I expect the individual to contain \'3\' genes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Should not mutate any genes when mutation rate is 0 percent")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Mutations")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Domain")]
        public virtual void ShouldNotMutateAnyGenesWhenMutationRateIs0Percent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Should not mutate any genes when mutation rate is 0 percent", ((string[])(null)));
#line 27
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "MutationRate"});
            table4.AddRow(new string[] {
                        "0.0"});
#line 28
 testRunner.Given("I have the following population settings", ((string)(null)), table4, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Turn",
                        "Priority",
                        "Alleles"});
            table5.AddRow(new string[] {
                        "First",
                        "0",
                        "DDD_X_ORA"});
            table5.AddRow(new string[] {
                        "Second",
                        "0",
                        "RDX_X_ODA"});
            table5.AddRow(new string[] {
                        "Third",
                        "0",
                        "DXO___RAA"});
            table5.AddRow(new string[] {
                        "Fourth",
                        "0",
                        "DDDDDDDDD"});
            table5.AddRow(new string[] {
                        "Fifth",
                        "0",
                        "DDDDDDDDD"});
            table5.AddRow(new string[] {
                        "Sixth",
                        "0",
                        "DDDDDDDDD"});
            table5.AddRow(new string[] {
                        "Seventh",
                        "0",
                        "DDDDDDDDD"});
            table5.AddRow(new string[] {
                        "Eigth",
                        "0",
                        "DDDDDDDDD"});
            table5.AddRow(new string[] {
                        "Ninth",
                        "0",
                        "DDDDDDDDD"});
            table5.AddRow(new string[] {
                        "First",
                        "1",
                        "DDD_X_ORA"});
            table5.AddRow(new string[] {
                        "Second",
                        "1",
                        "RDX_X_ODA"});
            table5.AddRow(new string[] {
                        "Third",
                        "1",
                        "DXO___RAA"});
            table5.AddRow(new string[] {
                        "Fourth",
                        "1",
                        "DDDDDDDDD"});
            table5.AddRow(new string[] {
                        "Fifth",
                        "1",
                        "DDDDDDDDD"});
            table5.AddRow(new string[] {
                        "Sixth",
                        "1",
                        "DDDDDDDDD"});
            table5.AddRow(new string[] {
                        "Seventh",
                        "1",
                        "DDDDDDDDD"});
            table5.AddRow(new string[] {
                        "Eigth",
                        "1",
                        "DDDDDDDDD"});
            table5.AddRow(new string[] {
                        "Ninth",
                        "1",
                        "DDDDDDDDD"});
            table5.AddRow(new string[] {
                        "First",
                        "2",
                        "DDD_X_ORA"});
            table5.AddRow(new string[] {
                        "Second",
                        "2",
                        "RDX_X_ODA"});
            table5.AddRow(new string[] {
                        "Third",
                        "2",
                        "DXO___RAA"});
            table5.AddRow(new string[] {
                        "Fourth",
                        "2",
                        "DDDDDDDDD"});
            table5.AddRow(new string[] {
                        "Fifth",
                        "2",
                        "DDDDDDDDD"});
            table5.AddRow(new string[] {
                        "Sixth",
                        "2",
                        "DDDDDDDDD"});
            table5.AddRow(new string[] {
                        "Seventh",
                        "2",
                        "DDDDDDDDD"});
            table5.AddRow(new string[] {
                        "Eigth",
                        "2",
                        "DDDDDDDDD"});
            table5.AddRow(new string[] {
                        "Ninth",
                        "2",
                        "DDDDDDDDD"});
#line 31
 testRunner.Given("I have an individual with the following genes", ((string)(null)), table5, "Given ");
#line 60
 testRunner.When("I mutate my given individual", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Turn",
                        "Priority",
                        "Alleles"});
            table6.AddRow(new string[] {
                        "First",
                        "0",
                        "DDD_X_ORA"});
            table6.AddRow(new string[] {
                        "Second",
                        "0",
                        "RDX_X_ODA"});
            table6.AddRow(new string[] {
                        "Third",
                        "0",
                        "DXO___RAA"});
            table6.AddRow(new string[] {
                        "Fourth",
                        "0",
                        "DDDDDDDDD"});
            table6.AddRow(new string[] {
                        "Fifth",
                        "0",
                        "DDDDDDDDD"});
            table6.AddRow(new string[] {
                        "Sixth",
                        "0",
                        "DDDDDDDDD"});
            table6.AddRow(new string[] {
                        "Seventh",
                        "0",
                        "DDDDDDDDD"});
            table6.AddRow(new string[] {
                        "Eigth",
                        "0",
                        "DDDDDDDDD"});
            table6.AddRow(new string[] {
                        "Ninth",
                        "0",
                        "DDDDDDDDD"});
            table6.AddRow(new string[] {
                        "First",
                        "1",
                        "DDD_X_ORA"});
            table6.AddRow(new string[] {
                        "Second",
                        "1",
                        "RDX_X_ODA"});
            table6.AddRow(new string[] {
                        "Third",
                        "1",
                        "DXO___RAA"});
            table6.AddRow(new string[] {
                        "Fourth",
                        "1",
                        "DDDDDDDDD"});
            table6.AddRow(new string[] {
                        "Fifth",
                        "1",
                        "DDDDDDDDD"});
            table6.AddRow(new string[] {
                        "Sixth",
                        "1",
                        "DDDDDDDDD"});
            table6.AddRow(new string[] {
                        "Seventh",
                        "1",
                        "DDDDDDDDD"});
            table6.AddRow(new string[] {
                        "Eigth",
                        "1",
                        "DDDDDDDDD"});
            table6.AddRow(new string[] {
                        "Ninth",
                        "1",
                        "DDDDDDDDD"});
            table6.AddRow(new string[] {
                        "First",
                        "2",
                        "DDD_X_ORA"});
            table6.AddRow(new string[] {
                        "Second",
                        "2",
                        "RDX_X_ODA"});
            table6.AddRow(new string[] {
                        "Third",
                        "2",
                        "DXO___RAA"});
            table6.AddRow(new string[] {
                        "Fourth",
                        "2",
                        "DDDDDDDDD"});
            table6.AddRow(new string[] {
                        "Fifth",
                        "2",
                        "DDDDDDDDD"});
            table6.AddRow(new string[] {
                        "Sixth",
                        "2",
                        "DDDDDDDDD"});
            table6.AddRow(new string[] {
                        "Seventh",
                        "2",
                        "DDDDDDDDD"});
            table6.AddRow(new string[] {
                        "Eigth",
                        "2",
                        "DDDDDDDDD"});
            table6.AddRow(new string[] {
                        "Ninth",
                        "2",
                        "DDDDDDDDD"});
#line 61
 testRunner.Then("I expect the individual to contain the following genes", ((string)(null)), table6, "Then ");
#line 90
 testRunner.Then("I expect the individual to contain \'27\' genes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
