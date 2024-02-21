@ECHO OFF

SET SERVER=localhost:5432
SET DB_NAME=red-cobra
SET DB_USER=red-cobra
SET DB_PASSWD=!cyHen20
SET CNN_STRING=Server=%SERVER%;Database=%DB_NAME%;User Id=%DB_USER%;Password=%DB_PASSWD%;

.\..\..\dist\evolve-db\3.2.0\windows64\evolve.exe migrate postgresql -c "%CNN_STRING%" @locations
