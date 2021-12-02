#!/bin/bash -eux

set -o pipefail
IFS=$'\n\t'

cd src/StructuredLogViewer.Avalonia
dotnet publish --self-contained -r osx-x64
