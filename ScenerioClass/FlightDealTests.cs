using NUnit.Framework;
using WebAdapterClass;
using InterfaceClass;
using Utilities; // ✅ Added Utilities

namespace ScenerioClass
{
    [TestFixture]
    public class FlightDealTests
    {
        private IFlightDeal flightdeal;

        [SetUp]
        public void SetUp()
        {
            flightdeal = new FlightDeal();
        }

        [TearDown]
        public void TearDown()
        {
            flightdeal.Close();
        }

        [Test]
        public void GetTitle()
        {
            flightdeal.PerformLogin("admin", "admin");
            string expectedSubtitle = "Flight deals";
            string actualSubtitle = flightdeal.Title();

            AssertionsHelper.AssertEqual(expectedSubtitle, actualSubtitle); // ✅ use helper
        }

        [Test]
        public void TestBoxSourceToDestination()
        {
            flightdeal.PerformLogin("admin", "admin");

            string expectedSource = "Seattle (SEA)";
            var expectedDestinations = new[]
            {
                "to Barcelona (BCN)",
                "to Singapore (SIN)",
                "to Puerto Nare (NAR)",
                "to Hounslow (LHR)"
            };

            for (int i = 0; i < expectedDestinations.Length; i++)
            {
                var (actualSource, actualDest) = flightdeal.BoxSourceToDestination(i + 1);
                AssertionsHelper.AssertEqual(expectedSource, actualSource);
                AssertionsHelper.AssertEqual(expectedDestinations[i], actualDest);
            }
        }

        [Test]
        public void TestBoxEndDates()
        {
            flightdeal.PerformLogin("admin", "admin");

            var expectedEndDates = new[]
            {
                "Purchase by Feb 13th 2018",
                "Purchase by Feb 13th 2017",
                "Purchase by Feb 13th 2017",
                "Purchase by Feb 13th 2017"
            };

            for (int i = 0; i < expectedEndDates.Length; i++)
            {
                string actualEndDate = flightdeal.BoxEndDate(i + 1);
                AssertionsHelper.AssertEqual(expectedEndDates[i], actualEndDate);
            }
        }

        [Test]
        public void TestBoxDescriptions()
        {
            flightdeal.PerformLogin("admin", "admin");

            var prices = new[] { 479, 528, 535, 626 };

            for (int i = 0; i < prices.Length; i++)
            {
                string expectedDescription = $"From $ {prices[i]} ONE WAY";

                string actualDescription = flightdeal.BoxDescription(i + 1)
                    .Replace("\r\n", " ")
                    .Trim()
                    .ToLower();

                string normalizedExpectedDescription = expectedDescription.ToLower().Trim();

                AssertionsHelper.AssertEqual(normalizedExpectedDescription, actualDescription);
            }
        }
    }
}