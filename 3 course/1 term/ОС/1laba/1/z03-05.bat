@echo off
echo -- parametres: %*
echo -- parameter 1: %1
echo -- parameter 2: %2
echo -- parameter 3: %3

set /a res= %1 %3 %2
echo -- result: %res%
@pause