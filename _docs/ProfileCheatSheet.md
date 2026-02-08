# Profile Cheat Sheet

## Faction Profile Preset

| Preset | Combat | Outlaws | Wildfolk | Eraden | Eye | Rakta | Special | Fallback |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `Default` | Off | Off | Off | On | On | On | On | On |
| `Core Factions` | Off | Off | On | On | On | On | On | On |
| `Most Factions` | Off | On | On | On | On | On | On | On |
| `All Factions` | On | On | On | On | On | On | On | On |
| `Random` | Randomized each apply | Randomized each apply | Randomized each apply | Randomized each apply | Randomized each apply | Randomized each apply | Randomized each apply | Randomized each apply |

## Enemy Type Profile Preset

| Preset | Mage | Mage Bow | Mage Melee | Bow | Melee |
| --- | --- | --- | --- | --- | --- |
| `Mage` | On | On | On | Off | Off |
| `Mage Bow` | On | On | On | On | Off |
| `Mage Melee` | On | On | On | Off | On |
| `Mage Bow Melee` | On | On | On | On | On |
| `Random` | Randomized each apply | Randomized each apply | Randomized each apply | Randomized each apply | Randomized each apply |

## Notes

- Faction collapsibles are the source of truth; presets batch-write those values.
- In `Mage` enemy-type profile mode, caster spell mirroring is enabled by default.
- `Uncertain Enemy Type Fallback`:
  - `Treat As Melee` keeps uncertain enemies eligible under melee rules.
  - `Skip Enemy` blocks uncertain enemies until stronger signals appear.
