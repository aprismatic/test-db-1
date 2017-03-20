FROM  microsoft/mssql-server-windows-developer
MAINTAINER  bazzilic "bazzilic@gmail.com"

COPY  Test-DB-1.dacpac  C:/Test-DB-1.dacpac
COPY  start.ps1  C:/start.ps1
COPY  *.dll  C:/
ENV   sa_password  saPwd123
ENV   ACCEPT_EULA  Y

SHELL [ "powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';" ]

RUN   Start-Service MSSQLSERVER ; \
      for( $cnt = 1; $cnt -le 10; $cnt++ ) { $ErrorActionPreference = 'Continue' ; \
                                             Invoke-Sqlcmd -Query \"SELECT 1\" | Out-Null; \
                                             if ($?) { $cnt = 10 } else { Write-Output \"Connection attempt $cnt failed\" ; sleep $(2*$cnt+1) } ; \
                                             $ErrorActionPreference = 'Stop' } ; \
      Invoke-Sqlcmd -Query \"ALTER LOGIN sa with password='$env:sa_password'; ALTER LOGIN sa ENABLE;\" ; \
      & \"C:/Program Files (x86)/Microsoft SQL Server/130/DAC/bin/SqlPackage.exe\" \
                  /a:Publish \
                  /tcs:\"Data Source=localhost,1433;\
                         Persist Security Info=True;\
                         User ID=sa;Pooling=False;\
                         MultipleActiveResultSets=False;\
                         Connect Timeout=60;\
                         Encrypt=False;\
                         TrustServerCertificate=True;\
                         Password=${env:sa_password};\
                         Database=Test-DB-1\" \
                  /sf:C:/Test-DB-1.dacpac ; \
      Stop-Service MSSQLSERVER ; \
      rm *.dacpac ; \
      rm *.dll

ENTRYPOINT ["powershell", "-file C:/start.ps1"]
