@echo off
cls
echo Ckeckout Master and Pull MicroS
pause
for /D %%d in (MicroS,MicroS.Services.Identity,MicroS.Services.Operations,MicroS.Services.SignalR,MicroS-Common) do (git --git-dir=../../%%d/.git checkout master && git --git-dir=../../%%d/.git pull)


echo Ckeckout Master and Pull WeErp
pause
for /D %%d in (./,../weerp.api,../weerp.domain,../weerp.Services.Discounts,../weerp.Services.Products,../weerp.Services.Settings,../weerp.Services.Cotations) do (git --git-dir=%%d/.git checkout master && git --git-dir=%%d/.git pull)


