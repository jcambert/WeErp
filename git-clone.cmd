@echo off
cls
echo Clone MicroS Services and utilities
pause

for %%d in (MicroS,MicroS.Services.Identity,MicroS.Services.Operations,MicroS.Services.SignalR,MicroS-Common) do (git -C ../../ clone https://github.com/jcambert/%%d.git)

echo Clone Complete WeErp
pause
for %%d in (weerp.api,weerp.domain,weerp.Services.Discounts,weerp.Services.Products,weerp.Services.Settings,weerp.Services.Cotations) do (git -C ../ clone https://github.com/jcambert/%%d.git)
