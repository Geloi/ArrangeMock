﻿using System;
using ArrangeMock.UnitTest.TestableArtifacts;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace ArrangeMock.UnitTest.APITests
{
    public class ArrangeMethodTests
    {

        [Test]
        public void CanArrangeParameterlessMethod()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
        }
        
        [Test]
        public void CanArrangeMethodWithAnyArgument()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetSalaryForEmployee(WithAnyArgument.OfType<string>()))
                             .IsCalled()
                             .ItReturns(5);

            payrollSystemMock.Object.GetSalaryForEmployee("Foo").ShouldBe(5);
        }

        [Test]
        public void CanArrangeMethodWithSpecificArgument_ShouldPass()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetSalaryForEmployee("Foo"))
                             .IsCalled()
                             .ItReturns(5);

            payrollSystemMock.Object.GetSalaryForEmployee("Foo").ShouldBe(5);
        }

        [Test]
        public void CanArrangeMethodWithSpecificArgument_ShouldFail()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetSalaryForEmployee("Foo"))
                             .IsCalled()
                             .ItReturns(5);

            payrollSystemMock.Object.GetSalaryForEmployee("Bar").ShouldBe(0);
        }

        [Test]
        public void CanArrangeMethodWithTwoAnyArguments()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetSalaryForEmployeeForYear(WithAnyArgument.OfType<string>(),
                                                                                  WithAnyArgument.OfType<int>()))
                             .IsCalled()
                             .ItReturns(6);

            payrollSystemMock.Object.GetSalaryForEmployeeForYear("Foo", 2014).ShouldBe(6);
        }

        [Test]
        public void CanArrangeMethodWithTwoSpecificArguments_ShouldPass()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetSalaryForEmployeeForYear("Foo",
                                                                                  2014))
                             .IsCalled()
                             .ItReturns(6);

            payrollSystemMock.Object.GetSalaryForEmployeeForYear("Foo", 2014).ShouldBe(6);
        }

        [Test]
        public void CanArrangeMethodWithTwoSpecificArguments_ShouldFail_Scenario1()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetSalaryForEmployeeForYear("Foo",
                                                                                  2013))
                             .IsCalled()
                             .ItReturns(6);

            payrollSystemMock.Object.GetSalaryForEmployeeForYear("Foo", 2014).ShouldBe(0);
        }

        [Test]
        public void CanArrangeMethodWithTwoSpecificArguments_ShouldFail_Scenario2()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetSalaryForEmployeeForYear("Bar",
                                                                                  2014))
                             .IsCalled()
                             .ItReturns(6);

            payrollSystemMock.Object.GetSalaryForEmployeeForYear("Foo", 2014).ShouldBe(0);
        }

        [Test]
        public void CanArrangeMethodWithThreeAnyArguments()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetSalaryForEmployeeForPeriod(WithAnyArgument.OfType<string>(),
                                                                                    WithAnyArgument.OfType<DateTime>(),
                                                                                    WithAnyArgument.OfType<DateTime>()))
                             .IsCalled()
                             .ItReturns(6);

            payrollSystemMock.Object
                             .GetSalaryForEmployeeForPeriod("Foo", DateTime.Now.AddYears(-2), DateTime.Now.AddYears(-1))
                             .ShouldBe(6);
        }

    }
}
