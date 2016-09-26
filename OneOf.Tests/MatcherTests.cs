﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace OneOf.Tests
{
    public class MatcherTests
    {
        [Test]
        public void MatchCallsBoolFuncWhenBool()
        {
            var oneOf = (OneOf<string, bool>)true;

            var success = oneOf.Matcher<bool>()
                .When<string>(str => false)
                .When<bool>(bln => bln == true)
                .Result;

            Assert.AreEqual(true, success);
        }

        [Test]
        public void MatchCallsStringFuncWhenString()
        {
            var oneOf = (OneOf<string, bool>)"xyz";

            var success = oneOf.Matcher<bool>()
                .When<string>(str => str == "xyz")
                .When<bool>(bln => false)
                .Result;

            Assert.AreEqual(true, success);
        }

        [Test]
        public void MatchCallsOtherFuncWhenNoMatch()
        {
            var oneOf = (OneOf<string, bool>)"xyz";

            var success = oneOf.Matcher<bool>()
                .Otherwise(obj => obj.ToString() == "xyz")
                .Result;

            Assert.AreEqual(true, success);
        }
    }

}
