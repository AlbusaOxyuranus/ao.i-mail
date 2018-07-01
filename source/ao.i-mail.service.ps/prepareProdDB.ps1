#﻿
# Script.ps1
# Autor: Denis Prokhorchik
# Date: 06.06.2018
# Version: 0.1
#
param(
[string]$DBName
)
echo "==========================================================================================================="
echo $DBName
$servername="WINSTATION";
#$DBName="i-account-tests.db"
#$DBName="i-account.db"
#$Username="dionis_999@hotmail.com";
#$Password="ps";

import-module "sqlps" -DisableNameChecking
$directoryPath = Split-Path $MyInvocation.MyCommand.Path;
$directoryScripts =$directoryPath.Substring(0,$directoryPath.LastIndexOf('\'))+"\Data\ao.i-mail.service.db\Scripts\";
$directoryScriptsConstraints =$directoryPath.Substring(0,$directoryPath.LastIndexOf('\'))+"\Data\ao.i-mail.service.db\Scripts\Constraints";
$baseDirectoryOutput = $directoryPath.Substring(0,$directoryPath.LastIndexOf('\'))+"\Data\ao.i-mail.service.db\";
$directoryScriptsStoredProcedures =$directoryPath.Substring(0,$directoryPath.LastIndexOf('\'))+"\Data\ao.i-mail.service.db\dbo\Programmability\Stored Procedures";
$directoryOutput = $baseDirectoryOutput+"Output\";
echo $directoryOutput
New-Item -Path $directoryOutput -ItemType directory -Force;
Get-ChildItem -Path $directoryOutput -Include * -File -Recurse | foreach { $_.Delete()}

#echo " - Initialization DBs - "
#invoke-sqlcmd  -ServerInstance $servername -Database $DBName -InputFile 'D:\Git\GitHub\ao.i-account\source\Data\ao.i-account.db\DDL - iaccount - Initialization.sql' | format-table -verbose

echo " - Scripts - "
foreach ($f in Get-ChildItem -path  $directoryScripts -Filter *.sql | sort-object -desc ) 
{ 
    $out =  $directoryOutput+ $f.name.Substring(0,$f.name.LastIndexOf('.')) + ".txt" ; 
    invoke-sqlcmd  -ServerInstance $servername -Database $DBName -InputFile $f.fullname | format-table | out-file -filePath $out -verbose
    invoke-sqlcmd  -ServerInstance $servername -Database $DBName -inputFile $f.fullname -verbose *>&1 | out-File -filepath $out
}

echo " - Constraints - "
foreach ($f in Get-ChildItem -path  $directoryScriptsConstraints -Filter *.sql | sort-object -desc ) 
{ 
    $out =  $directoryOutput+ $f.name.Substring(0,$f.name.LastIndexOf('.')) + ".txt" ; 
    invoke-sqlcmd  -ServerInstance $servername -Database $DBName -InputFile $f.fullname | format-table | out-file -filePath $out -verbose
    invoke-sqlcmd  -ServerInstance $servername -Database $DBName -inputFile $f.fullname -verbose *>&1 | out-File -filepath $out
}

echo " - Procedures - "
#Execute Stored Procedures
foreach ($f in Get-ChildItem -path  $directoryScriptsStoredProcedures -Filter *.sql | sort-object -desc ) 
{ 
    $out =  $directoryOutput+ $f.name.Substring(0,$f.name.LastIndexOf('.')) + ".txt" ; 
    invoke-sqlcmd  -ServerInstance $servername -Database $DBName -InputFile $f.fullname | format-table | out-file -filePath $out -verbose
    invoke-sqlcmd  -ServerInstance $servername -Database $DBName -inputFile $f.fullname -verbose *>&1 | out-File -filepath $out
}

echo " - end - "