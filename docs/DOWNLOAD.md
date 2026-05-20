# Download Link Setup

## Local package generation
Run on Windows:

```powershell
powershell -ExecutionPolicy Bypass -File .\scripts\create-release.ps1
```

Output:
- `.artifacts\XufusLite-win-x64.zip`

## Publish to GitHub Releases (recommended)
1. Create a version tag (e.g., `v0.1.0`).
2. Open **Releases** in GitHub.
3. Create release from the tag.
4. Upload `.artifacts\XufusLite-win-x64.zip`.
5. Copy the generated asset URL and share as the official download link.

## Security checklist before sharing link
- Code-sign executable.
- Scan artifact with Defender + VirusTotal.
- Publish SHA256 checksum alongside the link.
