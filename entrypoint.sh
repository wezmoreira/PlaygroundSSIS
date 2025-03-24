#!/bin/bash

/opt/mssql/bin/sqlservr &

echo "Aguardando o SQL Server iniciar..."
sleep 30s

echo "Executando o script de inicialização..."
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "$SA_PASSWORD" -i /usr/config/init.sql

wait