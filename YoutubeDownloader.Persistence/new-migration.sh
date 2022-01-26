#!/usr/bin/bash
dotnet ef migrations add $1 --startup-project ../YoutubeDownloader.WebApi/