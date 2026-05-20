# Download Xufus Lite

## Direct Download Link (after first release)
Use the latest GitHub release URL:

`https://github.com/<your-org-or-user>/Xufus-Lite/releases/latest`

From that page, download:
- `XufusLite-win-x64.zip`

## How to create the downloadable package
1. Tag a release:
   - `git tag v0.1.0`
   - `git push origin v0.1.0`
2. GitHub Actions will build and attach `XufusLite-win-x64.zip` to the release.

## Local packaging (Windows)
Run:
- `pwsh ./tools/publish-release.ps1`

Output zip:
- `artifacts/XufusLite-win-x64.zip`
