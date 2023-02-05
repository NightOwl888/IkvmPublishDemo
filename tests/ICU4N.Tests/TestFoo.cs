using java.lang;
using java.text;
using NUnit.Framework;
using System;
using System.Globalization;

namespace ICU4N.Tests
{
    public class TestFoo
    {
        [Test]
        public void TestGetMessage()
        {
            var target = new Foo();

            Assert.AreEqual("Hello", target.GetMessage());
        }

        // This test throws AccessViolationException - some IKVM issue

        // Test that the decimal is shown even when there are no fractional digits
        [Test]
        public void Test11621()// throws Exception
        {
            string pat = "0.##E0";

            com.ibm.icu.text.DecimalFormatSymbols icuSym = new com.ibm.icu.text.DecimalFormatSymbols(java.util.Locale.US);
            com.ibm.icu.text.DecimalFormat icuFmt = new com.ibm.icu.text.DecimalFormat(pat, icuSym);
            icuFmt.setDecimalSeparatorAlwaysShown(true);
            string icu = ((com.ibm.icu.text.NumberFormat)icuFmt).format(299792458);

            java.text.DecimalFormatSymbols jdkSym = new java.text.DecimalFormatSymbols(java.util.Locale.US);
            java.text.DecimalFormat jdkFmt = new java.text.DecimalFormat(pat, jdkSym);
            jdkFmt.setDecimalSeparatorAlwaysShown(true);
            string jdk = ((java.text.NumberFormat)jdkFmt).format(299792458);

            Assert.AreEqual(jdk, icu, "ICU and JDK placement of decimal in exponent");
        }


        //[Test]
        //public void TestCoverage()
        //{
        //    java.util.Currency usd = java.util.Currency.getInstance("USD");
        //    Assert.AreEqual(
        //            "$",
        //            usd.getSymbol(),
        //            "USD.getSymbol()");
        //}
    }
}
