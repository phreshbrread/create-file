#!/bin/bash

dotnet publish --configuration Release --runtime linux-x64 --no-self-contained /p:PublishSingleFile=true
