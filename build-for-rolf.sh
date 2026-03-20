#!/bin/bash -eux

set -o pipefail
IFS=$'\n\t'

cd "$(dirname "${BASH_SOURCE[0]}")"

REPO_ROOT=$(pwd)
PROJECT_DIR=src/StructuredLogViewer.Avalonia
APP_NAME=StructuredLogViewer
PUBLISH_DIR="$REPO_ROOT/artifacts/publish"
BUNDLE_DIR="$REPO_ROOT/artifacts/$APP_NAME.app"

if [[ $(arch) == "arm64" ]]; then
    RID=osx-arm64
else
    RID=osx-x64
fi

dotnet publish "$PROJECT_DIR" --self-contained -r $RID -o "$PUBLISH_DIR"

# Create the .app bundle
rm -rf "$BUNDLE_DIR"
mkdir -p "$BUNDLE_DIR/Contents/MacOS"
mkdir -p "$BUNDLE_DIR/Contents/Resources"
mkdir -p "$BUNDLE_DIR/Contents/Frameworks"

cp "$PROJECT_DIR/Info.plist" "$BUNDLE_DIR/Contents/"
cp "$PROJECT_DIR/StructuredLogViewer.icns" "$BUNDLE_DIR/Contents/Resources/"
cp -a "$PUBLISH_DIR/" "$BUNDLE_DIR/Contents/MacOS/"

codesign --force --deep --sign - "$BUNDLE_DIR"

echo ""
echo "App bundle created: $BUNDLE_DIR"

