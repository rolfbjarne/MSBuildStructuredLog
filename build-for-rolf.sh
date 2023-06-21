#!/bin/bash -eux

set -o pipefail
IFS=$'\n\t'

cd src/StructuredLogViewer.Avalonia
if [[ $(arch) == "arm64" ]]; then
    RID=osx-arm64
else
    RID=osx-x64
fi
dotnet publish --self-contained -r $RID
