# Troubleshooting

## No imbues applied
- Confirm `Enable Mod` is on.
- Confirm the relevant faction profile is enabled.
- Confirm slot strengths and normalized slot chances are above `0`.
- Confirm spell ids exist in the current catalog.

## Wrong faction behavior
- Verify faction `Enabled` toggles in collapsibles and confirm the selected faction profile preset.
- Compare those ids to profile mapping in logs.

## Spell applies but looks weak
- Raise slot `Strength`.
- Use `Force Reapply` after changing options.
- Enable `Verbose Logs` and check spell transfer + energy writes.

## Enemy type eligibility not behaving as expected
- Verify `Mage Eligible`, `Bow Eligible`, and `Melee Eligible` values.
- Verify `Uncertain Enemy Type Fallback` is set as intended (`Treat As Melee` vs `Skip Enemy`).
- Enable `Verbose Logs` and check `enemyType=Mage`, `enemyType=Bow`, or `enemyType=Melee` in track lines.
- Remember `Enemy Type Profile Preset` changes can overwrite enemy-type toggles.

## Lore-friendly caster mirror seems wrong
- In `Casters` profile mode, caster enemies attempt to use their loaded/casting spell id for imbues.
- If that spell id is missing or not a valid `SpellCastCharge`, the system falls back to the selected slot spell.
- Enable `Verbose Logs` to confirm the assigned slot spell and current faction values.
