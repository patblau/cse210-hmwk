# Develop03 (Scripture Memorizer)

## How to run
```bash
# from inside this folder
dotnet build
dotnet run
```

## Files
- Program.cs — entry point (handles user loop)
- Reference.cs — single-verse and verse-range reference (e.g., Proverbs 3:5–6)
- Word.cs — tracks a single token and whether it's hidden
- Scripture.cs — holds words + reference, hides random visible words, renders display

## Notes
- Adjust difficulty by changing the number passed to `HideRandomWords(n)` in Program.cs.
- If you get a “multiple entry points” error, make sure only this project has a `Main` method, or set this project as the Startup Project.
