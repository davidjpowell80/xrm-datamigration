﻿using Capgemini.DataMigration.Core.Model;
using Capgemini.DataMigration.Core.Tests.Base;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.DataMigration.Core.Tests.Unit.Model
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class FieldToBeObfuscatedTests : UnitTestBase
    {
        [TestInitialize]
        public void Setup()
        {
            InitializeProperties();
        }

        [TestMethod]
        public void CanBeFormattedReturnsFalseIfFormattingArgsAreMissing()
        {
            FieldToBeObfuscated testObject = new FieldToBeObfuscated() { FieldName = "test" };

            testObject.CanBeFormatted.Should().BeFalse();
        }

        [TestMethod]
        public void CanBeFormattedReturnsTrueIfFormattingArgsAreAvailable()
        {
            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("length", "10");
            List<ObfuscationFormatOption> formatOptions = new List<ObfuscationFormatOption>();
            formatOptions.Add(new ObfuscationFormatOption(ObfuscationFormatType.RandomString, args));
            FieldToBeObfuscated testObject = new FieldToBeObfuscated() 
            {
                FieldName = "test",
                ObfuscationFormat = "{0}",
                ObfuscationFormatArgs = formatOptions
            };

            testObject.CanBeFormatted.Should().BeTrue();
        }
    }
}
