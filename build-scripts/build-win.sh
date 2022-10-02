#!/bin/bash

dotnet publish --configuration Release --runtime win-x64 --no-self-contained /p:PublishSingleFile=true
