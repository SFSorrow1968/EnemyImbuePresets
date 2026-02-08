using EnemyImbuePresets.Configuration;
using NUnit.Framework;

namespace EnemyImbuePresets.Tests
{
    [TestFixture]
    public class EIPModOptionsTests
    {
        [Test]
        public void Version_IsSemverLike()
        {
            Assert.That(EIPModOptions.VERSION, Is.Not.Null.And.Not.Empty);
            Assert.That(EIPModOptions.VERSION, Does.Match("^\\d+\\.\\d+\\.\\d+"));
        }

        [Test]
        public void NormalizePresets_MapsKnownAliases()
        {
            Assert.That(EIPModOptions.NormalizeFactionProfilePreset("High Magic Conflict"), Is.EqualTo(EIPModOptions.PresetProfileHighMagic));
            Assert.That(EIPModOptions.NormalizeEnemyTypeProfilePreset("mage melee"), Is.EqualTo(EIPModOptions.PresetProfileWarfront));
            Assert.That(EIPModOptions.NormalizeImbuePreset("random"), Is.EqualTo(EIPModOptions.PresetImbueRandomized));
            Assert.That(EIPModOptions.NormalizeChancePreset("Relentless Threat"), Is.EqualTo(EIPModOptions.PresetChanceRelentless));
            Assert.That(EIPModOptions.NormalizeStrengthPreset("cataclysmic"), Is.EqualTo(EIPModOptions.PresetStrengthCataclysmic));
        }

        [Test]
        public void NormalizeEnemyTypeFallback_DefaultsToMelee()
        {
            Assert.That(EIPModOptions.NormalizeEnemyTypeFallbackMode("unknown"), Is.EqualTo(EIPModOptions.EnemyTypeFallbackMelee));
            Assert.That(EIPModOptions.NormalizeEnemyTypeFallbackMode("skip"), Is.EqualTo(EIPModOptions.EnemyTypeFallbackSkip));
        }

        [Test]
        public void PresetSelectionHash_ChangesWhenPresetSelectionChanges()
        {
            string prevImbue = EIPModOptions.PresetImbue;
            try
            {
                int before = EIPModOptions.GetPresetSelectionHash();
                EIPModOptions.PresetImbue = EIPModOptions.PresetImbueRandomized;
                int after = EIPModOptions.GetPresetSelectionHash();
                Assert.That(after, Is.Not.EqualTo(before));
            }
            finally
            {
                EIPModOptions.PresetImbue = prevImbue;
            }
        }
    }
}
