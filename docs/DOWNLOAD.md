# Download Xufus Lite (.exe)

## Direct Download (EXE package)
After the first release is published, open:

`https://github.com/<your-org-or-user>/Xufus-Lite/releases/latest`

Download this file from **Assets**:
- `XufusLite-win-x64.zip`

Then extract it and run:
- `XufusLite.App.exe`

---

## One-click EXE link format
After you publish a tagged release (example: `v0.1.0`), you can share this direct asset URL:

`https://github.com/<your-org-or-user>/Xufus-Lite/releases/download/v0.1.0/XufusLite-win-x64.zip`

(Replace `v0.1.0` with your current tag.)

---

## How to publish the EXE package
1. Create and push a release tag:
   - `git tag v0.1.0`
   - `git push origin v0.1.0`
2. GitHub Actions workflow builds and uploads `XufusLite-win-x64.zip` to the release.
3. Users download zip, extract, and run `XufusLite.App.exe`.

---

## Build EXE package locally (Windows)
Run:
- `pwsh ./tools/publish-release.ps1`

Output:
- `artifacts/XufusLite-win-x64.zip`
- `artifacts/publish/win-x64/XufusLite.App.exe`
