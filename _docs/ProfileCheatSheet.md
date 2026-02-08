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

| Preset | Mage | Bow | Melee |
| --- | --- | --- | --- |
| `Casters` | On | Off | Off |
| `Ranged` | On | On | Off |
| `All` | On | On | On |

## Notes

- Faction collapsibles are the source of truth; presets batch-write those values.
- In `Casters` enemy-type profile mode, caster spell mirroring is enabled by default.
- `Uncertain Enemy Type Fallback`:
  - `Treat As Melee` keeps uncertain enemies eligible under melee rules.
  - `Skip Enemy` blocks uncertain enemies until stronger signals appear.
