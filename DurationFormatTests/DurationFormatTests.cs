using NUnit.Framework;

namespace DurationFormat.Tests
{
    [TestFixture]
    public class DurationFormatTests
    {
        [Test]
        public void Now()
        {
            DurationFormat formator = new DurationFormat(0);
            Assert.AreEqual("now", formator.FormatDuration());
        }

        [Test]
        public void T_1_second()
        {
            DurationFormat formator = new DurationFormat(1);
            Assert.AreEqual("1 second", formator.FormatDuration());
        }

        [Test]
        public void T_1_minute_and_2_seconds()
        {
            DurationFormat formator = new DurationFormat(62);
            Assert.AreEqual("1 minute and 2 seconds", formator.FormatDuration());
        }

        [Test]
        public void T_2_minutes()
        {
            DurationFormat formator = new DurationFormat(120);
            Assert.AreEqual("2 minutes", formator.FormatDuration());
        }

        [Test]
        public void T_1_hour_1_minute_and_2_seconds()
        {
            DurationFormat formator = new DurationFormat(3662);
            Assert.AreEqual("1 hour, 1 minute and 2 seconds", formator.FormatDuration());
        }

        [Test]
        public void T_182_days_1_hour_44_minutes_and_40_seconds()
        {
            DurationFormat formator = new DurationFormat(15731080);
            Assert.AreEqual("182 days, 1 hour, 44 minutes and 40 seconds", formator.FormatDuration());
        }

        [Test]
        public void T_4_years_68_days_3_hours_and_4_minutes()
        {
            DurationFormat formator = new DurationFormat(132030240);
            Assert.AreEqual("4 years, 68 days, 3 hours and 4 minutes", formator.FormatDuration());
        }
    }
}